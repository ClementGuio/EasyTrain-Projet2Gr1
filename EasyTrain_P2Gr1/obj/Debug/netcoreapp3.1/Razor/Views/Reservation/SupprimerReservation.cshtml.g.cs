#pragma checksum "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Reservation/SupprimerReservation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2742d78967292a1771c8a268b4b97eeadb5244a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservation_SupprimerReservation), @"mvc.1.0.view", @"/Views/Reservation/SupprimerReservation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2742d78967292a1771c8a268b4b97eeadb5244a8", @"/Views/Reservation/SupprimerReservation.cshtml")]
    #nullable restore
    public class Views_Reservation_SupprimerReservation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EasyTrain_P2Gr1.ViewModels.ReservationViewModel>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Reservation/SupprimerReservation.cshtml"
  
    Layout = "_LayoutGestionnaire";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2742d78967292a1771c8a268b4b97eeadb5244a83075", async() => {
                WriteLiteral("\n    <meta name=\"viewport\" content=\"width=device-width\" />\n    <title>SupprimerReservation</title>\n");
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2742d78967292a1771c8a268b4b97eeadb5244a84127", async() => {
                WriteLiteral("\n");
#nullable restore
#line 17 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Reservation/SupprimerReservation.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <fieldset>\n            <legend>Supprimer une Réservation : </legend>\n            \n            <br />\n            ");
#nullable restore
#line 23 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Reservation/SupprimerReservation.cshtml"
       Write(Html.LabelFor(m => m.Reservation.CoursProgramme.DateDebut));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            ");
#nullable restore
#line 24 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Reservation/SupprimerReservation.cshtml"
       Write(Html.DisplayFor(m => m.Reservation.CoursProgramme.DateDebut));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            <br />\n            ");
#nullable restore
#line 26 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Reservation/SupprimerReservation.cshtml"
       Write(Html.HiddenFor(m => m.SelectCoursProgrammeId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            ");
#nullable restore
#line 27 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Reservation/SupprimerReservation.cshtml"
       Write(Html.HiddenFor(m => m.Reservation.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            <input type=\"submit\" value=\"Supprimer\" />\n        </fieldset>\n");
#nullable restore
#line 30 "/Users/loicsunve/Downloads/EasyTrain_P2Gr1/EasyTrain_P2Gr1/Views/Reservation/SupprimerReservation.cshtml"
    }

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\n</html>\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EasyTrain_P2Gr1.ViewModels.ReservationViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591