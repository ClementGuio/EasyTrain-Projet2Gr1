#pragma checksum "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "205c48a9ed4fae1ff6be95de0ddce89bf8d68b1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gestionnaire_SupprimerGestionnaire), @"mvc.1.0.view", @"/Views/Gestionnaire/SupprimerGestionnaire.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"205c48a9ed4fae1ff6be95de0ddce89bf8d68b1e", @"/Views/Gestionnaire/SupprimerGestionnaire.cshtml")]
    #nullable restore
    public class Views_Gestionnaire_SupprimerGestionnaire : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EasyTrain_P2Gr1.Models.Gestionnaire>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
  
    Layout = "_LayoutGestionnaire";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.LabelFor(c => c.Nom));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.DisplayFor(c => c.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n");
#nullable restore
#line 13 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.LabelFor(c => c.Prenom));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.DisplayFor(c => c.Prenom));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n");
#nullable restore
#line 16 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.LabelFor(c => c.DateNaissance));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.DisplayFor(c => c.DateNaissance));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n");
#nullable restore
#line 19 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.LabelFor(c => c.AdresseMail));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.DisplayFor(c => c.AdresseMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n");
#nullable restore
#line 22 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.LabelFor(c => c.MotDePasse));

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.DisplayFor(c => c.MotDePasse));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n");
#nullable restore
#line 25 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.LabelFor(c => c.DateCreationCompte));

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
Write(Html.DisplayFor(c => c.DateCreationCompte));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n    <input type=\"submit\" value=\"Confirmer la supression\" />\n");
#nullable restore
#line 29 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Gestionnaire/SupprimerGestionnaire.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EasyTrain_P2Gr1.Models.Gestionnaire> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591