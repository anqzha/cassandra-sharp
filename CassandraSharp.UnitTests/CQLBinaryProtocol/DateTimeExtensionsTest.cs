﻿// cassandra-sharp - high performance .NET driver for Apache Cassandra
// Copyright (c) 2011-2018 Pierre Chalamet
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

using System;
using CassandraSharp.Utils.Stream;
using NUnit.Framework;

namespace CassandraSharp.UnitTests.CQLBinaryProtocol
{
    [TestFixture]
    public class DateTimeExtensionsTest
    {
        [Test]
        public void TestConversion()
        {
            var dt = new DateTime(2013, 1, 16, 14, 20, 0);
            var ts = dt.ToTimestamp();

            Assert.AreEqual(ts, 1358346000000);

            var cdt = ts.ToDateTime();
            Assert.AreEqual(cdt, dt);
        }
    }
}