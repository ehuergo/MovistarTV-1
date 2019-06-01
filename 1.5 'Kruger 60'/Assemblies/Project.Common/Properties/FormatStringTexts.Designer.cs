// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

namespace IpTviewr.Common.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class FormatStringTexts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal FormatStringTexts() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IpTviewr.Common.Properties.FormatStringTexts", typeof(FormatStringTexts).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:d} {0:t} to {1:d} {1:t}.
        /// </summary>
        internal static string DateTimeFromToMinutesDifferentStartDifferentEnd {
            get {
                return ResourceManager.GetString("DateTimeFromToMinutesDifferentStartDifferentEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:d} {0:t} to {1:t}.
        /// </summary>
        internal static string DateTimeFromToMinutesDifferentStartEnd {
            get {
                return ResourceManager.GetString("DateTimeFromToMinutesDifferentStartEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:t} to {1:d} {1:t}.
        /// </summary>
        internal static string DateTimeFromToMinutesStartDifferentEnd {
            get {
                return ResourceManager.GetString("DateTimeFromToMinutesStartDifferentEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:t} to {1:t}.
        /// </summary>
        internal static string DateTimeFromToMinutesStartEnd {
            get {
                return ResourceManager.GetString("DateTimeFromToMinutesStartEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:N0} minutes.
        /// </summary>
        internal static string TimeSpanTotalMinutesBasic {
            get {
                return ResourceManager.GetString("TimeSpanTotalMinutesBasic", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:N0}m.
        /// </summary>
        internal static string TimeSpanTotalMinutesCompact {
            get {
                return ResourceManager.GetString("TimeSpanTotalMinutesCompact", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {2:N0}d {1:N0}h {0:N0}m.
        /// </summary>
        internal static string TimeSpanTotalMinutesCompactDays {
            get {
                return ResourceManager.GetString("TimeSpanTotalMinutesCompactDays", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {1:N0}h {0:N0}m.
        /// </summary>
        internal static string TimeSpanTotalMinutesCompactHours {
            get {
                return ResourceManager.GetString("TimeSpanTotalMinutesCompactHours", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:N0} minutes.
        /// </summary>
        internal static string TimeSpanTotalMinutesExtended {
            get {
                return ResourceManager.GetString("TimeSpanTotalMinutesExtended", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {2:N0} days, {1:N0} hours, {0:N0} minutes.
        /// </summary>
        internal static string TimeSpanTotalMinutesExtendedDays {
            get {
                return ResourceManager.GetString("TimeSpanTotalMinutesExtendedDays", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {1:N0} hours, {0:N0} minutes.
        /// </summary>
        internal static string TimeSpanTotalMinutesExtendedHours {
            get {
                return ResourceManager.GetString("TimeSpanTotalMinutesExtendedHours", resourceCulture);
            }
        }
    }
}
