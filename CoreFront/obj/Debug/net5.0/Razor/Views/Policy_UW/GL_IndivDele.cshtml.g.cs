#pragma checksum "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64f7a323e9a2cc8d1253ba342303c24780ca53db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Policy_UW_GL_IndivDele), @"mvc.1.0.view", @"/Views/Policy_UW/GL_IndivDele.cshtml")]
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
#line 1 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
using Microsoft.Extensions.Configuration.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64f7a323e9a2cc8d1253ba342303c24780ca53db", @"/Views/Policy_UW/GL_IndivDele.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99bcc360a617726928c7c32ba1e2393fb851fd94", @"/Views/_ViewImports.cshtml")]
    public class Views_Policy_UW_GL_IndivDele : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Policy_UW/GLIndivDelete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
  
    ViewData["Title"] = "GroupLife Individual Deletion";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"" src=""https://code.jquery.com/jquery-3.4.1.min.js""></script>
<link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css"">
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
<script src=""https://code.jquery.com/jquery-3.2.1.min.js""></script>
<script type=""text/javascript"" src=""http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
<script type=""text/javascript"" src=""http://cdnjs.cloudflare.com/ajax/libs/json2/20130526/json2.min.js""></script>
<link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css"" />
<script src=""https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js""></script>
<script type=""text/javascript"">

    const app_host_API = ");
#nullable restore
#line 20 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
                    Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_API_IP").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const api_port_API = ");
#nullable restore
#line 21 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
                    Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_API_PNO").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const Result_API = (app_host_API + \":\" + api_port_API);\r\n\r\n    const app_host_Front = ");
#nullable restore
#line 24 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
                      Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_FRONT_IP").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const api_port_Front = ");
#nullable restore
#line 25 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
                      Write(Json.Serialize(@Configuration.GetSection("Endpoint").GetSection("CORE_FRONT_PNO").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
    const Result_Front = (app_host_Front + "":"" + api_port_Front);

</script>

<script type=""text/javascript"">

    function Get_Added_Customer() {
        var PolicyNo = $(""#PolicyNo"").val();
        alert(1);
        var baseURL = ""http://"" + Result_API + ""/api/UnderWritting/Get_NewOrDelete_Customer/"" + PolicyNo;
        $.ajax(baseURL,
            {
                ""async"": true,
                ""crossDomain"": true,
                type: ""GET"",
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        function OnSuccess(response) {
            if (response === 0) {
                alert('Record not found');
            }
            $.fn.dataTable.ext.errMode = 'throw';
   ");
            WriteLiteral(@"         $(""#GL_IndivDelet"").DataTable({
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, ""All""]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                data: response,
                ""columns"": [{ ""data"": ""FGPC_CUST_TITLE"" },
                    { ""data"": ""FGPC_CUST_NAME"" },
                    { ""data"": ""FGPC_EMP_AGE"" },
                    { ""data"": ""FGPC_CUST_GENDER"" },
                    { ""data"": ""FGPC_CUST_OCCUP"" },
                    //{ ""data"": ""FSSI_DESCRIPTION"" },
                    { ""data"": ""FGPH_POLICY_NO"" },
                    { ""data"": ""FGQH_QUOTATHDR_CODE"" },
                    { ""data"": ""FGPC_CUST_CNIC"" },
                ],
            });
        };
    };

    $(document).ready(function () {
        $(""#FGBU_CUST_CNIC"").focusout(function () {
            let custCNIC = $(""#FGBU_CUST_CNIC"").val();
            let n1 = custCNIC.substring(0, 5);
            let n2 = cus");
            WriteLiteral(@"tCNIC.substring(5, 12);
            let addn = n1 + ""-"" + n2 + ""-"" + custCNIC[custCNIC.length - 1]
            $(""#FGBU_CUST_CNIC"").val(addn);
        })
    })

    window.setTimeout(function () {
        $("".alert"").fadeTo(500, 0).slideUp(500, function () {
            $(this).remove();
        });
    }, 4000);

    $(document).ready(function () {
        $('form input').keydown(function (event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                return false;
            }
        });

        $(document).ready(function () {
            $('#btnGLIDSearch').click(function (e) {
                e.preventDefault();
                var CustomerCNIC = $(""#CustomerCNIC"").val();
                var PolicyNo = $(""#PolicyNo"").val();
                var baseURL = ""http://"" + Result_API + ""/api/GLIndivAddi/GetGLIndiAddiDetails/"" + CustomerCNIC + ""/"" + PolicyNo;
                $("".spinner-box"").removeAttr(""hidden"", true);
                setTime");
            WriteLiteral(@"out(function () {
                    $.ajax(baseURL,
                        {
                            ""async"": true,
                            ""crossDomain"": true,
                            type: ""GET"",
                            cache: false,
                            contentType: ""application/json; charset=utf-8"",
                            datatype: JSON,
                            timeout: 5000,
                            success: function (data, status, xhr) {
                                $(data).each(function () {
                                    if (data) {

                                        $(""#FGQH_QUOTATHDR_ID"").val(this.FGQH_QUOTATHDR_ID);
                                        $(""#FGQH_QUOTATHDR_CODE"").val(this.FGQH_QUOTATHDR_CODE);
                                        $(""#FGBU_CUST_CNIC"").val(this.FGPC_CUST_CNIC);
                                        $(""#FGBU_CUST_NAME"").val(this.FGPC_CUST_NAME);
                                        $(""#FGBU");
            WriteLiteral(@"_EMP_AGE"").val(this.FGPC_EMP_AGE);
                                        $(""#FGBU_CUST_GENDER"").val(this.FGPC_CUST_GENDER);
                                        $(""#FGBU_EMP_NAME"").val(this.FGBU_EMP_NAME);
                                        $(""#FGPH_POLICY_NO"").val(this.FGPH_POLICY_NO);
                                        $(""#FGQH_QUOTATHDR_CODE"").val(this.FGQH_QUOTATHDR_CODE);
                                        $(""#FGPC_CUST_OCCUP"").val(this.FGPC_CUST_OCCUP);

                                    } else {
                                        alert('No Data Found for given criteria.');
                                    }
                                });
                            },
                            error: function (jqXhr, textStatus, errorMessage) { // error callback
                                alert('error, Counld not found Result as provided parameter.' + errorMessage);
                            }
                        }
                    );
");
            WriteLiteral("                    $(\".spinner-box\").attr(\"hidden\", true)\r\n                }, 2000)\r\n            });\r\n        });\r\n    });\r\n\r\n</script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64f7a323e9a2cc8d1253ba342303c24780ca53db13012", async() => {
                WriteLiteral(@"

    <div class=""card"">
        <div class=""card-body"">
            <div class=""row"">
                <h1 class=""card-title"" style=""font-weight:600; font-size:1.3rem; font-weight:bold"">Group Life Individual Deletion</h1>
            </div>
            <div class=""row"">
                <div class=""col-md-3"">
                    <label class=""text-success"" for=""CustomerSearch"" style=""font-weight:bold"">Customer Search:</label>
                </div>
            </div>
            <div class=""row"">
                <div class=""mb-2 col-md-3"">
                    <label class=""text-success"" for=""InstutionRegistration "" style=""font-weight:bold"">Customer CNIC:</label>
                    <input type=""text"" class=""form-control"" name=""CustomerCNIC"" id=""CustomerCNIC"" placeholder=""4420116544135"" maxlength=""15"">
                </div>
                <div class=""mb-3 col-md-3"">
                    <label class=""text-success"" for=""Instution_Name"" style=""font-weight:bold"">Policy No:</label>
             ");
                WriteLiteral(@"       <input type=""text"" class=""form-control"" name=""PolicyNo"" id=""PolicyNo"" placeholder=""GL10000001"" maxlength=""13"">
                </div>
                <div class=""mb-2 col-md-3"">
                    <div> <label class=""text-success"" for=""btnGLIDSearch "" style=""font-weight:bold""></label></div>
                    <button class=""btn btn-primary"" type=""button"" id=""btnGLIDSearch"" name=""btnGLIDSearch"" onclick=""btnGLIDSearch"" value=""Search"">Search!</button>
                </div>
                <div class=""col-md-4"">
");
#nullable restore
#line 176 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
                     if (TempData["successGLIndiviDelt"] != null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("<div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">\r\n                            <strong>\r\n                                ");
#nullable restore
#line 179 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
                           Write(TempData["successGLIndiviDelt"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </strong>\r\n                        </div>");
#nullable restore
#line 181 "D:\Current Working Front And APIs\CoreFront FVCF V 1.9\CoreFront\Views\Policy_UW\GL_IndivDele.cshtml"
                              }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </div>
            </div>
        </div>

        <div class=""card-body col-sm-11"">
            <div class=""row"">
                <h1 class=""card-title"" style=""font-weight:700; font-size:1.3rem"">Employee Details</h1>
            </div>
            <div class=""row mt-1"">
                <div class=""col-md-3 col-sm-12"">
                    <label for=""FGBU_CUST_CNIC"" class=""text-success"" style=""font-weight:bold;"">Customer CNIC:</label>
                    <input id=""FGBU_CUST_CNIC"" name=""FGBU_CUST_CNIC"" placeholder=""Customer CNIC "" class=""form-control"" readonly />
                </div>
                <div class=""col-md-3 col-sm-12"">
                    <label for=""FGBU_CUST_NAME"" class=""text-success"" style=""font-weight:bold;"">Customer Name:</label>
                    <input id=""FGBU_CUST_NAME"" name=""FGBU_CUST_NAME"" placeholder=""Customer Name"" class=""form-control"" readonly />
                </div>
                <div class=""col-md-3 col-sm-12"">
                    <label fo");
                WriteLiteral(@"r=""FGBU_EMP_AGE"" class=""text-success"" style=""font-weight:bold;"">Customer Age:</label>
                    <input id=""FGBU_EMP_AGE"" name=""FGBU_EMP_AGE"" placeholder=""Age"" class=""form-control"" readonly />
                </div>
                <div class=""col-md-3 col-sm-12"">
                    <label for=""FGBU_CUST_GENDER"" class=""text-success"" style=""font-weight:bold;"">Customer Gender:</label>
                    <input id=""FGBU_CUST_GENDER"" name=""FGBU_CUST_GENDER"" placeholder=""Gender"" class=""form-control"" readonly />
");
                WriteLiteral(@"                </div>
            </div>
            <div class=""row mt-2"">
                <div class=""col-md-3 col-sm-12"">
                    <label for=""FGPC_CUST_OCCUP"" class=""text-success"" style=""font-weight:bold;"">Occupation:</label>
                    <input id=""FGPC_CUST_OCCUP"" name=""FGPC_CUST_OCCUP"" placeholder=""Occupation"" class=""form-control"" readonly />
                </div>
");
                WriteLiteral(@"                <div class=""col-md-3 col-sm-12"">
                    <label for=""FGPH_POLICY_NO"" class=""text-success"" style=""font-weight:bold;"">Policy No:</label>
                    <input id=""FGPH_POLICY_NO"" name=""FGPH_POLICY_NO"" placeholder=""Policy No"" class=""form-control"" readonly />
                </div>
            </div>
            <!--<div class=""row"">
                <div class=""col-md-3"">
                    <label for=""emp_name"" class=""text-success"" style=""font-weight:bold""></label>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-3"">-->
");
                WriteLiteral("            <!--<h1 class=\"card-title text-success\" style=\"font-weight:bold; font-size:1rem\">Policy Details</h1>\r\n                </div>\r\n            </div>-->\r\n            <div class=\"row\">\r\n");
                WriteLiteral(@"            </div>
            <div class=""row "">
                <div class=""col-md-3"">
                    <label for=""emp_name"" class=""text-success"" style=""font-weight:bold""></label>
                </div>
            </div>
            <!--<div class=""row "">
            <div class=""col-md-3"">-->
");
                WriteLiteral(@"            <!--<h1 class=""card-title text-success"" style=""font-weight:bold; font-size:1rem"">Details</h1>
                </div>
                <div class=""col-md-12 col-sm-12 col-lg-12"" style=""overflow-x:auto"">
                    <table class=""table table-bordered mt-2 mb-1"" id=""TableDetails"">
                        <thead>
                            <tr class=""text-success"">
                                <th scope=""col"" colspan=""1"">Plan Rider Name</th>
                                <th scope=""col"" colspan=""1"">Sum Assured Criteria</th>
                                <th scope=""col"" colspan=""1"">Sum Assured</th>
                                <th scope=""col"" colspan=""1"">Loading Type</th>
                                <th scope=""col"" colspan=""1"">Loading Amount</th>
                                <th scope=""col"" colspan=""1"">Policy Start Date</th>
                                <th scope=""col"" colspan=""1"">Expire Start Date</th>
                                <th scope=""col"" colspan=""1""");
                WriteLiteral(@">Emp Premium Amount</th>
                                <th scope=""col"" colspan=""1"">Emp Addition Date</th>
                                <th scope=""col"" colspan=""1"">Status</th>
                        </thead>
                    </table>
                </div>
            </div>-->
            <div class=""row"">
                <div class=""col-md-3"">
                    <button class=""btn btn-success mt-2 mb-2"" type=""submit"" name=""Process"" id=""Process"">Process</button>
                </div>
                <div class=""col"">
                    <button class=""btn btn-primary"" type=""button"" id=""Submit"" name=""Submit"" onclick=""Get_Added_Customer()"">Load Data</button>
                </div>
            </div>
            <div class=""row"">
            </div>
            <div class=""container-fluid p-0"">
                <div class=""row"">
                    <div class=""col-12"">
                        <div class=""card"">
                            <div class=""card-body"">
                   ");
                WriteLiteral(@"             <table id=""GL_IndivDelet"" class=""table table-striped"" style=""width:100%"">
                                    <thead>
                                        <tr>
                                            <th>Title:</th>
                                            <th>Customer Name:</th>
                                            <th>Age</th>
                                            <th>Gendar</th>
                                            <th>Occupation</th>
                                            <th>Policy Number</th>
                                            <th>Quotation Code</th>
                                            <th>Customer CNIC</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
    ");
                WriteLiteral(@"            </div>
            </div>
        </div>
    </div>
    <div class=""spinner-box"" hidden>
        <img src=""/Assets/img/photos/loader_img.gif"" id=""loaderImage"" />
        <div id=""loader_text"" class=""text-white pt-2 text-center"">Please wait...While Data is Loading!</div>
    </div>
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
            WriteLiteral("\r\n");
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