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
using System.Collections.Generic;

namespace cqlplus.StatementReader
{
    public class ConsoleInput : IStatementReader
    {
        private readonly string _hostname;

        public ConsoleInput(string hostname)
        {
            _hostname = hostname;
        }

        public IEnumerable<string> Read()
        {
            while (true)
            {
                Console.Write("{0}> ", _hostname);
                var line = Console.ReadLine();
                yield return line;
            }

// ReSharper disable FunctionNeverReturns
        }

// ReSharper restore FunctionNeverReturns
    }
}