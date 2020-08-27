﻿// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNumber(System.String,System.String,System.String,System.Globalization.NumberStyles,System.IFormatProvider)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfContainsType(System.Object,System.String,System.String,System.Type[])")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfContainsType(System.Type,System.String,System.String,System.Type[])")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfContainsType``1(System.String,System.String,System.Type[])")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfEmailAddress(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfEmpty(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfEnum``1(System.String,System.Boolean,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfEnumType(System.Type,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfEnumType``1(System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfEqual``1(``0,``0,System.Collections.Generic.IEqualityComparer{``0},System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfFalse(System.Boolean,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfGreaterThan``1(``0,``0,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfGreaterThanOrEqual``1(``0,``0,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfGuid(System.String,Cuemon.GuidFormats,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfHex(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfLowerThan``1(``0,``0,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfLowerThanOrEqual``1(``0,``0,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotBase64String(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotBinaryDigits(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotContainsType(System.Object,System.String,System.String,System.Type[])")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotContainsType(System.Type,System.String,System.String,System.Type[])")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotContainsType``1(System.String,System.String,System.Type[])")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotEmailAddress(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotEnum``1(System.String,System.Boolean,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotEnumType(System.Type,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotEnumType``1(System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotEqual``1(``0,``0,System.Collections.Generic.IEqualityComparer{``0},System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotGuid(System.String,Cuemon.GuidFormats,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotHex(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotSame``1(``0,``0,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNotUri(System.String,System.UriKind,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNull``1(``0,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNullOrEmpty(System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNullOrEmpty(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNullOrWhitespace(System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfNullOrWhitespace(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfSame``1(``0,``0,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfTrue(System.Boolean,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfUri(System.String,System.UriKind,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3445:Exceptions should not be explicitly rethrown", Justification = "This is by design; we only want the stacktrace from within the validator method.", Scope = "member", Target = "~M:Cuemon.Validator.ThrowIfWhiteSpace(System.String,System.String,System.String)")]
[assembly: SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "This is a base class implementation of the IDisposable interface tailored to avoid wrong implementations.", Scope = "type", Target = "~T:Cuemon.Disposable")]
[assembly: SuppressMessage("Minor Code Smell", "S1128:Unused \"using\" should be removed", Justification = "It is actually used when resolving extension method from System.Collections.Generic; SC just can't figure this out.")]
[assembly: SuppressMessage("Major Code Smell", "S1168:Empty arrays and collections should be returned instead of null", Justification = "By design; property serves it purpose.", Scope = "member", Target = "~P:Cuemon.Data.ConcurrentDsvDataReader.NullRead")]
[assembly: SuppressMessage("Critical Code Smell", "S927:parameter names should match base declaration and other partial definitions", Justification = "By design to help clarify context.", Scope = "member", Target = "~M:Cuemon.Data.ConcurrentDsvDataReader.ReadNext(System.String[])~System.String[]")]
[assembly: SuppressMessage("Critical Code Smell", "S927:parameter names should match base declaration and other partial definitions", Justification = "By design to help clarify context.", Scope = "member", Target = "~M:Cuemon.Data.DsvDataReader.ReadNext(System.String[])~System.String[]")]
[assembly: SuppressMessage("Major Code Smell", "S1168:Empty arrays and collections should be returned instead of null", Justification = "By design; property serves it purpose.", Scope = "member", Target = "~P:Cuemon.Data.DsvDataReader.NullRead")]
[assembly: SuppressMessage("Minor Code Smell", "S1199:Nested code blocks should not be used", Justification = "By design.", Scope = "member", Target = "~M:Cuemon.IO.StreamFactory.CreateStreamCore``1(Cuemon.ActionFactory{``0},System.Action{Cuemon.IO.StreamWriterOptions})~System.IO.Stream")]
[assembly: SuppressMessage("Major Bug", "S1751:Loops with at most one iteration should be refactored", Justification = "This is by design and how a reader is implemented. While there are lines to be read, we built a token, and the token is being read. When read, it returns true and proceeds to next line.", Scope = "member", Target = "~M:Cuemon.Data.DsvDataReader.Read~System.Boolean")]
[assembly: SuppressMessage("Major Bug", "S1751:Loops with at most one iteration should be refactored", Justification = "This is by design and how a reader is implemented. While there are lines to be read, we built a token, and the token is being read. When read, it returns true and proceeds to next line.", Scope = "member", Target = "~M:Cuemon.Data.ConcurrentDsvDataReader.ReadAsync~System.Threading.Tasks.Task{System.Boolean}")]
