using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Microsoft.AspNetCore.Cors;

namespace CoreFront.Controllers
{
    public class FileUploadController : PageModel
	{
		private readonly IWebHostEnvironment webHostEnvironment;

		public FileUploadController(IWebHostEnvironment webHostEnvironment)
		{
			this.webHostEnvironment = webHostEnvironment;
		}

		[EnableCors("GlobalWebPolicy")]
		//[HttpPost]
		public IActionResult OnPostMyUploader(IFormFile MyUploader)
		{
			if (MyUploader != null)
			{
				string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "mediaUpload");
				string filePath = Path.Combine(uploadsFolder, MyUploader.FileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					MyUploader.CopyTo(fileStream);
				}
				return new ObjectResult(new { status = "success" });
			}
			return new ObjectResult(new { status = "fail" });

		}
	}
}