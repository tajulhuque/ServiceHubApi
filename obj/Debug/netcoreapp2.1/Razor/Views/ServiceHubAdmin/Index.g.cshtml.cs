#pragma checksum "c:\projects\ServiceHubApi\Views\ServiceHubAdmin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c332b7a92b86b8cf28d4aa526fac94be941a1a39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceHubAdmin_Index), @"mvc.1.0.view", @"/Views/ServiceHubAdmin/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ServiceHubAdmin/Index.cshtml", typeof(AspNetCore.Views_ServiceHubAdmin_Index))]
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
#line 1 "c:\projects\ServiceHubApi\Views\_ViewImports.cshtml"
using ServiceHubApi;

#line default
#line hidden
#line 2 "c:\projects\ServiceHubApi\Views\_ViewImports.cshtml"
using ServiceHubApi.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c332b7a92b86b8cf28d4aa526fac94be941a1a39", @"/Views/ServiceHubAdmin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45d9b83e09db8b91a57fb60f0b19c900121bb520", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceHubAdmin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ServiceHubApi.Data_Access.RetentionPolicy>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(63, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "c:\projects\ServiceHubApi\Views\ServiceHubAdmin\Index.cshtml"
  
    ViewData["Title"] = "Service Hub Admin";
    //IEnumerable<ServiceHubApi.Data_Access.RetentionPolicy> retentionPolicies = @Model;

#line default
#line hidden
            BeginContext(208, 166, true);
            WriteLiteral("\r\n\r\n <h3>Retention Policies</h3>\r\n\r\n\r\n<div>\r\n    <table class=\"table\">\r\n        <th>Description</th>\r\n        <th>Retention Time</th>\r\n        <th>For Severity</th>\r\n");
            EndContext();
#line 17 "c:\projects\ServiceHubApi\Views\ServiceHubAdmin\Index.cshtml"
     foreach (var rp in @Model)
    {

#line default
#line hidden
            BeginContext(414, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(463, 14, false);
#line 21 "c:\projects\ServiceHubApi\Views\ServiceHubAdmin\Index.cshtml"
           Write(rp.Description);

#line default
#line hidden
            EndContext();
            BeginContext(477, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(533, 21, false);
#line 24 "c:\projects\ServiceHubApi\Views\ServiceHubAdmin\Index.cshtml"
           Write(rp.RetentionTimeHours);

#line default
#line hidden
            EndContext();
            BeginContext(554, 61, true);
            WriteLiteral(" hours\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(616, 14, false);
#line 27 "c:\projects\ServiceHubApi\Views\ServiceHubAdmin\Index.cshtml"
           Write(rp.ForSeverity);

#line default
#line hidden
            EndContext();
            BeginContext(630, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 30 "c:\projects\ServiceHubApi\Views\ServiceHubAdmin\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(673, 72, true);
            WriteLiteral("    <tr>\r\n        <td colspan=3 style=\"text-align: left;\">\r\n            ");
            EndContext();
            BeginContext(746, 58, false);
#line 33 "c:\projects\ServiceHubApi\Views\ServiceHubAdmin\Index.cshtml"
       Write(Html.ActionLink("Create New", "Create", "ServiceHubAdmin"));

#line default
#line hidden
            EndContext();
            BeginContext(804, 67, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n    </table>\r\n\r\n    \r\n   \r\n</div>\r\n\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ServiceHubApi.Data_Access.RetentionPolicy>> Html { get; private set; }
    }
}
#pragma warning restore 1591
