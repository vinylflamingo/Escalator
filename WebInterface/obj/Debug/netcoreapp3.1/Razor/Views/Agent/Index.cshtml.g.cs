#pragma checksum "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\Agent\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd88a0ecbf9cd837be9ddc86fce640455719317b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agent_Index), @"mvc.1.0.view", @"/Views/Agent/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\_ViewImports.cshtml"
using WebInterface;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\_ViewImports.cshtml"
using WebInterface.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd88a0ecbf9cd837be9ddc86fce640455719317b", @"/Views/Agent/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f98756771a1af8feec21549a13b720d440d95425", @"/Views/_ViewImports.cshtml")]
    public class Views_Agent_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebInterface.Models.AgentsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\Agent\Index.cshtml"
  

    ViewData["Title"] = "Agents";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
    <div class=""card"">
        <h5 class=""card-header"">Agents</h5>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-striped table-bordered first"">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Username</th>
                            <th>Role</th>
                            <th>Email</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 22 "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\Agent\Index.cshtml"
                      
                        foreach (var item in Model.agents)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 26 "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\Agent\Index.cshtml"
                               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 27 "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\Agent\Index.cshtml"
                               Write(item.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 28 "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\Agent\Index.cshtml"
                               Write(item.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 29 "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\Agent\Index.cshtml"
                               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>           \r\n");
#nullable restore
#line 31 "C:\Users\francisco.costoya\Documents\Escalator\WebInterface\Views\Agent\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebInterface.Models.AgentsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
