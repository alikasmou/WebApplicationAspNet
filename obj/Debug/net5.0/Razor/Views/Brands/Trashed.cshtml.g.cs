#pragma checksum "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b727c5c9ace088183171b8f327be3a4f35aa841"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Brands_Trashed), @"mvc.1.0.view", @"/Views/Brands/Trashed.cshtml")]
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
#nullable restore
#line 1 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\_ViewImports.cshtml"
using ecommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\_ViewImports.cshtml"
using ecommerce.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
using ecommerce.Vm;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b727c5c9ace088183171b8f327be3a4f35aa841", @"/Views/Brands/Trashed.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7f21b70560d5a59d669ee90de49e3401f8465fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Brands_Trashed : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<ecommerce.Vm.BrandsVm>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
  
    ViewData["Title"] = "Brands";
    Layout = "~/Views/Shared/_layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row mb-5 mt-5\">\r\n    <div class=\"container\">\r\n        <div class=\"alert alert-primary\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 368, "\"", 408, 1);
#nullable restore
#line 16 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
WriteAttributeValue("", 375, Url.ActionLink("Index","Brands"), 375, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Back To Brands</a>
        </div>

    </div>
</div>
<div class=""row mb-5"">
    <div class=""container"">
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">Trashed Brands</h3>
            </div>
            <!-- /.card-header -->
            <div class=""card-body"">
                <table id=""Brands"" class=""table table-bordered table-striped"">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Brand</th>
                            <th>Created at</th>
                            <th>Operations</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 39 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
                         foreach (var brand in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th>");
#nullable restore
#line 42 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
                               Write(brand.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 43 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
                               Write(brand.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>");
#nullable restore
#line 44 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
                               Write(brand.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                <th>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1511, "\"", 1575, 1);
#nullable restore
#line 46 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
WriteAttributeValue("", 1518, Url.ActionLink("Restore", "Brands", new {id = brand.Id}), 1518, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Restore</a> |\r\n                                    <a class=\"text-danger\"");
            BeginWriteAttribute("href", " href=\"", 1650, "\"", 1710, 1);
#nullable restore
#line 47 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
WriteAttributeValue("", 1657, Url.ActionLink("Drop","Brands", new {id = brand.Id}), 1657, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n                                </th>\r\n                            </tr>\r\n");
#nullable restore
#line 50 "C:\Users\alikasmou\Desktop\Code\ecommerce\ecommerce\Views\Brands\Trashed.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                    <tfoot>
                        <tr>
                            <th>Count : [Counter]</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <!-- /.card-body -->
        </div>
        <!-- /.card -->
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<ecommerce.Vm.BrandsVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
