// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using IpTviewr.Common;
using IpTviewr.Common.Serialization;
/*
using IpTviewr.Services.EPG;
using IpTviewr.Services.EpgDiscovery;
using IpTviewr.Services.EPG.TvAnytime;
using IpTviewr.Services.SqlServerCE;
using IpTviewr.UiServices.EPG;
*/
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace IpTviewr.Internal.Tools.ConsoleExperiments
{
    class Program
    {
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Experiment experiment;

            //experiment = new CachedLogos();
            //experiment = new WindowsIconTest();
            //experiment = new Find();
            //experiment = new ExceptionMsgBoxExperiment();
            //experiment = new PlayingWithLogos();
            experiment = new ReorganizeLogos();

            return experiment.Execute(args);
        } // Main
    } // class Program
} // namespace
