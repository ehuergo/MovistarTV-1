// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Etsi.Ts102034.v010501.XmlSerialization.Common
{
    [GeneratedCode("myxsdtool", "0.0.0.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType("TargetPackageType", Namespace = "urn:dvb:metadata:iptv:sdns:2012-1")]
    public class TargetPackage
    {
        [XmlElement("PackageType")]
        public MultilingualText[] PackageType;

        [XmlAttribute("PackageIDRef")]
        public string PackageIdRef;
    } // class TargetPackage
} // namespace
