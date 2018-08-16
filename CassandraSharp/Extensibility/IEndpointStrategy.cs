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

namespace CassandraSharp.Extensibility
{
    using System.Net;
    using System.Numerics;

    /// <summary>
    ///     IEndpointStrategy helps choosing a server to connect to Implementation must be thread safe
    /// </summary>
    public interface IEndpointStrategy
    {
        IPAddress Pick(BigInteger? token = null);

        void Ban(IPAddress endpoint);

        void Permit(IPAddress endpoint);

        void Update(NotificationKind kind, Peer peer);
    }
}