#pragma checksum "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\SendEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bad6c551c0f399627bb7530be03fe695e229cddc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_SendEmail), @"mvc.1.0.view", @"/Views/Admin/SendEmail.cshtml")]
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
#line 3 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\_ViewImports.cshtml"
using Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bad6c551c0f399627bb7530be03fe695e229cddc", @"/Views/Admin/SendEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e247e83530e33e258fab4226407e45bf0c04095", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_SendEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SendEmail>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\SendEmail.cshtml"
  
    ViewBag.Title = "Send Email ";

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"mainAbout my-5\">\r\n    <div class=\"container\">\r\n        <div class=\"showcase-form card\">\r\n            <h2>Send Email</h2>\r\n            <h3>");
#nullable restore
#line 9 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\SendEmail.cshtml"
           Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            \r\n");
#nullable restore
#line 11 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\SendEmail.cshtml"
             using(Html.BeginForm("SendEmail", "Admin", FormMethod.Post, new {enctype = "multipart/form-data" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <table>\r\n                    <tr>\r\n                        <td>\r\n                            To:\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 18 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\SendEmail.cshtml"
                       Write(Html.TextBoxFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            Subject:\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 24 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\SendEmail.cshtml"
                       Write(Html.TextBoxFor(model => model.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            Body:\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 30 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\SendEmail.cshtml"
                       Write(Html.TextAreaFor(model => model.Message, new { rows = "15", cols="25" } ));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td colspan=\"2\"><input type=\"submit\" value=\"send\" /></td>\r\n                    </tr>\r\n                </table>\r\n");
#nullable restore
#line 36 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\SendEmail.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SendEmail> Html { get; private set; }
    }
}
#pragma warning restore 1591
