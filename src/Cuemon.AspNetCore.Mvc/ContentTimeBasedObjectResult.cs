﻿using System;
using Cuemon.Data.Integrity;
using Cuemon.Security.Cryptography;

namespace Cuemon.AspNetCore.Mvc
{
    internal class ContentTimeBasedObjectResult :  CacheableObjectResult, IEntityData
    {
        internal ContentTimeBasedObjectResult(object instance, IEntityDataTimestamp timestamp, IEntityDataIntegrity dataIntegrity) : base(instance)
        {
            Created = timestamp.Created;
            Checksum = dataIntegrity.Checksum;
            Modified = timestamp.Modified;
            Validation = dataIntegrity.Validation;
        }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public EntityDataIntegrityStrength Validation { get; set; }

        public HashResult Checksum { get; set; }
    }

    internal class ContentTimeBasedObjectResult<T> : ContentTimeBasedObjectResult
    {
        internal ContentTimeBasedObjectResult(T instance, IEntityDataTimestamp timestamp, IEntityDataIntegrity dataIntegrity) : base(instance, timestamp, dataIntegrity)
        {
        }
    }
}