using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Razor;

[assembly: AspMvcViewLocationFormat("~/Api/{1}{0}.cshtml")]
[assembly: AspMvcViewLocationFormat("~/Features/{1}/{0}.cshtml")]
[assembly: AspMvcViewLocationFormat("~/Features/Shared/{0}.cshtml")]
namespace Onion.Web
{
    /// <summary>
    /// Used to apply Features directorys (rather than separate Controller, Model
    /// and View directories).
    /// </summary>
    /// <remarks>
    /// See: https://scottsauber.com/2016/04/25/feature-folder-structure-in-asp-net-core/
    /// </remarks>
    public class FeatureLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Don't need anything here, but required by the interface
        }
        
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            // The old locations are /Views/{1}/{0}.cshtml and /Views/Shared/{0}.cshtml
            // where {1} is the controller and {0} is the name of the View
            
            // Replace /Views with /Features
            return new string[]
            {
                "/Api/{1}/{0}.cshtml",
                "/Features/{1}/{0}.cshtml",
                "/Features/Shared/{0}.cshtml"
            };
        }
    }
}