#pragma checksum "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca1764c8449e55dcc2b8a27a4328bd0fa6fd098b"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca1764c8449e55dcc2b8a27a4328bd0fa6fd098b", @"/Views/Ticket/New.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f98756771a1af8feec21549a13b720d440d95425", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_New : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebInterface.Models.TicketViewModel>
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
            WriteLiteral("\n<div style=\"display: grid; place-items: center;\">\n");
#nullable restore
#line 8 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card\" style=\"width: 70em;\">\n            ");
#nullable restore
#line 11 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
       Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            ");
#nullable restore
#line 12 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
       Write(Html.HiddenFor(model => model.ticket.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <h5 class=""card-header"">New Ticket</h5>
            <div class=""card-body"" style=""text-align: center;"">
                <div>
                    <div class=""row"" style=""display: grid; place-items: center; padding-top: 1em;""> 
                        ");
#nullable restore
#line 17 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.ticketType, "Type of Ticket", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 18 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.DropDownListFor(m => m.ticket.ticketType, new SelectList(Model.ticketTypes, "Id", "Type"), new {@style = "width:20em;"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 19 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.ticketType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </div>\n                    <div class=\"row\" style=\"display: grid; place-items: center; padding-top: 1em;\">\n                        ");
#nullable restore
#line 22 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.JurisdictionId, "Jurisdiction", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 23 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.DropDownListFor(m => m.ticket.JurisdictionId, new SelectList(Model.jurisdictions, "Id", "Name"), new {@style = "width:20em;"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("                      \n                        ");
#nullable restore
#line 24 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.JurisdictionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("           \n                    </div>\n                    <div class=\"row\" style=\"display: grid; place-items: center; padding-top: 1em;\">\n                        ");
#nullable restore
#line 27 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.DueBy, "Due Date", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 28 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.EditorFor(model => model.ticket.DueBy, new {htmlAttributes = new {@style = "width:20em;"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 29 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.DueBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </div>\n                    <div class=\"row\" style=\"display: grid; place-items: center; padding-top: 1em;\">\n                        ");
#nullable restore
#line 32 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.PhoneNumber,"Phone Number", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 33 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.EditorFor(model => model.ticket.PhoneNumber, new {htmlAttributes = new {@style = "width:20em;"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 34 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    \n                    </div>\n                    <div class=\"row\" style=\"display: grid; place-items: center; padding-top: 1em;\">\n                        ");
#nullable restore
#line 38 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.EmailAddress,"Email Address", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 39 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.EditorFor(model => model.ticket.EmailAddress, new {htmlAttributes = new {@style = "width:20em;"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 40 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.EmailAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    \n                    </div>\n                    <div class=\"row\" style=\"display: grid; place-items: center; padding-top: 1em;\">\n                        ");
#nullable restore
#line 44 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.OriginalAccount,"Original Account", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 45 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.EditorFor(model => model.ticket.OriginalAccount, new {htmlAttributes = new {@style = "width:20em;"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 46 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.OriginalAccount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </div>\n                    <div class=\"row\" style=\"display: grid; place-items: center; padding-top: 1em;\">\n                        ");
#nullable restore
#line 49 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.MoveToAccount,"Move To Account", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 50 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.EditorFor(model => model.ticket.MoveToAccount, new {htmlAttributes = new {@style = "width:20em;"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 51 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.MoveToAccount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </div>\n                    <div class=\"row\" style=\"display: grid; place-items: center; padding-top: 1em;\">\n                        ");
#nullable restore
#line 54 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.Invoices,"Invoices #'s", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 55 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.EditorFor(model => model.ticket.Invoices, new {htmlAttributes = new {@style = "width:20em;"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 56 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.Invoices));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </div>\n                    <div class=\"row\" style=\"display: grid; place-items: center; padding-top: 1em;\">\n                        ");
#nullable restore
#line 59 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.Details,"Details", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 60 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.TextAreaFor(model => model.ticket.Details, new {@style = "width:40em; height:20em"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 61 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.Details));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </div>\n                    <div class=\"row\" style=\"display: grid; place-items: center; padding-top: 1em;\">\n                        ");
#nullable restore
#line 64 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.LabelFor(model => model.ticket.WhoSubmitted,"Your Name", new { @class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 65 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.EditorFor(model => model.ticket.WhoSubmitted, new {htmlAttributes = new {@style = "width:20em;"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        ");
#nullable restore
#line 66 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
                   Write(Html.ValidationMessageFor(model => model.ticket.WhoSubmitted));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""row"" style=""display: grid; place-items: center; padding-top: 1em;"">
                    <input type=""submit"" value=""Save"" class=""btn btn-default"" />
                </div>
            </div>
        </div>
");
#nullable restore
#line 74 "/Users/frankie/Documents/Escalator/WebInterface/Views/Ticket/New.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebInterface.Models.TicketViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591