using King.WebApi.Extension.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Diagnostics.CodeAnalysis;

namespace King.WebApi.Extension.Filter
{
    public class Routes : RouteAttribute, IApiDescriptionGroupNameProvider
    {
        public Routes([StringSyntax("Route")] string template) : base(template)
        {
        }

        public string? GroupName {get; set;}

        public Routes(Versions version,string name= "[action]") : base($"/{version}/[controller]/{name}")
        {
            GroupName=version.ToString();
        }
    }
}
