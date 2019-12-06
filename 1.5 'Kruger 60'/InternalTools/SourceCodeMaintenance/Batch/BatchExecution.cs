// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlphaCentaury.Tools.SourceCodeMaintenance.Interfaces;
using AlphaCentaury.Tools.SourceCodeMaintenance.Properties;
using IpTviewr.Common.Serialization;
using JetBrains.Annotations;

namespace AlphaCentaury.Tools.SourceCodeMaintenance.Batch
{
    [Export(typeof(IMaintenanceTool))]
    [ExportMetadata("Name", "Batch execution")]
    [ExportMetadata("Guid", "{6F08CBEF-417F-49EA-8704-1686B1BBF5A9}")]
    [ExportMetadata("HasParameters", true)]
    [ExportMetadata("HasFileParameters", true)]
    [ExportMetadata("HasUi", true)]
    [ExportMetadata("CliName", "Batch")]
    public sealed class BatchExecution : IMaintenanceTool
    {
        #region Implementation of IMaintenanceTool

        public void Execute([NotNull] IReadOnlyList<string> arguments, [NotNull] IToolOutputWriter writer)
        {
            if (arguments.Count == 0)
            {
                ShowUsage(writer);
                return;
            } // if

            foreach (var argument in arguments)
            {
                writer.WriteLine("**********************************************************************");
                writer.WriteLine($"Executing '{argument}'");
                writer.WriteLine("**********************************************************************");
                writer.WriteLine();

                var batch = XmlSerialization.Deserialize<Serialization.Batch>(argument);
                if (batch == null) throw new System.IO.InvalidDataException();

                DoExecute(batch, writer);
            } // foreach
        } // Execute

        [PublicAPI]
        public void Execute(Serialization.Batch batch, IToolOutputWriter writer)
        {
            if (batch == null) throw new ArgumentNullException(nameof(batch));
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            DoExecute(batch, writer);
        } // Execute

        public void ShowUsage(IToolOutputWriter writer)
        {
            throw new NotImplementedException();
        } // ShowUsage

        public Form GetUi() => new BatchDialog();

        string IMaintenanceTool.SelectFileFilter => BatchResources.SelectFileFilter;

        #endregion

        public static Task ExecuteBatchAsync(Serialization.Batch batch, IToolOutputWriter writer)
        {
            if (batch == null) throw new ArgumentNullException(nameof(batch));
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            var task = new Task(() => DoExecute(batch, writer), TaskCreationOptions.LongRunning);
            task.Start();

            return task;
        } // ExecuteBatchAsync

        private static void DoExecute([NotNull] Serialization.Batch batch, [NotNull] IToolOutputWriter writer)
        {
            foreach (var line in batch.Lines)
            {
                var tool = Program.GetTool(line.Guid);
                if (tool == null)
                {
                    continue;
                } // if

                writer.WriteLine("======================================================================");
                writer.WriteLine($"Executing {tool.Metadata.CliName}");
                writer.IncreaseIndent();
                foreach (var argument in line.Arguments)
                {
                    writer.WriteLine(argument);
                } // foreach
                writer.DecreaseIndent();
                writer.WriteLine();

                try
                {
                    tool.Value.Execute(line.Arguments, writer);
                }
                catch (Exception e)
                {
                    writer.WriteException(e);
                } // catch

                writer.WriteLine($"Execution ended: {writer.ElapsedTime}");
                writer.WriteLine("======================================================================");
                writer.WriteLine();
            } // foreach
        } // DoExecute
    } // class BatchExecution
} // namespace
