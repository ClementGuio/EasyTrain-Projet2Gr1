#pragma checksum "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Home/DevIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a14c17cc56d6293b214bcacaf865905d3e6071a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DevIndex), @"mvc.1.0.view", @"/Views/Home/DevIndex.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a14c17cc56d6293b214bcacaf865905d3e6071a4", @"/Views/Home/DevIndex.cshtml")]
    #nullable restore
    public class Views_Home_DevIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Home/DevIndex.cshtml"
  
    Layout = "_LayoutVisiteur";
    List<String> message = new List<String> { " \\o/ ","Youpi !!", "Un controller de vues partielles !!!!" };

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <main>
        
        <div>Bonjour la team! <br />
            <br />
            <strong>Pour vous connecter:</strong>
            <br />
            <ul>
                <li>
                    En tant que <b>Gestionnaire</b> : <br />
                    &nbsp;&nbsp;<b>AdresseMail</b> : stella.dubois@mail.fr<br />
                    &nbsp;&nbsp;<b>MotDePasse</b> : Fraise
                </li>
                <br />
                <li>
                    En tant que <b>Client</b> : <br />
                    &nbsp;&nbsp;<b>AdresseMail</b> : BONNER.Henri@gmail.com<br />
                    &nbsp;&nbsp;<b>MotDePasse</b> : Prune
                </li>
                <br />
                <li>
                    En tant que <b>Coach</b> : <br />
                    &nbsp;&nbsp;<b>AdresseMail</b> : bergermay@mail.fr<br />
                    &nbsp;&nbsp;<b>MotDePasse</b> : Poire
                </li>
            </ul>    
        </div>
        <br />
        ");
#nullable restore
#line 33 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Home/DevIndex.cshtml"
   Write(Html.Partial("TestPartialView",message));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
