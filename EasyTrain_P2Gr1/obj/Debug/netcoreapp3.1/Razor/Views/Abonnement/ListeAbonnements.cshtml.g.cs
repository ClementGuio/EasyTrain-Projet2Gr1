#pragma checksum "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "891c6601d02b78bdfeedfc4e796b6b923c7749d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Abonnement_ListeAbonnements), @"mvc.1.0.view", @"/Views/Abonnement/ListeAbonnements.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"891c6601d02b78bdfeedfc4e796b6b923c7749d1", @"/Views/Abonnement/ListeAbonnements.cshtml")]
    #nullable restore
    public class Views_Abonnement_ListeAbonnements : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EasyTrain_P2Gr1.Models.Abonnement>>
    #nullable disable
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
  
    Layout = "_LayoutGestionnaire";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<<<<<<< HEAD\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "891c6601d02b78bdfeedfc4e796b6b923c7749d12924", async() => {
                WriteLiteral("\r\n    <meta charset=\"UTF-8\" />\r\n    <title>Liste des Cours</title>\r\n");
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n\r\n\r\n    <div class=\"container\">\r\n\r\n");
#nullable restore
#line 80 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
         if (TempData.ContainsKey("Message"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>");
#nullable restore
#line 82 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
            Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 83 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a href=\"creerabonnements\"> Ajouter </a>\r\n\r\n        <table class=\"tableauL\">\r\n            <tr>\r\n                <th>Id</th>\r\n                <th>Titre</th>\r\n                <th>Prix</th>\r\n                <th>Action</th>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 94 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
             foreach (EasyTrain_P2Gr1.Models.Abonnement abonnement in Model)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 98 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
                   Write(abonnement.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 99 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
                   Write(abonnement.Mensualite);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a class=\" btn btn-secondaire\"");
            BeginWriteAttribute("href", " href=\"", 1975, "\"", 2015, 2);
            WriteAttributeValue("", 1982, "modifierabonnement/", 1982, 19, true);
#nullable restore
#line 101 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
WriteAttributeValue("", 2001, abonnement.Id, 2001, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> modifier </a>\r\n                        <a class=\" btn btn-secondaire\"");
            BeginWriteAttribute("href", " href=\"", 2087, "\"", 2128, 2);
            WriteAttributeValue("", 2094, "supprimerabonnement/", 2094, 20, true);
#nullable restore
#line 102 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
WriteAttributeValue("", 2114, abonnement.Id, 2114, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> suprimer </a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 105 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Abonnement/ListeAbonnements.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EasyTrain_P2Gr1.Models.Abonnement>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
