#pragma checksum "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\ManageRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0af1f99e0f38e4bfbae568a3d25c8c2f940edbd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ManageRole), @"mvc.1.0.view", @"/Views/Admin/ManageRole.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0af1f99e0f38e4bfbae568a3d25c8c2f940edbd0", @"/Views/Admin/ManageRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e247e83530e33e258fab4226407e45bf0c04095", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ManageRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ManageRole>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<section class=\"mainAbout\">\r\n    <div class=\"container card my-4\">\r\n        <h2 class=\"md my-2\">Manage Role</h2>\r\n");
#nullable restore
#line 6 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\ManageRole.cshtml"
         using (Html.BeginForm())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <table class=\"table\">\r\n                <tr>\r\n                    <th>");
#nullable restore
#line 10 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\ManageRole.cshtml"
                   Write(Html.LabelFor(m => m.UserList));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 11 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\ManageRole.cshtml"
                   Write(Html.DropDownListFor(m => m.UserID, new SelectList(Model.UserList, "Value", "Text"), "Select a User"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                </tr>\r\n                <tr>\r\n                    <td>");
#nullable restore
#line 14 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\ManageRole.cshtml"
                   Write(Html.LabelFor(m => m.RoleList));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 15 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\ManageRole.cshtml"
                   Write(Html.DropDownListFor(m => m.RoleList, new SelectList(Model.RoleList, "Value", "Text"), "Select a Role"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"2\"> \r\n                    <button type=\"submit\" class=\"btn btn-primary\">Assign Role</button>\r\n                    </td>\r\n                </tr>\r\n\r\n\r\n            </table>\r\n");
#nullable restore
#line 25 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\ManageRole.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ManageRole> Html { get; private set; }
    }
}
#pragma warning restore 1591