#pragma checksum "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56a5ffac4e0460f87b01d1bd62624198397d58cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_New), @"mvc.1.0.view", @"/Views/Ticket/New.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56a5ffac4e0460f87b01d1bd62624198397d58cf", @"/Views/Ticket/New.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f98756771a1af8feec21549a13b720d440d95425", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_New : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Escalator.Common.Models.Ticket>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
  
    ViewBag.Title = "Create New Ticket";


#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Create New Ticket</h2>\n\n");
#nullable restore
#line 9 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\n        <h4>Ticket</h4>\n        <hr />\n        ");
#nullable restore
#line 14 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
   Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        ");
#nullable restore
#line 15 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
   Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 18 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
       Write(Html.LabelFor(model => model.OriginalAccount, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 20 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.EditorFor(model => model.OriginalAccount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 21 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.ValidationMessageFor(model => model.OriginalAccount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 26 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
       Write(Html.LabelFor(model => model.JurisdictionId, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 28 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.EditorFor(model => model.JurisdictionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 29 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.ValidationMessageFor(model => model.JurisdictionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 33 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
       Write(Html.LabelFor(model => model.DueBy, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 35 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.EditorFor(model => model.DueBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 36 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.ValidationMessageFor(model => model.DueBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 41 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
       Write(Html.LabelFor(model => model.PhoneNumber, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 43 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.EditorFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 44 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.ValidationMessageFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 49 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
       Write(Html.LabelFor(model => model.EmailAddress, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 51 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.EditorFor(model => model.EmailAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 52 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.ValidationMessageFor(model => model.EmailAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 57 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
       Write(Html.LabelFor(model => model.Details, new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 59 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.EditorFor(model => model.Details));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 60 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
           Write(Html.ValidationMessageFor(model => model.Details));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            <div class=\"col-md-offset-2 col-md-10\">\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\n            </div>\n        </div>\n\n\n\n\n\n    </div>\n");
#nullable restore
#line 75 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Escalator.Common.Models.Ticket> Html { get; private set; }
    }
}
#pragma warning restore 1591
