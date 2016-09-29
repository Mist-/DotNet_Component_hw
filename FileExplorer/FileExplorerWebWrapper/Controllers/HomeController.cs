using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using FileExplorerWebWrapper.Models;
using FileExplorerWebWrapper.VO;
using FileExplorer;

namespace FileExplorerWebWrapper.Controllers
{
	
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return Redirect("/Home/Files");
		}
		
		public ActionResult Files()
		{
			return View();
		}

		public ActionResult FileInfo()
		{
			string filePath = Request.Form["filePath"].ToString();
			string keyField = Request.Form["keyField"].ToString();
			currFileModel = new FileModel(filePath);
			currFileModel.KeyField = keyField;
			return Json(currFileModel);
		}

		public ActionResult Delete()
		{
			string filePath = Request.Form["filePath"].ToString();
			try
			{
				FileExplorerModel.DeleteFromDisk(filePath, false);
			}
			catch (Exception e)
			{
				return Json(new ResultMessage(1, e.Message));
			}
			return Json(new ResultMessage());
		}

		/// <summary>
		/// 只是用来返回纯html文档用的=。=
		/// </summary>
		/// <param name="path">示例： ~/View/files.cshtml ，懂了吧</param>
		/// <returns></returns>
		private ActionResult RawView(string path)
		{
			using (StreamReader sr = new StreamReader(Server.MapPath(path)))
            {
                string htmlContent = sr.ReadToEnd();
                return Content(htmlContent);
            }
		}

		private FileModel currFileModel = null;
	}
}
