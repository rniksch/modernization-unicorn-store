#pragma checksum "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8ff87561e1ce6e1e6b4c098d35c3fb097f9f971"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_StoreManager_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/StoreManager/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/StoreManager/Edit.cshtml", typeof(AspNetCore.Areas_Admin_Views_StoreManager_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8ff87561e1ce6e1e6b4c098d35c3fb097f9f971", @"/Areas/Admin/Views/StoreManager/Edit.cshtml")]
    public class Areas_Admin_Views_StoreManager_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UnicornStore.Models.Album>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
  
    ViewBag.Title = "Edit";

#line default
#line hidden
            BeginContext(67, 16, true);
            WriteLiteral("\n<h2>Edit</h2>\n\n");
            EndContext();
#line 9 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(116, 23, false);
#line 11 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(141, 80, true);
            WriteLiteral("    <div class=\"form-horizontal\">\n        <h4>Album</h4>\n        <hr />\n        ");
            EndContext();
            BeginContext(222, 28, false);
#line 16 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
   Write(Html.ValidationSummary(true));

#line default
#line hidden
            EndContext();
            BeginContext(250, 9, true);
            WriteLiteral("\n        ");
            EndContext();
            BeginContext(260, 38, false);
#line 17 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
   Write(Html.HiddenFor(model => model.AlbumId));

#line default
#line hidden
            EndContext();
            BeginContext(298, 47, true);
            WriteLiteral("\n\n        <div class=\"form-group\">\n            ");
            EndContext();
            BeginContext(346, 91, false);
#line 20 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
       Write(Html.LabelFor(model => model.GenreId, "GenreId", new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(437, 53, true);
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
            EndContext();
            BeginContext(491, 42, false);
#line 22 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.DropDownList("GenreId", String.Empty));

#line default
#line hidden
            EndContext();
            BeginContext(533, 17, true);
            WriteLiteral("\n                ");
            EndContext();
            BeginContext(551, 49, false);
#line 23 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.GenreId));

#line default
#line hidden
            EndContext();
            BeginContext(600, 81, true);
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
            EndContext();
            BeginContext(682, 93, false);
#line 28 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
       Write(Html.LabelFor(model => model.ArtistId, "ArtistId", new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(775, 53, true);
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
            EndContext();
            BeginContext(829, 43, false);
#line 30 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.DropDownList("ArtistId", String.Empty));

#line default
#line hidden
            EndContext();
            BeginContext(872, 17, true);
            WriteLiteral("\n                ");
            EndContext();
            BeginContext(890, 50, false);
#line 31 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.ArtistId));

#line default
#line hidden
            EndContext();
            BeginContext(940, 81, true);
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
            EndContext();
            BeginContext(1022, 78, false);
#line 36 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
       Write(Html.LabelFor(model => model.Title, new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1100, 53, true);
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
            EndContext();
            BeginContext(1154, 36, false);
#line 38 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.EditorFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1190, 17, true);
            WriteLiteral("\n                ");
            EndContext();
            BeginContext(1208, 47, false);
#line 39 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1255, 81, true);
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
            EndContext();
            BeginContext(1337, 78, false);
#line 44 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
       Write(Html.LabelFor(model => model.Price, new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1415, 53, true);
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
            EndContext();
            BeginContext(1469, 36, false);
#line 46 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.EditorFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1505, 17, true);
            WriteLiteral("\n                ");
            EndContext();
            BeginContext(1523, 47, false);
#line 47 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1570, 81, true);
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            ");
            EndContext();
            BeginContext(1652, 84, false);
#line 52 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
       Write(Html.LabelFor(model => model.AlbumArtUrl, new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1736, 53, true);
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
            EndContext();
            BeginContext(1790, 42, false);
#line 54 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.EditorFor(model => model.AlbumArtUrl));

#line default
#line hidden
            EndContext();
            BeginContext(1832, 17, true);
            WriteLiteral("\n                ");
            EndContext();
            BeginContext(1850, 53, false);
#line 55 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.AlbumArtUrl));

#line default
#line hidden
            EndContext();
            BeginContext(1903, 243, true);
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            <div class=\"col-md-offset-2 col-md-10\">\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\n            </div>\n        </div>\n    </div>\n");
            EndContext();
#line 65 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
}

#line default
#line hidden
            BeginContext(2148, 11, true);
            WriteLiteral("\n<div>\n    ");
            EndContext();
            BeginContext(2160, 40, false);
#line 68 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(2200, 9, true);
            WriteLiteral("\n</div>\n\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2227, 1, true);
                WriteLiteral("\n");
                EndContext();
                BeginContext(2360, 11, true);
                WriteLiteral("    <script");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 2371, "\"", 2421, 1);
#line 74 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
WriteAttributeValue("", 2377, Url.Content("~/Scripts/jquery.validate.js"), 2377, 44, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2422, 22, true);
                WriteLiteral("></script>\n    <script");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 2444, "\"", 2506, 1);
#line 75 "/Users/puccio/Documents/GitHub/modernization-unicorn-store/UnicornStore/Areas/Admin/Views/StoreManager/Edit.cshtml"
WriteAttributeValue("", 2450, Url.Content("~/Scripts/jquery.validate.unobtrusive.js"), 2450, 56, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2507, 11, true);
                WriteLiteral("></script>\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UnicornStore.Models.Album> Html { get; private set; }
    }
}
#pragma warning restore 1591
