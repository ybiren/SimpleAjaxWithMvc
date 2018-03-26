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
using System.Runtime.Caching;


namespace WebApplication2.Controllers
{
	public class ImageController : Controller
	{ 
		const int NUM_IMAGES = 2;


		private string GetData()
		{
			var data = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/data.json"));
			return data;
		}


		public string GetImage(InputView input)
		{
			//Server.Transfer("/Home");
			//var aa = HttpContext.Request.Browser.Type;
			var cacheService = new InMemoryCache();

			var data = cacheService.GetOrSet("images", () => GetData());
			
			//var data = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/data.json"));
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



public class InMemoryCache : ICacheService
	{
		public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
		{
			T item = MemoryCache.Default.Get(cacheKey) as T;
			if (item == null)
			{
				item = getItemCallback();
				MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
			}
			return item;
		}
	}

	interface ICacheService
	{
		T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
	}



}