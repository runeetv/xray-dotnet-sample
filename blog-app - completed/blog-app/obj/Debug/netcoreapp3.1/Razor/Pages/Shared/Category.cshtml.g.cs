#pragma checksum "C:\Official\Immersion Days NYC\New Content\X-Ray\xray-dotnet-sample\src\blog-app - completed\blog-app\Pages\Shared\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10fc7e0766cc693943399c3f5cd1973377c764ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(blog_app.Pages.Shared.Pages_Shared_Category), @"mvc.1.0.view", @"/Pages/Shared/Category.cshtml")]
namespace blog_app.Pages.Shared
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
#line 1 "C:\Official\Immersion Days NYC\New Content\X-Ray\xray-dotnet-sample\src\blog-app - completed\blog-app\Pages\_ViewImports.cshtml"
using blog_app;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Official\Immersion Days NYC\New Content\X-Ray\xray-dotnet-sample\src\blog-app - completed\blog-app\Pages\Shared\Category.cshtml"
using blog_app.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10fc7e0766cc693943399c3f5cd1973377c764ad", @"/Pages/Shared/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2a3dd5371d487dd65305fe196aa4698a0e65392", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BlogCategory>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<br />\r\nCategories\r\n<hr />\r\n");
#nullable restore
#line 9 "C:\Official\Immersion Days NYC\New Content\X-Ray\xray-dotnet-sample\src\blog-app - completed\blog-app\Pages\Shared\Category.cshtml"
 foreach (var category in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a href=\"#\">");
#nullable restore
#line 11 "C:\Official\Immersion Days NYC\New Content\X-Ray\xray-dotnet-sample\src\blog-app - completed\blog-app\Pages\Shared\Category.cshtml"
           Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 12 "C:\Official\Immersion Days NYC\New Content\X-Ray\xray-dotnet-sample\src\blog-app - completed\blog-app\Pages\Shared\Category.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<hr />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BlogCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
