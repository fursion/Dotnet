#pragma checksum "C:\Users\Du\Documents\CSharp\WebServer\Views\DutyInfo\GetInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c832c476dbd0c9e748a3fd99a1062246e83847a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DutyInfo_GetInfo), @"mvc.1.0.view", @"/Views/DutyInfo/GetInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c832c476dbd0c9e748a3fd99a1062246e83847a2", @"/Views/DutyInfo/GetInfo.cshtml")]
    public class Views_DutyInfo_GetInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Du\Documents\CSharp\WebServer\Views\DutyInfo\GetInfo.cshtml"
  
    ViewData["Title"] = "IT";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>今日IT在班信息</h1>\r\n<title>");
#nullable restore
#line 8 "C:\Users\Du\Documents\CSharp\WebServer\Views\DutyInfo\GetInfo.cshtml"
  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" --info</title>\r\n<div>\r\n    <p>");
#nullable restore
#line 10 "C:\Users\Du\Documents\CSharp\WebServer\Views\DutyInfo\GetInfo.cshtml"
  Write(DateTime.Now.ToString("yyyyMMdd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n");
#nullable restore
#line 12 "C:\Users\Du\Documents\CSharp\WebServer\Views\DutyInfo\GetInfo.cshtml"
 for (int lin = 0; lin < ((List<string>)ViewData["TodayDuty"]).Count; lin++)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li>");
#nullable restore
#line 14 "C:\Users\Du\Documents\CSharp\WebServer\Views\DutyInfo\GetInfo.cshtml"
    Write(((List<string>)ViewData["TodayDuty"])[lin]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 15 "C:\Users\Du\Documents\CSharp\WebServer\Views\DutyInfo\GetInfo.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<dir>\r\n</dir>\r\n\r\n");
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