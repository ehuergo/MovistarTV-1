// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using AlphaCentaury.Licensing.Data.Serialization;
using AlphaCentaury.Licensing.Data.Ui;
using AlphaCentaury.Tools.SourceCodeMaintenance.Licensing.VisualStudio;
using IpTviewr.UiServices.Common.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlphaCentaury.Tools.SourceCodeMaintenance.Helpers;
using AlphaCentaury.Tools.SourceCodeMaintenance.Properties;
using IpTviewr.Common;

namespace AlphaCentaury.Tools.SourceCodeMaintenance.Licensing
{
    public partial class LicensingFormDocumentView : CommonBaseForm
    {
        private readonly List<(LicensingDataNode Licensing, TreeNode Node)> _licensingNodes;
        private DetailsModeEnum _detailsMode;
        private LicensingData _currentLicensingData;
        private VsSolution _currentSolutionField;
        private bool _formLoaded;
        private readonly Helpers.AsyncHelper _asyncHelper;

        protected enum DetailsModeEnum
        {
            None,
            LicensingDataCollection,
            LicensingData,
            VsProject
        } // DetailsModeEnum

        public LicensingFormDocumentView()
        {
            InitializeComponent();

            SolutionImages.InitializeImageListSmall(imageListSolutionTreeSmall);
            SolutionImages.InitializeImageListMedium(imageListSolutionTreeMedium);
            LicensingImageList = new ImageList(components);
            LicensingUiImages.GetImageListMedium(LicensingImageList);

            SolutionImages = new SolutionImages(imageListSolutionTreeSmall.Images);
            LicensingVsUi = new LicensingVsUi(SolutionImages);
            LicensingImages = new LicensingUiImages(LicensingImageList.Images);
            LicensingUi = new LicensingDataUi(LicensingImages);

            _asyncHelper = new AsyncHelper(this, toolStripMain, cancelStripButton);
            _licensingNodes = new List<(LicensingDataNode Licensing, TreeNode node)>();
        } // constructor

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                _asyncHelper?.Dispose();
            } // if

            base.Dispose(disposing);
        } // Dispose

        private protected SolutionImages SolutionImages { get; }
        private protected LicensingVsUi LicensingVsUi { get; }
        protected LicensingUiImages LicensingImages { get; }
        protected ImageList LicensingImageList { get; }
        protected LicensingDataUi LicensingUi { get; }
        private protected IReadOnlyList<(LicensingDataNode Licensing, TreeNode node)> LicensingNodes => _licensingNodes;

        protected VsSolution CurrentSolution
        {
            get => _currentSolutionField;
            set
            {
                if ((value != null) && (value == _currentSolutionField)) return;

                treeViewSolution.Nodes.Clear();
                var root = (value == null) switch
                {
                    true => new TreeNode(LicensingResources.NoSolutionSelected, SolutionImages.VsSolution, SolutionImages.VsSolution),
                    false => LicensingVsUi.GetSolutionTree(value)
                };

                treeViewSolution.Nodes.Add(root);
                _licensingNodes.Clear();
                ExtractLicensingData(root);

                checkStripButton.Enabled = (value != null);
                createStripButton.Enabled = (value != null);
                updateStripButton.Enabled = (value != null);
                licensingWriteStripButton.Enabled = (value != null);

                _currentSolutionField = value;
            } // set
        } // CurrentSolution

        protected LicensingData CurrentLicensingData
        {
            get => _currentLicensingData;
            set
            {
                if (value == _currentLicensingData)
                {
                    if (_formLoaded) return;
                } // if

                treeViewLicensingData.Nodes.Clear();

                var root = (value == null) switch
                {
                    true => new TreeNode(LicensingResources.NoLicensingSelected, LicensingImages.LicensingData, LicensingImages.LicensingData),
                    false => LicensingUi.DataToTree("", value)
                };

                treeViewLicensingData.Nodes.Add(root);
                _currentLicensingData = value;
            } // set
        } // CurrentLicensingData

        protected string SelectedLicensingDataName
        {
            get => treeViewLicensingData.Nodes[0].Text;
            set => treeViewLicensingData.Nodes[0].Text = value;
        } // SelectedLicensingDataName

        protected DetailsModeEnum DetailsMode
        {
            get => _detailsMode;
            set
            {
                _detailsMode = value;
                switch (value)
                {
                    case DetailsModeEnum.LicensingData:
                    case DetailsModeEnum.LicensingDataCollection:
                    case DetailsModeEnum.VsProject:
                        treeViewDetails.Enabled = true;
                        break;
                    default:
                        treeViewDetails.Nodes.Clear();
                        treeViewDetails.ImageList = null;
                        treeViewDetails.Enabled = false;
                        break;
                } // switch

                textBoxDetails.Text = null;
                textBoxDetails.Enabled = false;
            } // set
        } // DetailsMode

        #region Overrides of CommonBaseForm

        protected override void OnLoad(EventArgs e)
        {
            treeViewSolution.ImageList = imageListSolutionTreeMedium;
            CurrentSolution = null;

            treeViewLicensingData.ImageList = LicensingImageList;
            CurrentLicensingData = null;

            DetailsMode = DetailsModeEnum.None;
            _formLoaded = true;

            base.OnLoad(e);
        } // OnLoad

        #endregion

        #region Main ToolStrip event handlers

        protected virtual void openStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // openStripSplitButton_ButtonClick

        protected virtual void openSolutionFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // openSolutionFolderToolStripMenuItem_Click

        protected virtual void openSolutionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // openSolutionFileToolStripMenuItem_Click

        protected virtual void openLicensingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // openLicensingDataToolStripMenuItem_Click

        protected virtual void createStripButton_Click(object sender, EventArgs e)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // createStripButton_Click

        protected virtual void checkStripButton_Click(object sender, EventArgs e)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // checkStripButton_Click

        protected virtual void updateStripButton_Click(object sender, EventArgs e)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // updateStripButton_Click

        protected virtual void licensingWriteStripButton_Click(object sender, EventArgs e)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // licensingWriteStripButton_Click

        protected virtual void licensingOptionsStripButton_Click(object sender, EventArgs e)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // licensingOptionsStripButton_Click

        #endregion

        #region Solution tree event handlers

        protected virtual void treeViewSolution_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Tag)
            {
                case VsSolution solution:
                    SafeCall(OnVsSolutionSelected, solution);
                    break;
                case VsProject project:
                    SafeCall(OnVsProjectSelected, project);
                    break;
                case LicensingDataNode file:
                    SafeCall(OnLicensingNodeSelected, file);
                    break;
                default:
                    DetailsMode = DetailsModeEnum.None;
                    break;
            } // switch
        } // treeViewSolution_AfterSelect

        protected virtual void treeViewSolution_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageIndex != SolutionImages.FolderOpen) return;

            e.Node.ImageIndex = SolutionImages.Folder;
            e.Node.SelectedImageIndex = SolutionImages.Folder;
        } // treeViewSolution_BeforeCollapse

        protected virtual void treeViewSolution_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageIndex != SolutionImages.Folder) return;

            e.Node.ImageIndex = SolutionImages.FolderOpen;
            e.Node.SelectedImageIndex = SolutionImages.FolderOpen;
        } // treeViewSolution_BeforeExpand

        #endregion

        #region Details tree event handlers

        private void treeViewDetails_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (DetailsMode)
            {
                case DetailsModeEnum.LicensingDataCollection:
                    if (e.Node.Tag is LicensingDataNode node)
                    {
                        SafeCall(OnDetailsLicensingNodeSelected, node);
                    }
                    else
                    {
                        textBoxDetails.Text = null;
                        textBoxDetails.Enabled = false;
                    } // if-else
                    break;
                default:
                    return;
            } // switch
        } // treeViewDetails_AfterSelect

        #endregion

        #region Solution

        protected async void LoadSolutionFolderAsync(string path)
        {
            treeViewSolution.Nodes.Clear();
            DetailsMode = DetailsModeEnum.None;
            treeViewSolution.Nodes.Add(new TreeNode(LicensingResources.SolutionLoading, SolutionImages.VsSolution, SolutionImages.VsSolution));

            try
            {
                _asyncHelper.BeginAsyncOperation();
                var solution = await VsSolution.FromFolderAsync(path, LicensingMaintenance.ProjectReaders, _asyncHelper.GetCancellationToken());
                _asyncHelper.EndAsyncOperation();
                CurrentSolution = solution;
            }
            catch (OperationCanceledException e)
            {
                _asyncHelper.EndAsyncOperation();
                CurrentSolution = null;
                MessageBox.Show(this, e.Message, LicensingResources.SolutionLoadCancelCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                _asyncHelper.EndAsyncOperation();
                BaseProgram.HandleException(this, e.Message, e);
                CurrentSolution = null;
            } // try-catch
        } // LoadSolutionFolder

        private void ExtractLicensingData(TreeNode treeNode)
        {
            if (treeNode.Tag is LicensingDataNode licensing)
            {
                _licensingNodes.Add((licensing, treeNode));
            } // if

            if (treeNode.Nodes.Count == 0) return;

            foreach (var node in treeNode.Nodes.Cast<TreeNode>())
            {
                ExtractLicensingData(node);
            } // foreach node
        } // ExtractLicensingData

        #endregion

        #region OnSelected event handlers

        protected virtual void OnVsSolutionSelected(VsSolution solution)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // OnVsSolutionSelected


        protected virtual void OnVsProjectSelected(VsProject vsProject)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // OnVsProjectSelected

        private protected virtual void OnLicensingNodeSelected(LicensingDataNode node)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // OnLicensingNodeSelected

        private protected virtual void OnDetailsLicensingNodeSelected(LicensingDataNode node)
        {
            // must be overriden in descendant
            throw new NotSupportedException();
        } // OnDetailsLicensingNodeSelected

        #endregion

        protected async void ExecuteAsync(TextBoxOutputWriter writer, Func<CancellationToken, Task> asyncAction)
        {
            if (CurrentSolution == null) return;

            try
            {
                tabControlSolution.SelectedTab = tabPageOutput;
                writer.Clear();
                writer.Start();
                _asyncHelper.BeginAsyncOperation();

                await asyncAction(_asyncHelper.GetCancellationToken());
            }
            catch (OperationCanceledException)
            {
                // ignore
            } // catch
            catch (Exception ex)
            {
                writer.WriteException(ex);
            } // try-catch

            _asyncHelper.EndAsyncOperation();
            writer.Stop();
        } // ExecuteAsync

    } // class LicensingFormDocumentView
} // namespace

