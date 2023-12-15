using King.WebApi.Extension.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Diagnostics.CodeAnalysis;

namespace King.WebApi.Extension.Filter
{
    public class RouteFilter : RouteAttribute, IApiDescriptionGroupNameProvider
    {
        public RouteFilter([StringSyntax("Route")] string template) : base(template)
        {
        }

        public string? GroupName { get; set; }

        public RouteFilter(Versions version, string name = "[action]") : base($"/{version}/[controller]/{name}")
        {
            GroupName = version.ToString();
        }
    }
}