#pragma checksum "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68458be0529fc31f3526475b4286aacdfcb46aab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agent_New), @"mvc.1.0.view", @"/Views/Agent/New.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68458be0529fc31f3526475b4286aacdfcb46aab", @"/Views/Agent/New.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f98756771a1af8feec21549a13b720d440d95425", @"/Views/_ViewImports.cshtml")]
    public class Views_Agent_New : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Escalator.Common.Models.Agent>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
  
    ViewBag.Title = "Create New Agent";

    var roles = new List<string>() {"admin", "manager"};



#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div style=\"text-align: center;\">\n");
#nullable restore
#line 11 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12\" style=\"margin: auto;\">\n        <div class=\"card\">\n            ");
#nullable restore
#line 15 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
       Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <h5 class=\"card-header\">New Agent</h5>\n\n            <div class=\"card-body\">\n                <div class=\"form-group\">\n                    ");
#nullable restore
#line 20 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.LabelFor(model => model.Username, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 21 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.EditorFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \n                    ");
#nullable restore
#line 22 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.ValidationMessageFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("           \n                </div>\n\n                <div class=\"form-group\">\n                    ");
#nullable restore
#line 26 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.LabelFor(model => model.Password, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 27 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.EditorFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \n                    ");
#nullable restore
#line 28 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.ValidationMessageFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("           \n                </div>\n\n                <div class=\"form-group\">\n                    ");
#nullable restore
#line 32 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.LabelFor(model => model.NeedsNewPassword, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 33 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.CheckBoxFor(model => model.NeedsNewPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \n                    ");
#nullable restore
#line 34 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.ValidationMessageFor(model => model.NeedsNewPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("           \n                </div>\n\n                \n\n                <div class=\"form-group\">\n                    ");
#nullable restore
#line 40 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.LabelFor(model => model.Email, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 41 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.EditorFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \n                    ");
#nullable restore
#line 42 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.ValidationMessageFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("           \n                </div>\n                \n                <div class=\"form-group\">\n                    ");
#nullable restore
#line 46 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.LabelFor(model => model.Role, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 47 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.DropDownListFor(model => model.Role, new SelectList(roles)));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \n                    ");
#nullable restore
#line 48 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
               Write(Html.ValidationMessageFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"           
                </div>               

                <div class=""row"">
                    <div class=""form-group"">
                        <div class=""col-md-offset-2 col-md-10"">
                            <input type=""submit"" value=""Save"" class=""btn btn-default"" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 61 "/Users/frankie/Documents/Escalator/WebInterface/Views/Agent/New.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Escalator.Common.Models.Agent> Html { get; private set; }
    }
}
#pragma warning restore 1591
