#pragma checksum "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db9e59a3c241459e691b820f6d4daea1d6c0a6f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Login), @"mvc.1.0.view", @"/Views/Login/Login.cshtml")]
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
#line 1 "/Users/frankie/Documents/Escalator/WebInterface/Views/_ViewImports.cshtml"
using WebInterface;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/frankie/Documents/Escalator/WebInterface/Views/_ViewImports.cshtml"
using WebInterface.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db9e59a3c241459e691b820f6d4daea1d6c0a6f2", @"/Views/Login/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f98756771a1af8feec21549a13b720d440d95425", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Escalator.Common.Models.UserCred>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
  
    ViewBag.Title = "Login";


#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<div style=\"text-align: center;\">\n");
#nullable restore
#line 9 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12\" style=\"margin: auto;\">\n        <div class=\"card\">\n            ");
#nullable restore
#line 13 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
       Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <h5 class=\"card-header\">Login</h5>\n            <div class=\"card-body\">\n                    <div class=\"form-group\">\n                        ");
#nullable restore
#line 17 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
                   Write(Html.LabelFor(model => model.Username, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 18 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
                   Write(Html.EditorFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 19 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </div>\n                    <div class=\"form-group\">\n                        ");
#nullable restore
#line 22 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
                   Write(Html.LabelFor(model => model.Password, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 23 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
                   Write(Html.EditorFor(model => model.Password, new {@type = "password"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("    \n                        ");
#nullable restore
#line 24 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"           
                    </div>
                    <div class=""row"">
                        <div class=""col-sm-6 pl-0"">
                            <button type=""submit"" value=""Submit"" class=""btn btn-space btn-primary"">Submit</button>
                        </div>
                    </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 34 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n<p>");
#nullable restore
#line 37 "/Users/frankie/Documents/Escalator/WebInterface/Views/Login/Login.cshtml"
Write(ViewBag.Result);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Escalator.Common.Models.UserCred> Html { get; private set; }
    }
}
#pragma warning restore 1591
