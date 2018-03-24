using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Views.Data;
using System.Web.Script.Serialization;
using WebApplication2.Views.Input;
//using System.Web.Http;

namespace WebApplication2.Controllers
{
	public class ImageController : Controller
	{ 
		const int NUM_IMAGES = 2;

		public string GetImage(InputView input)
		{
			//Server.Transfer("/Home");
			//var aa = HttpContext.Request.Browser.Type;

		
			
			var data = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/data.json"));
			DataView datView = new JavaScriptSerializer().Deserialize<DataView>(data);

			short ind = 0;
			if (HttpContext.Session["ind"] == null)
				HttpContext.Session["ind"] = 0;
			ind = Convert.ToInt16(HttpContext.Session["ind"]);
			
			var imgStr = String.Empty;

			if (ind >= datView.imgs.Count())
				ind = 0;

			List<Img> imgList = new List<Img>();
			for (var i = ind; i < ind + NUM_IMAGES; i++)
			{
				imgList.Add(datView.imgs[i]);
			}
			imgStr = new JavaScriptSerializer().Serialize(imgList);

			//img = datView.imgs[ind].img;

			ind += NUM_IMAGES;
			HttpContext.Session["ind"] = ind;

			return imgStr;
		}


	}
}