#pragma checksum "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c799c6bd82865ed8baa6fc69d5f8c3d9edda5c81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Detail), @"mvc.1.0.view", @"/Views/Admin/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c799c6bd82865ed8baa6fc69d5f8c3d9edda5c81", @"/Views/Admin/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e247e83530e33e258fab4226407e45bf0c04095", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<section class=\"mainAbout my-5\">\r\n    <div class=\"container\">\r\n        <div class=\"showcase-form card\">\r\n            <h2>View Student\'s\' Application </h2>\r\n            <div class=\"form-control\">\r\n                UserName : ");
#nullable restore
#line 6 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\Detail.cshtml"
                      Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-control\">\r\n                UserPhone: ");
#nullable restore
#line 9 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\Detail.cshtml"
                      Write(Model.UserPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-control\">\r\n                UserCourse: ");
#nullable restore
#line 12 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\Detail.cshtml"
                       Write(Model.UserCourse);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-control\">\r\n                UserGPA: ");
#nullable restore
#line 15 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\Detail.cshtml"
                    Write(Model.UserGPA);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-control\">\r\n                UserUni: ");
#nullable restore
#line 18 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\Detail.cshtml"
                    Write(Model.UserUni);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-control\">\r\n                UserCV: ");
#nullable restore
#line 21 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\Detail.cshtml"
                   Write(Model.UserCV);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-control\">\r\n                UserCV: ");
#nullable restore
#line 24 "C:\school\Tuesday Class\Assignment\assess2\project5 - Copy\Web\Web\Views\Admin\Detail.cshtml"
                   Write(Model.Regdate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591