﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Cuemon.IO;

namespace Cuemon
{
    /// <summary>
    /// This utility class is designed to make <see cref="Byte"/> related conversions easier to work with.
    /// </summary>
    public static class ByteConverter
    {
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
            return TryFromBase64String(value, StringUtility.SkipIfKnownChecksumLength, out result);
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
        public static bool TryFromBase64String(string value, Doer<string, bool> predicate, out byte[] result)
        {
            try
            {
                Validator.ThrowIfNullOrEmpty(value, nameof(value));
                if (predicate != null && predicate(value)) { throw new FormatException(); }
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
        /// Converts the specified <paramref name="value"/> to a byte array always starting from position 0 (when supported).
        /// </summary>
        /// <param name="value">The <see cref="Stream"/> value to be converted.</param>
        /// <returns>A <b>byte array</b> containing the data from the stream.</returns>
        public static byte[] FromStream(Stream value)
        {
            return FromStream(value, false);
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to a byte array.
        /// </summary>
        /// <param name="value">The <see cref="Stream"/> value to be converted.</param>
        /// <param name="leaveStreamOpen">if <c>true</c>, the <see cref="Stream"/> object is being left open; otherwise it is being closed and disposed.</param>
        /// <returns>A <b>byte array</b> containing the data from the stream.</returns>
        public static byte[] FromStream(Stream value, bool leaveStreamOpen)
        {
            Validator.ThrowIfNull(value, nameof(value));
            return FromStreamCore(value, leaveStreamOpen);
        }

        private static byte[] FromStreamCore(Stream value, bool leaveStreamOpen)
        {
            MemoryStream s = value as MemoryStream;
            if (s != null)
            {
                if (leaveStreamOpen) { return s.ToArray(); }
                using (s) { return s.ToArray(); }
            }
            return ((MemoryStream)StreamUtility.CopyStream(value, leaveStreamOpen)).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to a byte array using UTF-16 for the encoding preserving any preamble sequences.
        /// </summary>
        /// <param name="value">The string to be converted.</param>
        /// <returns>A <b>byte array</b> containing the results of encoding the specified set of characters.</returns>
        public static byte[] FromString(string value)
        {
            return FromString(value, PreambleSequence.Keep);
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to a byte array using UTF-16 for the encoding.
        /// </summary>
        /// <param name="value">The string to be converted.</param>
        /// <param name="sequence">Determines whether too keep or remove any preamble sequences.</param>
        /// <returns>A <b>byte array</b> containing the results of encoding the specified set of characters.</returns>
        public static byte[] FromString(string value, PreambleSequence sequence)
        {
            return FromString(value, sequence, Encoding.Unicode);
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> to a byte array using the provided preferred encoding.
        /// </summary>
        /// <param name="value">The string to be converted.</param>
        /// <param name="sequence">Determines whether too keep or remove any preamble sequences.</param>
        /// <param name="encoding">The preferred encoding to apply to the result.</param>
        /// <returns>A <b>byte array</b> containing the results of encoding the specified set of characters.</returns>
        public static byte[] FromString(string value, PreambleSequence sequence, Encoding encoding)
        {
            Validator.ThrowIfNull(value, nameof(value));
            Validator.ThrowIfNull(encoding, nameof(encoding));

            byte[] valueInBytes;
            switch (sequence)
            {
                case PreambleSequence.Keep:
                    valueInBytes = ByteUtility.CombineByteArrays(encoding.GetPreamble(), encoding.GetBytes(value));
                    break;
                case PreambleSequence.Remove:
                    valueInBytes = encoding.GetBytes(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sequence));
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
        public static byte[] FromConvertible<T>(T value) where T : struct, IConvertible
        {
            return FromConvertiblesCore(value);
        }

        /// <summary>
        /// Converts the specified sequence of <paramref name="values"/> to an array of bytes.
        /// </summary>
        /// <param name="values">A sequence of <see cref="IConvertible"/> values to convert.</param>
        /// <returns>An array of bytes equivalent to the sequence of the <paramref name="values"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="values"/> is outside the range of allowed types.<br/>
        /// Allowed types are: <see cref="Boolean"/>, <see cref="Char"/>, <see cref="double"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="ushort"/>, <see cref="UInt32"/> and <see cref="UInt64"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="values"/> is null.
        /// </exception>
        public static byte[] FromConvertibles<T>(IEnumerable<T> values) where T : struct, IConvertible
        {
            Validator.ThrowIfNull(values, nameof(values));
            List<byte> result = new List<byte>();
            foreach (T value in values)
            {
                result.AddRange(FromConvertiblesCore(value));
            }
            return result.ToArray();
        }

        private static byte[] FromConvertiblesCore<T>(T value) where T : struct, IConvertible
        {
            TypeCode code = value.GetTypeCode();
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