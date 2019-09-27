﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cuemon.Diagnostics
{
    public class MemberEvidence
    {
        internal MemberEvidence(string memberSignature, IDictionary<string, string> runtimeParameters)
        {
            Validator.ThrowIfNullOrWhitespace(memberSignature, nameof(memberSignature));
            MemberSignature = memberSignature;
            RuntimeParameters = runtimeParameters ?? new Dictionary<string, string>();
        }

        public string MemberSignature { get; }

        public IDictionary<string, string> RuntimeParameters { get; }
    }
}