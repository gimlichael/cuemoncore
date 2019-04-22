﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Cuemon.Text;

namespace Cuemon
{
    /// <summary>
    /// This utility class is designed to make <see cref="Byte"/> related conversions easier to work with.
    /// </summary>
    public static class ByteConverter
    {
        /// <summary>
        /// Decodes a URL string token to its equivalent byte array using base 64 digits.
        /// </summary>
        /// <param name="value">The URL string token to decode.</param>
        /// <returns>The byte array containing the decoded URL string token.</returns>
        /// <remarks>
        /// Source: http://tools.ietf.org/html/draft-ietf-jose-json-web-signature-08#appendix-C
        /// </remarks>
        public static byte[] FromUrlEncodedBase64(string value)
        {
            Validator.ThrowIfNullOrEmpty(value, nameof(value));
            value = value.Replace('-', '+');
            value = value.Replace('_', '/');
            switch (value.Length % 4)
            {
                case 0:
                    break;
                case 2:
                    value += "==";
                    break;
                case 3:
                    value += "=";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), "Illegal Base64 URL string.");
            }
            return Convert.FromBase64String(value);
        }

        /// <summary>
        /// Converts the string representation of a Base64 to its equivalent <see cref="T:byte[]"/> array.
        /// </summary>
        /// <param name="value">The Base64 to convert.</param>
        /// <param name="result">The array that will contain the parsed value.</param>
        /// <returns><c>true</c> if the parse operation was successful; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// This method returns <c>false</c> if <paramref name="value"/> is <c>null</c>, <c>empty</c> or not in a recognized format, and does not throw an exception.<br/>
        /// <paramref name="result"/> will have a default value of <c>null</c>.
        /// </remarks>
        public static bool TryFromBase64String(string value, out byte[] result)
        {
            return TryFromBase64String(value, StringUtility.IsValueWithValidBase64ChecksumLength, out result);
        }

        /// <summary>
        /// Converts the string representation of a Base64 to its equivalent <see cref="T:byte[]"/> array.
        /// </summary>
        /// <param name="value">The Base64 to convert.</param>
        /// <param name="predicate">A function delegate that provides custom rules for bypassing the Base64 structure check.</param>
        /// <param name="result">The array that will contain the parsed value.</param>
        /// <returns><c>true</c> if the parse operation was successful; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// This method returns <c>false</c> if <paramref name="value"/> is <c>null</c>, <c>empty</c> or not in a recognized format, and does not throw an exception.<br/>
        /// <paramref name="result"/> will have a default value of <c>null</c>.
        /// </remarks>
        public static bool TryFromBase64String(string value, Func<string, bool> predicate, out byte[] result)
        {
            try
            {
                Validator.ThrowIfNullOrEmpty(value, nameof(value));
                if (predicate != null && !predicate(value)) { throw new FormatException(); }
                result = Convert.FromBase64String(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to a byte array.
        /// </summary>
        /// <param name="value">The <see cref="Stream"/> value to be converted.</param>
        /// <param name="leaveOpen">if <c>true</c>, the <see cref="Stream"/> object is being left open; otherwise it is being closed and disposed.</param>
        /// <returns>A <b>byte array</b> containing the data from the stream.</returns>
        public static byte[] FromStream(Stream value, bool leaveOpen = false)
        {
            Validator.ThrowIfNull(value, nameof(value));
            Validator.ThrowIfFalse(value.CanRead, nameof(value), "Source stream cannot be read from.");
            Validator.ThrowIfGreaterThan(value.Length, int.MaxValue, nameof(value));
            if (value is MemoryStream s)
            {
                if (leaveOpen) { return s.ToArray(); }
                using (s) { return s.ToArray(); }
            }
            using (var memoryStream = new MemoryStream(new byte[value.Length]))
            {
                value.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to a byte array using the provided preferred encoding.
        /// </summary>
        /// <param name="value">The string to be converted.</param>
        /// <param name="setup">The <see cref="EncodingOptions"/> which need to be configured.</param>
        /// <returns>A <b>byte array</b> which is the result of the specified delegate <paramref name="setup"/>.</returns>
        /// <remarks><see cref="EncodingOptions"/> will be initialized with <see cref="EncodingOptions.DefaultPreambleSequence"/> and <see cref="EncodingOptions.DefaultEncoding"/>.</remarks>
        public static byte[] FromString(string value, Action<EncodingOptions> setup = null)
        {
            Validator.ThrowIfNull(value, nameof(value));
            var options = setup.Configure();

            byte[] valueInBytes;
            switch (options.Preamble)
            {
                case PreambleSequence.Keep:
                    valueInBytes = ByteUtility.CombineByteArrays(options.Encoding.GetPreamble(), options.Encoding.GetBytes(value));
                    break;
                case PreambleSequence.Remove:
                    valueInBytes = options.Encoding.GetBytes(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(setup));
            }
            return valueInBytes;
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to an array of bytes.
        /// </summary>
        /// <param name="value">The <see cref="IConvertible"/> value to convert.</param>
        /// <returns>An array of bytes equivalent to the data of the <paramref name="value"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> is outside the range of allowed types.<br/>
        /// Allowed types are: <see cref="Boolean"/>, <see cref="Char"/>, <see cref="double"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="ushort"/>, <see cref="UInt32"/> and <see cref="UInt64"/>.
        /// </exception>
        public static byte[] FromConvertibles<T>(T value) where T : struct, IConvertible
        {
            return FromConvertiblesCore(value);
        }

        /// <summary>
        /// Converts the specified sequence of <paramref name="source"/> to an array of bytes.
        /// </summary>
        /// <param name="source">A sequence of <see cref="IConvertible"/> values to convert.</param>
        /// <returns>An array of bytes equivalent to the sequence of the <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="source"/> is outside the range of allowed types.<br/>
        /// Allowed types are: <see cref="Boolean"/>, <see cref="Char"/>, <see cref="double"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="ushort"/>, <see cref="UInt32"/> and <see cref="UInt64"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> is null.
        /// </exception>
        public static byte[] FromConvertibles<T>(IEnumerable<T> source) where T : struct, IConvertible
        {
            Validator.ThrowIfNull(source, nameof(source));
            var result = new List<byte>();
            foreach (var value in source)
            {
                result.AddRange(FromConvertiblesCore(value));
            }
            return result.ToArray();
        }

        private static byte[] FromConvertiblesCore<T>(T value) where T : struct, IConvertible
        {
            var code = value.GetTypeCode();
            byte[] result;
            switch (code)
            {
                case TypeCode.Boolean:
                    result = BitConverter.GetBytes(value.ToBoolean(CultureInfo.InvariantCulture));
                    break;
                case TypeCode.Char:
                    result = BitConverter.GetBytes(value.ToChar(CultureInfo.InvariantCulture));
                    break;
                case TypeCode.Double:
                    result = BitConverter.GetBytes(value.ToDouble(CultureInfo.InvariantCulture));
                    break;
                case TypeCode.Int16:
                    result = BitConverter.GetBytes(value.ToInt16(CultureInfo.InvariantCulture));
                    break;
                case TypeCode.Int32:
                    result = BitConverter.GetBytes(value.ToInt32(CultureInfo.InvariantCulture));
                    break;
                case TypeCode.Int64:
                    result = BitConverter.GetBytes(value.ToInt64(CultureInfo.InvariantCulture));
                    break;
                case TypeCode.Single:
                    result = BitConverter.GetBytes(value.ToSingle(CultureInfo.InvariantCulture));
                    break;
                case TypeCode.UInt16:
                    result = BitConverter.GetBytes(value.ToUInt16(CultureInfo.InvariantCulture));
                    break;
                case TypeCode.UInt32:
                    result = BitConverter.GetBytes(value.ToUInt32(CultureInfo.InvariantCulture));
                    break;
                case TypeCode.UInt64:
                    result = BitConverter.GetBytes(value.ToUInt64(CultureInfo.InvariantCulture));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), string.Format(CultureInfo.InvariantCulture, "Value appears to contain an invalid type. Expected type is one of the following: Boolean, Char, Double, Int16, Int32, Int64, UInt16, UInt32 or UInt64. Actually type was {0}.", code));
            }

            if (BitConverter.IsLittleEndian) { Array.Reverse(result); }
            return result;
        }
    }
}