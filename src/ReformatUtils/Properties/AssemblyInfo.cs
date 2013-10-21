using System.Reflection;
using JetBrains.ActionManagement;
using JetBrains.Application.PluginSupport;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("Reformatting Utilities")]
[assembly:
    AssemblyDescription(
        "A resharper plugin that provides actions and shortcuts for reformatting based on scope (e.g. reformat method)")
]

[assembly: AssemblyCompany("Øystein Krog")]
[assembly: AssemblyProduct("ReformatUtils")]
[assembly: AssemblyCopyright("Copyright © Øystein Krog, 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.2.0.*")]
[assembly: AssemblyFileVersion("1.2.0.*")]

// The following information is displayed by ReSharper in the Plugins dialog

[assembly: PluginTitle("Reformatting Utilities")]
[assembly:
    PluginDescription(
        "A resharper plugin that provides actions and shortcuts for reformatting based on scope (e.g. reformat method)")
]
[assembly: PluginVendor("Øystein Krog")]