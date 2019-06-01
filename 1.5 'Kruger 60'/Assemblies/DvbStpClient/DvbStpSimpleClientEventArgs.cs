// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IpTviewr.DvbStp.Client
{
    public partial class DvbStpSimpleClient
    {
        public class SectionReceivedEventArgs : EventArgs
        {
            public int DatagramCount;
            public byte PayloadId;
            public byte SegmentIdNetworkHi;
            public byte SegmentIdNetworkLo;
            public byte SegmentVersion;
        } // class SectionReceivedEventArgs

        public class PayloadSectionReceivedEventArgs : EventArgs
        {
            public byte PayloadId;
            public int SegmentId;
            public byte SegmentVersion;
            public int SectionNumber;
            public int SectionCount;
            public int SectionsReceived;
        } // class PayloadSectionReceivedEventArgs

        public class DownloadRestartedEventArgs : EventArgs
        {
            public byte PayloadId;
            public int SegmentId;
            public byte OldVersion;
            public byte NewVersion;
            public int SectionCount;
        } // class DownloadRestartedEventArgs
    } // partial class DvbStpSimpleClient
} // namespace
