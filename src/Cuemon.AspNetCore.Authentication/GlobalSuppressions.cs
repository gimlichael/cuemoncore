﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "By design to support the Digest protocol.", Scope = "member", Target = "~M:Cuemon.AspNetCore.Authentication.Digest.DigestAuthorizationHeader.#ctor(System.String,System.String,System.String,System.String,System.String,System.String,System.String,System.String,System.String,System.String,System.String)")]