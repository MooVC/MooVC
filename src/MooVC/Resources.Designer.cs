﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MooVC {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MooVC.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to You must provide the target collection..
        /// </summary>
        internal static string CollectionExtensionsGenericTargetRequired {
            get {
                return ResourceManager.GetString("CollectionExtensionsGenericTargetRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must provide a message..
        /// </summary>
        internal static string ExceptionEventArgsMessageRequired {
            get {
                return ResourceManager.GetString("ExceptionEventArgsMessageRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Processor {0} has encountered an issue that has prevented it from waiting for continuation to cease..
        /// </summary>
        internal static string ProcessorContinuationAbortFailure {
            get {
                return ResourceManager.GetString("ProcessorContinuationAbortFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Processor {0} has encountered an issue that has prevented it from continuing its processing..
        /// </summary>
        internal static string ProcessorContinuationInteruppted {
            get {
                return ResourceManager.GetString("ProcessorContinuationInteruppted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The process cannot be started because it is currently in a {0:g} state..
        /// </summary>
        internal static string StartOperationInvalidExceptionMessage {
            get {
                return ResourceManager.GetString("StartOperationInvalidExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The process cannot be stopped because it is currently in a {0:g} state..
        /// </summary>
        internal static string StopOperationInvalidExceptionMessage {
            get {
                return ResourceManager.GetString("StopOperationInvalidExceptionMessage", resourceCulture);
            }
        }
    }
}
