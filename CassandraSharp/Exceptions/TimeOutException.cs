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

namespace CassandraSharp.Exceptions
{
    using System;

    [Serializable]
    public class TimeOutException : CassandraException
    {
        protected TimeOutException(ErrorCodes code, string message, ConsistencyLevel consistencyLevel, int received, int blockFor)
                : base(code, message)
        {
            ConsistencyLevel = consistencyLevel;
            Received = received;
            BlockFor = blockFor;
        }

        public ConsistencyLevel ConsistencyLevel { get; private set; }

        public int Received { get; private set; }

        public int BlockFor { get; private set; }
    }
}