﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Cuemon.Serialization.Xml.Converters;
using Cuemon.Xml;

namespace Cuemon.Serialization.Xml
{
    /// <summary>
    /// Serializes and deserializes objects into and from the XML format.
    /// </summary>
    public class XmlSerializer
    {
        /// <summary>
        /// Creates a new <see cref="XmlSerializer"/> instance using the specified <see cref="XmlSerializerSettings"/>.
        /// </summary>
        /// <param name="settings">The settings to be applied to the <see cref="XmlSerializer"/>.</param>
        /// <returns>
        /// A new <see cref="XmlSerializer"/> instance using the specified <see cref="XmlSerializerSettings"/>.
        /// </returns>
        /// <remarks>If <paramref name="settings"/> is <c>null</c>, <seealso cref="XmlConvert.DefaultSettings"/> is tried invoked. Otherwise, as a fallback, a default instance of <seealso cref="XmlSerializerSettings"/> is created.</remarks>
        public static XmlSerializer Create(XmlSerializerSettings settings)
        {
            var defaultSetup = settings ?? XmlConvert.DefaultSettings?.Invoke();
            return new XmlSerializer(defaultSetup);
        }

        /// <summary>
        /// Serializes the specified <paramref name="value"/> to a <see cref="Stream" />.
        /// </summary>
        /// <param name="value">The object to serialize to XML format.</param>
        /// <param name="objectType">The type of the object to serialize.</param>
        /// <returns>A stream of the serialized object.</returns>
        public Stream Serialize(object value, Type objectType)
        {
            return XmlWriterUtility.CreateXml(writer =>
            {
                Serialize(writer, value, objectType);
            }, settings =>
            {
                settings.Encoding = Settings.Writer.Encoding;
                settings.OmitXmlDeclaration = Settings.Writer.OmitXmlDeclaration;
                settings.CheckCharacters = Settings.Writer.CheckCharacters;
                settings.CloseOutput = Settings.Writer.CloseOutput;
                settings.ConformanceLevel = Settings.Writer.ConformanceLevel;
                settings.Indent = Settings.Writer.Indent;
                settings.IndentChars = Settings.Writer.IndentChars;
                settings.NamespaceHandling = Settings.Writer.NamespaceHandling;
                settings.NewLineChars = Settings.Writer.NewLineChars;
                settings.NewLineHandling = Settings.Writer.NewLineHandling;
                settings.NewLineOnAttributes = Settings.Writer.NewLineOnAttributes;
                settings.WriteEndDocumentOnClose = Settings.Writer.WriteEndDocumentOnClose;
                settings.Async = Settings.Writer.Async;
            });
        }

        /// <summary>
        /// Deserializes the specified <paramref name="value"/> into an object of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="value">The object to deserialize from XML format.</param>
        /// <returns>An object of <typeparamref name="T"/>.</returns>
        public T Deserialize<T>(Stream value)
        {
            return (T)Deserialize(value, typeof(T));
        }

        /// <summary>
        /// Deserializes the specified <paramref name="value" /> into an object of <paramref name="objectType"/>.
        /// </summary>
        /// <param name="value">The object to deserialize from XML format.</param>
        /// <param name="objectType">The type of the object to deserialize.</param>
        /// <returns>An object of <paramref name="objectType"/>.</returns>
        public object Deserialize(Stream value, Type objectType)
        {
            using (var reader = XmlReaderConverter.FromStream(value, null, settings =>
            {
                settings.ConformanceLevel = Settings.Reader.ConformanceLevel;
                settings.IgnoreComments = Settings.Reader.IgnoreComments;
                settings.IgnoreProcessingInstructions = Settings.Reader.IgnoreProcessingInstructions;
                settings.IgnoreWhitespace = Settings.Reader.IgnoreWhitespace;
                settings.LineNumberOffset = Settings.Reader.LineNumberOffset;
                settings.LinePositionOffset = Settings.Reader.LinePositionOffset;
                settings.MaxCharactersFromEntities = Settings.Reader.MaxCharactersFromEntities;
                settings.MaxCharactersInDocument = Settings.Reader.MaxCharactersInDocument;
                settings.NameTable = Settings.Reader.NameTable;
                settings.Async = Settings.Reader.Async;
                settings.DtdProcessing = Settings.Reader.DtdProcessing;
                settings.CloseInput = Settings.Reader.CloseInput;
                settings.CheckCharacters = Settings.Reader.CheckCharacters;
            }))
            {
                return Deserialize(reader, objectType);
            }
        }

        internal XmlSerializer(XmlSerializerSettings settings)
        {
            Settings = settings ?? new XmlSerializerSettings();
        }

        internal void Serialize(XmlWriter writer, object value, Type objectType)
        {
            GetWriterConverter(objectType).WriteXml(writer, value);
        }

        internal object Deserialize(XmlReader reader, Type objectType)
        {
            return GetReaderConverter(objectType).ReadXml(reader, objectType);
        }

        internal XmlSerializerSettings Settings { get; }

        internal IList<XmlConverter> Converters => Settings.Converters;

        internal XmlConverter GetReaderConverter(Type objectType)
        {
            var converter = Converters.FirstOrDefaultReaderConverter(objectType);
            return converter ?? new DefaultXmlConverter(Settings.RootName, Settings.Converters);
        }

        internal XmlConverter GetWriterConverter(Type objectType)
        {
            var converter = Converters.FirstOrDefaultWriterConverter(objectType);
            return converter ?? new DefaultXmlConverter(Settings.RootName, Settings.Converters);
        }
    }
}