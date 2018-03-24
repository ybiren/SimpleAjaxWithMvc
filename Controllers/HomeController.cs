using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Views.Data;
using System.Web.Script.Serialization;

namespace WebApplication2.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		//[HttpPost]
		public void  DoLogin()
		{

			StreamReader sr = new StreamReader(Server.MapPath(@"~/App_Data/data.json"));
			var x = sr.ReadToEnd();
			sr.Close();

			if (HttpContext.Session["num"] == null)
				HttpContext.Session["num"] = 0;
			else
			{
				int num = Convert.ToInt16(HttpContext.Session["num"]);
				num++;
				HttpContext.Session["num"] = num;
			}
		
			var aa = 3;
		}


		public string GetImage()
		{
			var data = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/data.json"));
			DataView datView = new JavaScriptSerializer().Deserialize<DataView>(data);

			short ind = 0;
			if (HttpContext.Session["ind"] == null)
				HttpContext.Session["ind"] = 0;
			ind = Convert.ToInt16(HttpContext.Session["ind"]);


			var img = String.Empty;

			if (ind >= datView.imgs.Count())
				ind = 0;
			img = datView.imgs[ind].img;
			HttpContext.Session["ind"] = ++ind;
			
			return img;
		}


	}
}