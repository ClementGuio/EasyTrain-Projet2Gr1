#pragma checksum "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51d5135ff27002cfbebbf367b08c54365fb7d8c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cours_SupprimerCours), @"mvc.1.0.view", @"/Views/Cours/SupprimerCours.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51d5135ff27002cfbebbf367b08c54365fb7d8c2", @"/Views/Cours/SupprimerCours.cshtml")]
    #nullable restore
    public class Views_Cours_SupprimerCours : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EasyTrain_P2Gr1.Models.Cours>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
  
    Layout = "_LayoutGestionnaire";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 11 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
Write(Html.LabelFor(m => m.Coach.Prenom));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
Write(Html.DisplayFor(m => m.Coach.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 14 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
Write(Html.LabelFor(m => m.Coach.Nom));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
Write(Html.DisplayFor(m => m.Coach.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 17 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
Write(Html.LabelFor(m => m.Titre));

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
Write(Html.DisplayFor(m => m.Titre));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 20 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
Write(Html.LabelFor(m => m.NbParticipants));

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
Write(Html.DisplayFor(m => m.NbParticipants));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <input type=\"submit\" value=\"Supprimer\">\r\n");
#nullable restore
#line 24 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Cours/SupprimerCours.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EasyTrain_P2Gr1.Models.Cours> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591