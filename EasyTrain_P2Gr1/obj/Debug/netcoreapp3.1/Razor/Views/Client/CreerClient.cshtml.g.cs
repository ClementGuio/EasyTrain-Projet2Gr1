#pragma checksum "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e229869b205d254b93c7e42ef3f2f734ecfb80ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_CreerClient), @"mvc.1.0.view", @"/Views/Client/CreerClient.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e229869b205d254b93c7e42ef3f2f734ecfb80ac", @"/Views/Client/CreerClient.cshtml")]
    #nullable restore
    public class Views_Client_CreerClient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EasyTrain_P2Gr1.ViewModels.InscriptionViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
  
    Layout = "_LayoutVisiteur";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
 if (TempData.ContainsKey("Message"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"message\">");
#nullable restore
#line 12 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                    Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 13 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\" style=\"height: 100vh; padding-top:7em\">\r\n\r\n");
#nullable restore
#line 17 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""fieldsetModifier"">
            <fieldset>
                <legend><h2>Inscription</h2></legend>

                <div class=""tableModifier"">
                    <table>
                        <tr>
                            <td>");
#nullable restore
#line 26 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.LabelFor(m => m.Prenom));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 27 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.TextBoxFor(m => m.Prenom, new { @class = "InputText"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 28 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.ValidationMessageFor(m => m.Prenom));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>");
#nullable restore
#line 31 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.LabelFor(m => m.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 32 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.TextBoxFor(m => m.Nom, new { @class = "InputText"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("  </td>\r\n                            <td>");
#nullable restore
#line 33 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.ValidationMessageFor(m => m.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>");
#nullable restore
#line 36 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.LabelFor(m => m.AdresseMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 37 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.TextBoxFor(m => m.AdresseMail, new { @class = "InputText"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 38 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.ValidationMessageFor(m => m.AdresseMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>");
#nullable restore
#line 41 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.LabelFor(m => m.DateNaissance));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 42 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.TextBoxFor(m => m.DateNaissance, new { @type="date" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 43 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.ValidationMessageFor(m => m.DateNaissance));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>");
#nullable restore
#line 46 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.LabelFor(m => m.MotDePasse));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 47 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.PasswordFor(m => m.MotDePasse, new { @class = "InputText"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 48 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.ValidationMessageFor(m => m.MotDePasse));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>");
#nullable restore
#line 51 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.LabelFor(m => m.VerifMotDePasse));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 52 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.PasswordFor(m => m.VerifMotDePasse, new { @class = "InputText"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 53 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
                           Write(Html.ValidationMessageFor(m => m.VerifMotDePasse));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        </tr>\r\n                    </table>\r\n                </div>\r\n                ");
#nullable restore
#line 57 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
           Write(Html.DisplayFor(m => m.DateAbonnement));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 58 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
           Write(Html.DisplayFor(m => m.AccesEscalade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 59 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
           Write(Html.DisplayFor(m => m.AccesPiscine));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 60 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
           Write(Html.DisplayFor(m => m.AccompagnementCoach));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 61 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
           Write(Html.DisplayFor(m => m.Mensualite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"btnCoachModifier\">\r\n                    <input type=\"submit\" value=\"Confirmer\" />\r\n                </div>\r\n            </fieldset>\r\n        </div>\r\n");
#nullable restore
#line 68 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Client/CreerClient.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EasyTrain_P2Gr1.ViewModels.InscriptionViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
