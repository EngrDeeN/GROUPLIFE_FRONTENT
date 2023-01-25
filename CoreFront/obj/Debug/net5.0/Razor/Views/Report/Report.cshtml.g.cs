#pragma checksum "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Report\Report.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "219c6aac15e7abe1a2e06821e74343a78d0057fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Report), @"mvc.1.0.view", @"/Views/Report/Report.cshtml")]
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
#line 1 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Report\Report.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Report\Report.cshtml"
using Microsoft.Extensions.Configuration.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"219c6aac15e7abe1a2e06821e74343a78d0057fb", @"/Views/Report/Report.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99bcc360a617726928c7c32ba1e2393fb851fd94", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_Report : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Reporting/Print_Receipt"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Report\Report.cshtml"
  
    ViewData["Title"] = "Policy Reporting";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"" src=""https://code.jquery.com/jquery-3.4.1.min.js""></script>
<link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css"">
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
<script src=""https://code.jquery.com/jquery-3.2.1.min.js""></script>
<script type=""text/javascript"" src=""http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
<script type=""text/javascript"" src=""http://cdnjs.cloudflare.com/ajax/libs/json2/20130526/json2.min.js""></script>

<script>
   const app_host_API = ");
#nullable restore
#line 18 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Report\Report.cshtml"
                   Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_API_IP").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const api_port_API = ");
#nullable restore
#line 19 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Report\Report.cshtml"
                    Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_API_PNO").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const Result_API = (app_host_API + \":\" + api_port_API);\r\n\r\n    const app_host_Front = ");
#nullable restore
#line 22 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Report\Report.cshtml"
                      Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_FRONT_IP").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const api_port_Front = ");
#nullable restore
#line 23 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Report\Report.cshtml"
                      Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_FRONT_PNO").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
    const Result_Front = (app_host_Front + "":"" + api_port_Front);

</script>

<script type=""text/javascript"">

    //$(document).ready(function () {
    //    $(""#Print_Receipt"").on('click', function () {
    //        var ftpr_rcpt_refno1 = $(""#ftpr_rcpt_refno1"").val();
    //        // alert(""Hello, In Print_Receipt Mehtid"" + ftpr_rcpt_refno1);
    //        $.ajax({
    //            type: 'POST',
    //            url: ""/Reporting/Print_Receipt?ftpr_rcpt_refno1="" + ftpr_rcpt_refno1 + """",
    //            contentType: ""application/json; charset=utf-8"",
    //            dataType: ""json"",
    //            processData: true,
    //            success: function (repo) {
    //                alert(""File is uploaded successfully"");
    //            },
    //            error: function (request, status, error) {
    //                alert(""Error "" + error.responseText);
    //            }
    //        });
    //    });
    //});

</script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "219c6aac15e7abe1a2e06821e74343a78d0057fb8114", async() => {
                WriteLiteral(@"
    <div class=""row"">
        <input class=""form-control"" name=""ftpr_rcpt_refno1"" id=""ftpr_rcpt_refno1"" hidden=""hidden"" value=""QT100000041"">
        <div class=""mb-3 col-md-3"">
            <button class=""btn btn-success"" type=""submit"" id=""Print_Receipt"" name=""Print_Receipt"">Print Receipt</button>
        </div>
    </div>");
                WriteLiteral(@"


    <input id=""IsActive"" name=""IsActive"" type=""checkbox"" value=""false"">
    <input id=""IsActive1"" name=""IsActive"" type=""checkbox"" value=""false"">


    <script>
        $('#IsActive').change(function () {
            var chk = $(""#IsActive"")
            var IsChecked = chk[0].checked
            if (IsChecked) {
                chk.attr('checked', 'checked')
            }
            else {
                chk.removeAttr('checked')
            }
            chk.attr('value', IsChecked)
        });
    </script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
