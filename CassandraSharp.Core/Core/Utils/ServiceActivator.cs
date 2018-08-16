﻿// cassandra-sharp - high performance .NET driver for Apache Cassandra
// Copyright (c) 2011-2013 Pierre Chalamet
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace CassandraSharp.Utils
{
    using CassandraSharp.Enlightenment;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal interface IServiceDescriptor
    {
        IDictionary<string, Type> Definition { get; }
    }

    internal sealed class ServiceActivator<T> where T : IServiceDescriptor, new()
    {
// ReSharper disable StaticFieldInGenericType
        private static readonly IServiceDescriptor _descriptor = new T();

// ReSharper restore StaticFieldInGenericType

        public static TI Create<TI>(string customType, params object[] prms)
        {
            if (string.IsNullOrEmpty(customType))
            {
                string emptyTypeMsg = string.Format("Expecting nickname or qualified class name for '{0}'", typeof(TI).AssemblyQualifiedName);
                throw new ArgumentException(emptyTypeMsg);
            }

            Type type;
            if (!_descriptor.Definition.TryGetValue(customType, out type))
            {
                type = Type.GetType(customType);
            }

            if (null == type || !typeof(TI).IsAssignableFrom(type))
            {
                string invalidTypeMsg = string.Format("'{0}' is not a valid type", customType);
                throw new ArgumentException(invalidTypeMsg);
            }

            return EnlightenmentMgr.Create<TI>(type, prms);
        }
    }
}