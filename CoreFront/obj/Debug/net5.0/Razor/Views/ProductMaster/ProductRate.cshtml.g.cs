#pragma checksum "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\ProductMaster\ProductRate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9a421c3653d1d93704f84bd7c495d6504252808"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductMaster_ProductRate), @"mvc.1.0.view", @"/Views/ProductMaster/ProductRate.cshtml")]
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
#line 1 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\_ViewImports.cshtml"
using CoreFront;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\_ViewImports.cshtml"
using CoreFront.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\ProductMaster\ProductRate.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\ProductMaster\ProductRate.cshtml"
using Microsoft.Extensions.Configuration.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9a421c3653d1d93704f84bd7c495d6504252808", @"/Views/ProductMaster/ProductRate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99bcc360a617726928c7c32ba1e2393fb851fd94", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductMaster_ProductRate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\ProductMaster\ProductRate.cshtml"
  
    ViewData["Title"] = "Product Rates";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js\"></script>\r\n\r\n<script>\r\n   const app_host_API = ");
#nullable restore
#line 11 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\ProductMaster\ProductRate.cshtml"
                   Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_API_IP").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const api_port_API = ");
#nullable restore
#line 12 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\ProductMaster\ProductRate.cshtml"
                    Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_API_PNO").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const Result_API = (app_host_API + \":\" + api_port_API);\r\n\r\n    const app_host_Front = ");
#nullable restore
#line 15 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\ProductMaster\ProductRate.cshtml"
                      Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_FRONT_IP").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const api_port_Front = ");
#nullable restore
#line 16 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\ProductMaster\ProductRate.cshtml"
                      Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_FRONT_PNO").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
    const Result_Front = (app_host_Front + "":"" + api_port_Front);

    //Result_API = ""localhost:62252"";
    //Result_Front = ""localhost:16948"";
</script>

<script>
    $(document).ready(function () {
        $(""#imageUploadForm"").change(function () {
            var formData = new FormData();
            var totalFiles = document.getElementById(""imageUploadForm"").files.length;
            for (var i = 0; i < totalFiles; i++) {
                var file = document.getElementById(""imageUploadForm"").files[i];
                formData.append(""imageUploadForm"", file);
            }
            $.ajax({
                type: ""POST"",
                url: '/Home/Upload',
                data: formData,
                dataType: 'json',
                contentType: false,
                processData: false
            }).done(function () {
                alert('success');
            }.fail(function (xhr, status, errorThrown) {
                alert('fail');
            };
        });
 ");
            WriteLiteral("   });\r\n</script>\r\n<input type=\"file\" id=\"imageUploadForm\" name=\"image\" multiple=\"multiple\" />");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration Configuration { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
