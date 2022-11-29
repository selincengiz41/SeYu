using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using MongoDB.Driver.Linq;
using Seyu;
using Seyu.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Intrinsics.Arm;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace SeYu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
     


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
          

           

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            var Result = collection.Find(a => true).ToList();
           

            return View(Result);
        }
        [HttpPost]
        public IActionResult Index(string submitButton)
        {
            switch (submitButton)
            {
                case "Search":
                    // delegate sending to another controller action
                    return (Search());
                case "Submit":
                    // call another action to perform the cancellation
                    return (Submit());
                case "EnDusukFiyat":
                    // call another action to perform the cancellation
                    return (EnDüsükFiyat());
                case "EnYuksekFiyat":
                    // call another action to perform the cancellation
                    return (EnYüksekFiyat());
                default:
                    // If they've submitted the form without a submitButton, 
                    // just return the view again.
                    return (View());
            }

           
        

        }
        private ActionResult EnDüsükFiyat()
        {
            
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            var Result = collection.Find(a=> true).SortBy(a=> a.Fiyat).ToList();

            return View(Result);
        }
        private ActionResult EnYüksekFiyat()
        {
           
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            var Result = collection.Find(a => true).SortByDescending(a => a.Fiyat).ToList();

            return View(Result);
        }
        private ActionResult Search()
        {
            string search = Request.Method == "POST" ? Request.Form["search"] : string.Empty;
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            var Result = collection.Find(a => a.Baslik.Contains(search) || a.ekranBoyutu.Contains(search) || a.Marka.Contains(search) || a.ekranKartı.Contains(search) || a.diskKapasitesi.Contains(search) || a.islemciMarkası.Contains(search) || a.islemciNesli.Contains(search) || a.islemciTeknolojisi.Contains(search)  || a.ram.Contains(search) || a.Url.Contains(search)).ToList();

            return View(Result);
        }
        private ActionResult Submit()
        {
          


            //MARKA
            string Asus = Request.Method == "POST" ? Request.Form["Asus"] : string.Empty;
            string Lenovo = Request.Method == "POST" ? Request.Form["Lenovo"] : string.Empty;
            string Monster = Request.Method == "POST" ? Request.Form["Monster"] : string.Empty;
            string Msi = Request.Method == "POST" ? Request.Form["Msi"] : string.Empty;
            string Apple = Request.Method == "POST" ? Request.Form["Apple"] : string.Empty;
            string Hp = Request.Method == "POST" ? Request.Form["Hp"] : string.Empty;


                //FİYAT
                string Price1 = Request.Method == "POST" ? Request.Form["Price1"] : string.Empty;
            string Price2 = Request.Method == "POST" ? Request.Form["Price2"] : string.Empty;
            string Price3 = Request.Method == "POST" ? Request.Form["Price3"] : string.Empty;
          

          
            //RAM
            string Ram4 = Request.Method == "POST" ? Request.Form["Ram4"] : string.Empty;
            string Ram8 = Request.Method == "POST" ? Request.Form["Ram8"] : string.Empty;
            string Ram16 = Request.Method == "POST" ? Request.Form["Ram16"] : string.Empty;
           
          
            //İŞLEMCİ MARKASI
            string Amd = Request.Method == "POST" ? Request.Form["Amd"] : string.Empty;
            string Intel = Request.Method == "POST" ? Request.Form["Intel"] : string.Empty;
            

            //İŞLEMCİ TEKNOLOJİSİ   
            string Amd3 = Request.Method == "POST" ? Request.Form["Amd3"] : string.Empty;
            string Amd5 = Request.Method == "POST" ? Request.Form["Amd5"] : string.Empty;
            string Amd7 = Request.Method == "POST" ? Request.Form["Amd7"] : string.Empty;
            string IntelC = Request.Method == "POST" ? Request.Form["IntelC"] : string.Empty;
            string Intel3 = Request.Method == "POST" ? Request.Form["Intel3"] : string.Empty;
            string Intel5 = Request.Method == "POST" ? Request.Form["Intel5"] : string.Empty;
            string Intel7 = Request.Method == "POST" ? Request.Form["Intel7"] : string.Empty;
            string Intel9 = Request.Method == "POST" ? Request.Form["Intel9"] : string.Empty;
             

            //DİSK KAPASİTESİ
            string Disk0 = Request.Method == "POST" ? Request.Form["Disk0"] : string.Empty;
            string Disk1 = Request.Method == "POST" ? Request.Form["Disk1"] : string.Empty;
            string Disk2 = Request.Method == "POST" ? Request.Form["Disk2"] : string.Empty;

            
            //EKRAN BOYUTU
            string E13 = Request.Method == "POST" ? Request.Form["E13"] : string.Empty;
            string E15 = Request.Method == "POST" ? Request.Form["E15"] : string.Empty;
            string E17 = Request.Method == "POST" ? Request.Form["E17"] : string.Empty;
          

            //EKRAN KARTI
            string AmdS = Request.Method == "POST" ? Request.Form["AmdS"] : string.Empty;
            string IntelS = Request.Method == "POST" ? Request.Form["IntelS"] : string.Empty;
            string NvidiaS = Request.Method == "POST" ? Request.Form["NvidiaS"] : string.Empty;



            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            List<Laptop> result1 = new List<Laptop>();

            if (Asus != null || Lenovo != null || Monster != null || Msi != null || Apple != null || Hp != null)
            {
                result1 = collection.Find(a => a.Marka == Asus || a.Marka == Lenovo || a.Marka == Monster || a.Marka == Msi || a.Marka == Apple || a.Marka == Hp
           
            )
                    .ToList();
            }
            if (Price1 != null || Price2 != null || Price3 != null)
            {
               
                string[] liste1;
                string[] liste2;
                string[] liste3;
                if (Price1 != null)
                {
                    liste1 = Price1.Split("-");
                }
                else
                {
                    liste1 =new string[2];
                    liste1[0] = "-999";
                    liste1[1] = "-999";

                }
                if (Price2 != null)
                {
                    liste2 = Price2.Split("-");
                }
                else
                {
                    liste2 = new string[2];
                    liste2[0] = "-999";
                    liste2[1] = "-999";

                }
                if (Price3 != null)
                {
                    liste3 = Price3.Split("-");
                }
                else
                {
                    liste3 = new string[2];
                    liste3[0] = "-999";
                    liste3[1] = "-999";

                }
                double[] converted1=new double[2];
                double[] converted2 = new double[2];
                double[] converted3 = new double[2];
                for (var i = 0; i < 2; i++)
                {
                  converted1[i]=  double.Parse(liste1[i]);
                  converted2[i] = double.Parse(liste2[i]);
                  converted3[i] = double.Parse(liste3[i]);
                }

               result1 = collection.Find(a => (a.Fiyat > converted1[0] && a.Fiyat < converted1[1]) || (a.Fiyat > converted2[0] && a.Fiyat < converted2[1])
               || (a.Fiyat > converted3[0] && a.Fiyat < converted3[1])
          )
                  .ToList();

            }
            if (Ram4 != null || Ram8 != null || Ram16 != null)
            {
                List<string> rams = new List<string>();
                rams.Add(Ram4);
                rams.Add(Ram8);
                rams.Add(Ram16);
                for (var i = 0; i < 3; i++)
                {
                    if (rams[i] == null)
                    {
                        rams[i] = "rhtergeafaeraaegegeaerg";
                    }
                }

                result1 = collection.Find(a=> a.ram.Contains(rams[0]) || a.ram.Contains(rams[1]) || a.ram.Contains(rams[2])

          )
                  .ToList();
                 
            }
            if (AmdS!=null || IntelS!=null || NvidiaS != null)
            {
                List<string> ekranKartları = new List<string>();
                ekranKartları.Add(AmdS);
                ekranKartları.Add(IntelS);
                ekranKartları.Add(NvidiaS);
                for(var i = 0; i< 3; i++)
                {
                    if (ekranKartları[i] == null)
                    {
                        ekranKartları[i] = "rhtergeafaeraaegegeaerg";
                    }
                }
                result1 = collection.Find(a => (a.ekranKartı.Contains(ekranKartları[0]) || a.ekranKartı.Contains(ekranKartları[1]) || a.ekranKartı.Contains(ekranKartları[2]))

         )
                 .ToList();

            }
           
            if (Amd != null || Intel != null)
            {
                List<string> işlemciMarkalari = new List<string>();
                işlemciMarkalari.Add(Amd);
                işlemciMarkalari.Add(Intel);
               
                for (var i = 0; i < 2; i++)
                {
                    if (işlemciMarkalari[i] == null)
                    {
                        işlemciMarkalari[i] = "rhtergeafaeraaegegeaerg";
                    }
                }
                result1 = collection.Find(a => (a.islemciMarkası.Contains(işlemciMarkalari[0]) || a.islemciMarkası.Contains(işlemciMarkalari[1]))

         )
                 .ToList();
            }
            if (Amd3 != null || Amd5 != null || Amd7 != null || Intel9 != null || Intel7 != null || Intel5 != null || Intel3 != null || IntelC != null)
            {
                List<string> işlemciTeknolojileri = new List<string>();
                işlemciTeknolojileri.Add(Amd3);
                işlemciTeknolojileri.Add(Amd5);
                işlemciTeknolojileri.Add(Amd7);
                işlemciTeknolojileri.Add(Intel9);
                işlemciTeknolojileri.Add(Intel7);
                işlemciTeknolojileri.Add(Intel5);
                işlemciTeknolojileri.Add(Intel3);
                işlemciTeknolojileri.Add(IntelC);

                for (var i = 0; i < 8; i++)
                {
                    if (işlemciTeknolojileri[i] == null)
                    {
                        işlemciTeknolojileri[i] = "rhtergeafaeraaegegeaerg";
                    }
                }
                result1 = collection.Find(a => (a.islemciTeknolojisi.Contains(işlemciTeknolojileri[0]) || a.islemciTeknolojisi.Contains(işlemciTeknolojileri[1]) || a.islemciTeknolojisi.Contains(işlemciTeknolojileri[2])
                || a.islemciTeknolojisi.Contains(işlemciTeknolojileri[3]) || a.islemciTeknolojisi.Contains(işlemciTeknolojileri[4]) || a.islemciTeknolojisi.Contains(işlemciTeknolojileri[5])
                || a.islemciTeknolojisi.Contains(işlemciTeknolojileri[6]) || a.islemciTeknolojisi.Contains(işlemciTeknolojileri[7]))

         )
                 .ToList();
            }
            if (Disk0 != null || Disk1 != null || Disk2 != null)
            {

            }
            if (E13 != null || E15 != null || E17 != null)
            {

            }
           


           /*     
                var filter1 = Builders<Laptop>.Filter.Where(a => a.Marka == Asus || a.Marka == Lenovo || a.Marka == Monster || a.Marka == Msi || a.Marka == Apple || a.Marka == Hp);
                var filter2 = Builders<Laptop>.Filter.Where(a => a.ram == Ram4 || a.ram == Ram8 || a.ram == Ram16);
              
                FilterDefinition<Laptop> filter = filter1 & filter2 ;
            var Result = collection.Find(filter).ToList();
           
            result1 = collection.Find(a => a.Marka == Asus || a.Marka ==Lenovo || a.Marka ==Monster || a.Marka == Msi || a.Marka ==Apple || a.Marka ==Hp
            || a.ram ==Ram4 || a.ram == Ram8 || a.ram == Ram16
           
            
            )
                    .ToList();*/

          //  (Int32.Parse(a.Fiyat.Replace("TL", "")) > Int32.Parse(Price1Range[0]) && Int32.Parse(a.Fiyat.Replace("TL", "")) < Int32.Parse(Price1Range[1]))
         /*    || (a.islemciMarkası.Contains(Amd3) || a.islemciMarkası.Contains(Amd5) || a.islemciMarkası.Contains(Amd7) || a.islemciMarkası.Contains(IntelC) || a.islemciMarkası.Contains(Intel3) || a.islemciMarkası.Contains(Intel5)
            || a.islemciMarkası.Contains(Intel7) || a.islemciMarkası.Contains(Intel9))*/


            return View(result1);
        }
     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
