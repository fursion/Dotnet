#pragma checksum "/Users/fursion/Dotnet/Dotnet/WebCore/WebCore/Views/Blog/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f89a19e9bda7cb3bb1709ed82e7a1e8d0e34fc1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebCore.Views.Blog.Views_Blog_Index), @"mvc.1.0.view", @"/Views/Blog/Index.cshtml")]
namespace WebCore.Views.Blog
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
#line 1 "/Users/fursion/Dotnet/Dotnet/WebCore/WebCore/Views/_ViewImports.cshtml"
using WebCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/fursion/Dotnet/Dotnet/WebCore/WebCore/Views/_ViewImports.cshtml"
using WebCore.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/fursion/Dotnet/Dotnet/WebCore/WebCore/Views/_ViewImports.cshtml"
using WebCore.Mouds;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f89a19e9bda7cb3bb1709ed82e7a1e8d0e34fc1a", @"/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f8ab107e337c180609a0325a3bb7618d05d7bff", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "/Users/fursion/Dotnet/Dotnet/WebCore/WebCore/Views/Blog/Index.cshtml"
  
    ViewData["title"] = "博客";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f89a19e9bda7cb3bb1709ed82e7a1e8d0e34fc1a3503", async() => {
                WriteLiteral("\n    <title>");
#nullable restore
#line 10 "/Users/fursion/Dotnet/Dotnet/WebCore/WebCore/Views/Blog/Index.cshtml"
      Write(ViewData["title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" -首页</title>\n    <link rel=\"stylesheet\" href=\"css/Blog/BlogCSS.css\">\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f89a19e9bda7cb3bb1709ed82e7a1e8d0e34fc1a4749", async() => {
                WriteLiteral(@"
    <div class=""blog-html-body"">
        <div class=""sidebar show-border-left"" id=""menu"">


        </div>
        <div class=""blog-html-body-content""><iframe class=""blog-html-body-html"" src=""https://baijiahao.baidu.com/s?id=1713280963348554499&wfr=spider&for=pc"" frameborder=""0""></iframe></div>
        <div class=""sidebar show-border-right"">
            <div class=""info-card fillet"">
                <img draggable=""false"" src=""https://gimg2.baidu.com/image_search/src=http%3A%2F%2F5b0988e595225.cdn.sohucs.com%2Fimages%2F20180520%2F0473e00bdfd2476fbe0c228a45a1652c.jpeg&refer=http%3A%2F%2F5b0988e595225.cdn.sohucs.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1636362999&t=082869fa01c02eab86b8eb8d446692e7"" class=""info-card-image"" />
                <div class=""info-card-textarea"">
                    <p>hello world!</p>
                </div>
            </div>
");
#nullable restore
#line 28 "/Users/fursion/Dotnet/Dotnet/WebCore/WebCore/Views/Blog/Index.cshtml"
              
                for (int i = 0; i < 5; i++)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <div class=""info-card fillet"">
                        <img draggable=""false"" src=""https://gimg2.baidu.com/image_search/src=http%3A%2F%2F5b0988e595225.cdn.sohucs.com%2Fimages%2F20180520%2F0473e00bdfd2476fbe0c228a45a1652c.jpeg&refer=http%3A%2F%2F5b0988e595225.cdn.sohucs.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1636362999&t=082869fa01c02eab86b8eb8d446692e7"" class=""info-card-image"" />
                        <div class=""info-card-textarea"">
                            <p>hello world!</p>
                            <p>");
#nullable restore
#line 35 "/Users/fursion/Dotnet/Dotnet/WebCore/WebCore/Views/Blog/Index.cshtml"
                          Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n                        </div>\n                    </div>\n");
#nullable restore
#line 38 "/Users/fursion/Dotnet/Dotnet/WebCore/WebCore/Views/Blog/Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\n\n\n    </div>\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
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
