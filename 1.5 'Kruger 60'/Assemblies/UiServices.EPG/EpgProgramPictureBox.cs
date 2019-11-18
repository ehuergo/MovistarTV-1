// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using IpTviewr.Services.EpgDiscovery;
using IpTviewr.UiServices.Common.Controls;
using System.Drawing;

namespace IpTviewr.UiServices.EPG
{
    internal class EpgProgramPictureBox: PictureBoxEx
    {
        public void LoadProgramImageAsync(EpgProgram epgProgram, bool portrait)
        {
            if ((epgProgram == null)) // || (!IpTvService.Current.EpgInfo.Capabilities.HasFlag(EpgProviderCapabilities.ProgramThumbnail)))
            {
                OnProgramImageLoaded(null, portrait);
            }
            else
            {
                OnProgramImageLoaded(null, portrait);
                // TODO: async load program image
            } // if-else
        } // LoadProgramImageAsync

        private void OnProgramImageLoaded(Image image, bool portrait)
        {
            if (image == null)
            {
                SetImage(portrait ? Properties.Resources.EpgNoProgramImageVertical : Properties.Resources.EpgNoProgramImage);
            }
            else
            {
                SetImage(image);
            } // if-else
        } // OnProgramImageLoaded
    } // class EpgProgramPictureBox
} // namespace
