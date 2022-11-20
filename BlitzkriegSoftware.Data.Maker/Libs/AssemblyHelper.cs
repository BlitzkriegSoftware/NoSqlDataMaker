using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlitzkriegSoftware.Data.Maker.Libs
{
    /// <summary>
    /// Assembly Helper
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// Make a version string from AssemblyInfo
        /// </summary>
        /// <returns>formatted string</returns>
        public static string? GetVersion()
        {
            return Assembly.GetExecutingAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        }

        /// <summary>
        /// Gets title from assembly info
        /// </summary>
        /// <returns>title</returns>
        public static string? GetTitle()
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName;
        }

        /// <summary>
        /// Gets the name of the EXE running
        /// </summary>
        /// <returns>String of name</returns>
        public static string GetExeName()
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileName;
        }

        /// <summary>
        /// Get CopyRight
        /// </summary>
        /// <returns></returns>
        public static string? GetCopyright()
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).LegalCopyright;
        }
    }

}
