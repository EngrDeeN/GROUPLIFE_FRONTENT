using Microsoft.AspNetCore.Mvc;

namespace CoreFront.Controllers
{
    public class ReportingController : Controller
    {
        /*
        [Obsolete]
        private readonly IHostingEnvironment webHostEnvironment;
        public IJsReportMVCService JsReportMVCService { get; }

        [Obsolete]
        public ReportingController(IHostingEnvironment _webHostEnvironment, IJsReportMVCService jsReportMVCService)
        {
            this.webHostEnvironment = _webHostEnvironment;
            this.JsReportMVCService = jsReportMVCService;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [MiddlewareFilter(typeof(JsReportPipeline))]
        public IActionResult Invoice()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);

            return View(InvoiceModel.Example());
        }

        [MiddlewareFilter(typeof(JsReportPipeline))]
        public IActionResult InvoiceDownload()
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf)
                .OnAfterRender((r) => HttpContext.Response.Headers["Content-Disposition"] = "attachment; filename=\"myReport.pdf\"");

            return View("Invoice", InvoiceModel.Example());
        }

        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> InvoiceWithHeader()
        {
            var header = await JsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Header", new { });

            HttpContext.JsReportFeature()
                .Recipe(Recipe.ChromePdf)
                .Configure((r) => r.Template.Chrome = new Chrome
                {
                    HeaderTemplate = header,
                    DisplayHeaderFooter = true,
                    MarginTop = "1cm",
                    MarginLeft = "1cm",
                    MarginBottom = "1cm",
                    MarginRight = "1cm"
                });

            return View("Invoice", InvoiceModel.Example());
        }

        [MiddlewareFilter(typeof(JsReportPipeline))]
        public IActionResult Items()
        {
            HttpContext.JsReportFeature()
                .Recipe(Recipe.HtmlToXlsx)
                .Configure((r) => r.Template.HtmlToXlsx = new HtmlToXlsx() { HtmlEngine = "chrome" });

            return View(InvoiceModel.Example());
        }

        [MiddlewareFilter(typeof(JsReportPipeline))]
        public IActionResult ItemsExcelOnline()
        {
            HttpContext.JsReportFeature()
                .Configure(req => req.Options.Preview = true)
                .Recipe(Recipe.HtmlToXlsx)
                .Configure((r) => r.Template.HtmlToXlsx = new HtmlToXlsx() { HtmlEngine = "chrome" });

            return View("Items", InvoiceModel.Example());
        }

        [MiddlewareFilter(typeof(JsReportPipeline))]
        public IActionResult InvoiceDebugLogs()
        {
            HttpContext.JsReportFeature()
                .DebugLogsToResponse()
                .Recipe(Recipe.ChromePdf);

            return View("Invoice", InvoiceModel.Example());
        }


        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> InvoiceWithCover()
        {
            var coverHtml = await JsReportMVCService.RenderViewToStringAsync(HttpContext, RouteData, "Cover", new { });
            HttpContext.JsReportFeature()
                .Recipe(Recipe.ChromePdf)
                .Configure((r) =>
                {
                    r.Template.PdfOperations = new[]
                    {
                        new PdfOperation()
                        {
                            Template = new Template
                            {
                                Content = coverHtml,
                                Engine = Engine.None,
                                Recipe = Recipe.ChromePdf
                            },
                            Type = PdfOperationType.Prepend
                        }
                    };
                });

            return View("Invoice", InvoiceModel.Example());
        }

        [MiddlewareFilter(typeof(JsReportPipeline))]
        public IActionResult ChartWithPrintTrigger()
        {
            HttpContext.JsReportFeature()
                .Recipe(Recipe.ChromePdf)
                .Configure(cfg =>
                {
                    cfg.Template.Chrome = new Chrome
                    {
                        WaitForJS = true
                    };
                });

            return View("Chart", new { });
        }


        //[Obsolete]
        //public void Print_Receipt(string ftpr_rcpt_refno1)
        //{
        //    _ = _Print_Receipt(ftpr_rcpt_refno1);

        //}

        [Obsolete]
        public ActionResult Print_Receipt(string ftpr_rcpt_refno1)
        {

            var dt = new DataTable();
            string mimetype = "";
            int extension = 1;
            var path = $"{webHostEnvironment.WebRootPath}\\Resources\\GroupPolicy.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "ReportParameter1", "RDLC report (Set as parameter)" }
            };
            AspNetCore.Reporting.LocalReport lr = new AspNetCore.Reporting.LocalReport(path);
            //lr.AddDataSource("dsEmployee", dt);
            var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");

        }*/
    }
}
