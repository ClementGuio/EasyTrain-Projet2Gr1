#pragma checksum "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22c575af4703df41a0e22e2c1096038871f808b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Connexion), @"mvc.1.0.view", @"/Views/Login/Connexion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22c575af4703df41a0e22e2c1096038871f808b5", @"/Views/Login/Connexion.cshtml")]
    #nullable restore
    public class Views_Login_Connexion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EasyTrain_P2Gr1.ViewModels.ClientViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
  
    Layout = "_LayoutVisiteur";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 6 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
 if (Model.Authentifie)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"messageDeconnecter\">\n        <h2>\n            Vous êtes déjà authentifié avec le login\n");
#nullable restore
#line 11 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
             if (Model.Utilisateur != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
           Write(Model.Utilisateur.Nom);

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
                                      
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </h2>\n        <br>\n        <br>\n        <h2>\n            ");
#nullable restore
#line 19 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
       Write(Html.ActionLink("Voulez-vous vous déconnecter ?", "Deconnexion"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </h2>\n    </div>\n");
#nullable restore
#line 22 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"fieldsetModifier\">\n\n            <fieldset>\n                <legend><h2>Se connecter</h2></legend>\n                <div class=\"tableModifier\">\n                    <table>\n                        <tr>\n                            <td>");
#nullable restore
#line 34 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
                           Write(Html.LabelFor(m => m.Utilisateur.AdresseMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 35 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
                           Write(Html.TextBoxFor(m => m.Utilisateur.AdresseMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        </tr>\n                        <tr>\n                            <td>");
#nullable restore
#line 38 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
                           Write(Html.LabelFor(m => m.Utilisateur.MotDePasse));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 39 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
                           Write(Html.PasswordFor(m => m.Utilisateur.MotDePasse));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                        </tr>
                    </table>
                </div>

                <div class=""btnSeConnecter"">

                    <input type=""submit"" value=""Se connecter"" />
                </div>

                <br />
                ");
#nullable restore
#line 50 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
           Write(Html.ActionLink("Créer un compte client", "CreerClient","Client"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n            </fieldset>\n        </div>\n");
#nullable restore
#line 54 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Login/Connexion.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EasyTrain_P2Gr1.ViewModels.ClientViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
