#pragma checksum "C:\Users\Admin\source\repos\AppCrud\AppCrud\Views\Clothes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10a69cea7fdb0d6898401f6f2ffd8c2a2cfd4b66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clothes_Index), @"mvc.1.0.view", @"/Views/Clothes/Index.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\AppCrud\AppCrud\Views\_ViewImports.cshtml"
using AppCrud;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\AppCrud\AppCrud\Views\_ViewImports.cshtml"
using AppCrud.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10a69cea7fdb0d6898401f6f2ffd8c2a2cfd4b66", @"/Views/Clothes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4805470b98547d8aef3dcc1d04c248407270cd41", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Clothes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Admin\source\repos\AppCrud\AppCrud\Views\Clothes\Index.cshtml"
  
    Layout = "/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Clothes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n");
            WriteLiteral(@"        <h2> Blogs </h2>
        <table class=""table"">
            <thead>
                <tr>
                    <th scope=""col"">Id</th>
                    <th scope=""col"">Name</th>
                    <th scope=""col"">Description</th>
                    <th scope=""col"">Rental Time</th>
                    <th scope=""col"">Rental Price</th>
                    <th scope=""col"">Status</th>
                </tr>
            </thead>
            <tbody id=""bodyContent"">
            </tbody>
        </table>
    </div>
</div>
<script>
    const main = async () => {
        var url = '/api/Clothes';
        console.log(url);
        var reponse = await fetch(url);
        var data = await reponse.json();
        renderSlide(data);
    }
    const renderSlide = (data) => {
        var domSlide = document.querySelector(""#bodyContent"")
        var html = '';
        data.forEach((element, index) => {
            html += `
                    <tr>
                      <th scope=""row"">");
            WriteLiteral(@"${element.id}</th>
                      <td>${element.name}</td>
                      <td>${element.description}</td>
                      <td>${element.rentalTime}</td>
                      <td>${element.rentalPrice}</td>
                      <td>${element.status==0?""Available"":""Rental""}</td>
                    </tr>
                    `;
        });

        console.log(domSlide);
        domSlide.innerHTML = html;
    }
    main()
</script>");
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
