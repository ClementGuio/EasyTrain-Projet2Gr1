#pragma checksum "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "156592b7a5122cc895d02d384cc63be23f58c63f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Abonnement_AfficherAbonnement), @"mvc.1.0.view", @"/Views/Abonnement/AfficherAbonnement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"156592b7a5122cc895d02d384cc63be23f58c63f", @"/Views/Abonnement/AfficherAbonnement.cshtml")]
    #nullable restore
    public class Views_Abonnement_AfficherAbonnement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EasyTrain_P2Gr1.ViewModels.AbonnementViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
  
    Layout = "_LayoutClient";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
 using (Html.BeginForm("ModifierAbonnement", "Abonnement", FormMethod.Post))
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container fieldsetFormulaire\">\n        <fieldset>\n            <legend><h2>Abonnement</h2></legend>\n            <div class=\"tableModifier\">\n                <table>\n                    <tr>\n                        <td>");
#nullable restore
#line 17 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.LabelFor(c => c.Abonnement.NbCours));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 18 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.TextBoxFor(c => c.Abonnement.NbCours, new { @placeholder = "Nb Cours", @type = "number", @min = 0, @max = 10 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td> x ");
#nullable restore
#line 19 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                          Write(Html.DisplayFor(c => c.TarifCours));

#line default
#line hidden
#nullable disable
            WriteLiteral(" euros</td>\n                    </tr>\n                    <tr>\n                        <td>");
#nullable restore
#line 22 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.LabelFor(c => c.Abonnement.AccesPiscine));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 23 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.CheckBoxFor(c => c.Abonnement.AccesPiscine));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 24 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.DisplayFor(c => c.TarifPiscine));

#line default
#line hidden
#nullable disable
            WriteLiteral(" euros</td>\n                    </tr>\n                    <tr>\n                        <td>");
#nullable restore
#line 27 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.LabelFor(c => c.Abonnement.AccesEscalade));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 28 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.CheckBoxFor(c => c.Abonnement.AccesEscalade));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 29 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.DisplayFor(c => c.TarifEscalade));

#line default
#line hidden
#nullable disable
            WriteLiteral(" euros</td>\n                    </tr>\n                    <tr>\n                        <td>");
#nullable restore
#line 32 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.LabelFor(c => c.Abonnement.AccompagnementCoach));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 33 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.CheckBoxFor(c => c.Abonnement.AccompagnementCoach));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 34 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.DisplayFor(c => c.TarifCoaching));

#line default
#line hidden
#nullable disable
            WriteLiteral(" euros</td>\n                    </tr>\n                    <tr>\n                        <td>");
#nullable restore
#line 37 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.LabelFor(a => a.Abonnement.Mensualite));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 38 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"
                       Write(Html.DisplayFor(a => a.Abonnement.Mensualite));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" euros</td>
                    </tr>
                    
                </table>
            </div>

            <div class=""btnCoachModifier"">
                <input type=""submit"" value=""Modifier mon abonnement"" />
            </div>
        </fieldset>
    </div>
");
#nullable restore
#line 49 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/AfficherAbonnement.cshtml"




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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EasyTrain_P2Gr1.ViewModels.AbonnementViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591