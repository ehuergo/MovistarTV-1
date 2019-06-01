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
using System.Windows.Forms;

namespace AlphaCentaury.Winforms.MsgBoxEx
{
    public class MsgBoxExContents
    {
        public MsgBoxExContents()
        {
            CustomCancelButton = MsgBoxExButton.None;
        } // constructor

        public MsgBoxExContents(Exception ex) : this()
        {
            Exception = ex;
            Buttons = MsgBoxExButtons.OK;
        } // constructor

        public MsgBoxExContents(string text) : this()
        {
            Text = text;
            Severity = MsgBoxSeverity.None;
        } // constructor

        public MsgBoxExContents(string text, string caption) : this(text)
        {
            Caption = caption;
        } // constructor

        public MsgBoxExContents(string text, string caption, MsgBoxExButtons buttons) : this(text, caption)
        {
            Buttons = buttons;
        } // constructor

        public MsgBoxExContents(string text, string caption, MsgBoxExButtons buttons, MsgBoxSeverity severity) : this(text, caption, buttons)
        {
            Severity = severity;
        } // constructor

        public MsgBoxExContents(string text, string caption, MsgBoxExButtons buttons, MsgBoxSeverity severity, MsgBoxExButton defaultButton) : this(text, caption, buttons, severity)
        {
            DefaultButton = defaultButton;
        } // constructor

        public MsgBoxExContents(string text, string caption, MsgBoxExButtons buttons, MsgBoxSeverity severity, MsgBoxExButton defaultButton, string[] customButtons, DialogResult[] customResults, MsgBoxExButton acceptButton = MsgBoxExButton.None, MsgBoxExButton cancelButton = MsgBoxExButton.None) : this(text, caption, MsgBoxExButtons.Custom, severity, defaultButton)
        {
            CustomButtons = customButtons;
            CustomResults = customResults;
            CustomAcceptButton = acceptButton;
            CustomCancelButton = cancelButton;
        } // constructor

        public IWin32Window Owner
        {
            get;
            internal set;
        } // Owner

        public string Caption
        {
            get;
            set;
        } // Caption

        public string Text
        {
            get;
            set;
        } // Text

        public string AdditionalInformation
        {
            get;
            set;
        } // AdditionalInformation

        public Exception Exception
        {
            get;
            set;
        } // Exception

        public MsgBoxSeverity Severity
        {
            get;
            set;
        } // Severity

        public MsgBoxExButtons Buttons
        {
            get;
            set;
        } // Buttons

        public MsgBoxExButton DefaultButton
        {
            get;
            set;
        } // DefaultButton

        public string[] CustomButtons
        {
            get;
            set;
        } // CustomButtons

        public DialogResult[] CustomResults
        {
            get;
            set;
        } // CustomResults

        public MsgBoxExButton CustomAcceptButton
        {
            get;
            set;
        } // CustomAcceptButton

        public MsgBoxExButton CustomCancelButton
        {
            get;
            set;
        } // CustomCancelButton

        public int MaxTextLines
        {
            get;
            set;
        } // MaxTextLines

        public int MinTextLinesWithException
        {
            get;
            set;
        } // MinTextLinesWithException

        public int MaxExceptionLines
        {
            get;
            set;
        } // MaxExceptionLines

        public int MaxInnerExceptionLines
        {
            get;
            set;
        } // MaxInnerExceptionLines
    } // class MsgBoxExContents
} // namespace
