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

using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using CassandraSharp.Config;

namespace CassandraSharp
{
    public class SectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            // rename the root element - it must be named "CassandraSharpConfig"
            var xmlDoc = new XmlDocument();
            var xmlRootNode = xmlDoc.AppendChild(xmlDoc.CreateElement("CassandraSharpConfig"));
            xmlRootNode.InnerXml = section.InnerXml;

            foreach (XmlAttribute xmlAttr in section.Attributes)
            {
                var newXmlAttr = xmlDoc.CreateAttribute(xmlAttr.Name, xmlAttr.NamespaceURI);
                newXmlAttr.Value = xmlAttr.Value;

                xmlRootNode.Attributes.Append(newXmlAttr);
            }

            return ReadConfig(xmlDoc);
        }

        private static CassandraSharpConfig ReadConfig(XmlDocument xmlDoc)
        {
            var xmlSer = new XmlSerializer(typeof(CassandraSharpConfig));
            //MiniXmlSerializer xmlSer = new MiniXmlSerializer(typeof(CassandraSharpConfig));
            using (XmlReader xmlReader = new XmlNodeReader(xmlDoc))
            {
                return (CassandraSharpConfig)xmlSer.Deserialize(xmlReader);
            }
        }
    }
}