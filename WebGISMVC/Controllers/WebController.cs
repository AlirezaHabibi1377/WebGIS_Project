using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGISMVC.Models;
using System.Data;
namespace WebGISMVC.Controllers
{
    public class WebController : Controller
    {
        [HttpPost]
        public ActionResult reportProvince(string search)
        {
            search.LoginWS reportProvince = new search.LoginWS();
            DataSet ds = reportProvince.SaleOnProvince(search);
            DataTable fd;
            DataTable dt = ds.Tables[0];
            ViewBag.fd = dt;
            return View();
        }

        public ActionResult report()
        {
            search.LoginWS report = new search.LoginWS();
            DataSet ds = report.Sales();
            DataTable fd;
            DataTable dt = ds.Tables[0];
            ViewBag.fd = dt;
            return View();
        }

        [HttpPost]
        public ActionResult Insert(string name, string agenet, string ostan, string city, float lat, float lon , float sale)
        {
            search.LoginWS StoreInsert = new search.LoginWS();
           
            if (StoreInsert.NewStore(name, agenet, ostan, city , lat, lon, sale) == "success")
            {
                //return Content(
                //    "<script> alert('با موفقیت ثبت شد.') </script>"
                //);
                return RedirectToAction("MainPage");
            }
            else
            {
                return Content(
                    "<script> alert('Error!') </script>"
                );
            }
        }
        
        public ActionResult NewStores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult search(string search)
        {
            search.LoginWS usersearch = new search.LoginWS();
            
            DataSet ds = usersearch.Search(search);
            DataTable fd;
            DataTable dt = ds.Tables[0];
            ViewBag.fd = dt;
            
            //return View("MainPage");
            return View();
        }

        public ActionResult first()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string uname, string psw)
        {
            //ViewBag.username = username;
            ////var httpRequest = HttpContext.Request;
            Login.LoginWS User = new Login.LoginWS();
           
            if (User.Login(uname, psw) == "0")
            {
                return View();
            }

            else
            {
                
                return RedirectToAction("MainPage");
            }
        }

        public ActionResult MainPage()
        {
            #region osm&city&DEM
            
            Layer StamenLayer = new Layer()
            {
                Name = "Stamen",
                Type = LayerType.RasterTile,
                IsBaseMap = true,
                Source = "ol.source.OSM",
                URL = "http://a.tile.stamen.com/watercolor/{z}/{x}/{y}.jpg"
            };

            Layer VectorLayer = new Layer()
            {
                Name = "VectorCity",
                Type = LayerType.Vector,
                IsBaseMap = false,
                Source = "ol.source.Vector",
                Title = "City",
                Format = "ol.format.GeoJSON",
                
                URL = "http://localhost:8080/geoserver/WebGIS/ows?service=WFS&version=1.0.0&request=GetFeature&typeName=WebGIS%3ACity&outputFormat=application%2Fjson"
            };

            Layer RasterLayer = new Layer()
            {
                Name = "DEM",
                Type = LayerType.Raster,
                IsBaseMap = false,
                Source = "ol.source.XYZ",
                Title = "DEM",

                URL = "http://localhost:8080/geoserver/gwc/service/wmts?layer=WebGIS%3ADEM_IR&style=&tilematrixset=EPSG%3A900913&Service=WMTS&Request=GetTile&Version=1.0.0&Format=image%2Fpng&TileMatrix=EPSG%3A900913%3A{z}&TileCol={x}&TileRow={y}"
            };

            #endregion

            List<Layer> Layers = new List<Layer>();
            Layers.Add(StamenLayer);
            Layers.Add(VectorLayer);
            Layers.Add(RasterLayer);
            ViewBag.Layers = Layers;
            return View("MainPage");
        }
    }
}