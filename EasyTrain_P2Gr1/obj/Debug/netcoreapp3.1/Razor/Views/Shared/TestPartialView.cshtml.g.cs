#pragma checksum "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Shared/TestPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1a1f1f71e965c9b1a40245d17405057e9f520d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_TestPartialView), @"mvc.1.0.view", @"/Views/Shared/TestPartialView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1a1f1f71e965c9b1a40245d17405057e9f520d4", @"/Views/Shared/TestPartialView.cshtml")]
    #nullable restore
    public class Views_Shared_TestPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<String>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Shared/TestPartialView.cshtml"
 foreach (String str in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>");
#nullable restore
#line 9 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Shared/TestPartialView.cshtml"
     Write(str);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 10 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Shared/TestPartialView.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<String>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591