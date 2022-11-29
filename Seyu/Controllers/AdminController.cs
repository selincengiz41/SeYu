using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Seyu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Threading.Tasks;
namespace Seyu.Controllers
{
    public class AdminController : Controller
    {
        public string emails = "email@gmail.com";
        public string passwords = "password";
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string k)
        {
            string email = Request.Method == "POST" ? Request.Form["email"] : string.Empty;
            string password = Request.Method == "POST" ? Request.Form["password"] : string.Empty;
            if (emails == email && passwords == password)
            {
                return Redirect("../Admin/Edit");


            }
            return Redirect("");
        }
        [HttpGet]
        public IActionResult Edit()
        {


            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            var Result = collection.Find(a => true).ToList();

            return View(Result);
        }
        [HttpPost]
        public IActionResult Edit(string submitButton)
        {
            switch (submitButton)
            {
                case "Search":
                    // delegate sending to another controller action
                    return (Search());
                case "WebScraping":
                    // call another action to perform the cancellation
                    return (Scrap());
                default:
                    // If they've submitted the form without a submitButton, 
                    // just return the view again.
                    return (View());
            }
        
          
        }
        private ActionResult Scrap()
        {
           DatabaseConnection.ClearData();
            WebScraping();
       DatabaseConnection.TrendyolConnect();
       DatabaseConnection.VatanConnect();
        DatabaseConnection.n11Connect();
       DatabaseConnection.mediaMarktConnect();



            return Redirect("../Admin/Edit");
           
        }
        private void WebScraping()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            //Start with a list of URLs
            var urls = new string[]
                {
        "https://www.vatanbilgisayar.com/notebook/",
         "https://www.vatanbilgisayar.com/laptop/?page=2",
          "https://www.vatanbilgisayar.com/laptop/?page=3",
           "https://www.vatanbilgisayar.com/laptop/?page=4",
            "https://www.vatanbilgisayar.com/laptop/?page=5",
        "https://www.n11.com/bilgisayar/dizustu-bilgisayar",
        "https://www.n11.com/bilgisayar/dizustu-bilgisayar?pg=2",
        "https://www.n11.com/bilgisayar/dizustu-bilgisayar?pg=3",
        "https://www.n11.com/bilgisayar/dizustu-bilgisayar?pg=4",
        "https://www.n11.com/bilgisayar/dizustu-bilgisayar?pg=5",
        "https://www.trendyol.com/laptop-x-c103108?pi=2",
        "https://www.trendyol.com/laptop-x-c103108?pi=3",
        "https://www.trendyol.com/laptop-x-c103108?pi=4",
        "https://www.trendyol.com/laptop-x-c103108?pi=5",
        "https://www.mediamarkt.com.tr/tr/category/_laptop-504926.html",
        "https://www.mediamarkt.com.tr/tr/category/_laptop-504926.html?searchParams=&sort=suggested&view=&page=2",
        "https://www.mediamarkt.com.tr/tr/category/_laptop-504926.html?searchParams=&sort=suggested&view=&page=3"
                };

            //Start requests for all of them
            var requests = urls.Select
                (
                    url => client.GetStringAsync(url)
                ).ToList();

            //Wait for all the requests to finish
            //  await Task.WhenAll(requests);

            //Get the responses
            var responses = requests.Select
                (
                    task => task.Result
                );
            //  await Task.WhenAll((Task)responses);
            var index = 0;
            foreach (var response in responses)
            {
            if (index >= 0 && index <=4)
                {
                    ParseHtmlVatan(response);

                }
              if (index >= 5 && index <=9)
                {
                    ParseHtmln11(response);
                }
              if (index >= 10 && index <=13)
                {
                    ParseHtmlTrendyol(response);
                }
             if (index >= 14)
                {
                    ParseHtmlMediaMarkt(response);
                }

                index++;

            }

        }
        private void ParseHtmlMediaMarkt(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var programmerLinks = htmlDoc.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "product-wrapper")

    .Take(30)
    .ToList();

            var data = programmerLinks.Select((node) =>
            {
                return new
                {
                    baslik = node.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "content ").QuerySelectorAll("h2"),

                    marka = node.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "content "),

                    fiyat = node.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "price small"),

                    resim = node.QuerySelectorAll("span")
                  .Where(e => e.GetAttributeValue("class", "") == "photo clickable"),

                    url = node.QuerySelectorAll("span")
                  .Where(e => e.GetAttributeValue("class", "") == "photo clickable"),


                };
            }
                );
            // Marka , fiyat , resim , başlık , derece,url

            List<string> baslikListe = new List<string>();
            List<string> markaListe = new List<string>();
            List<double> fiyatListe = new List<double>();
            List<string> resimListe = new List<string>();
            List<string> urlListe = new List<string>();

            foreach (var link in data)
            {
                

                foreach (var baslik in link.baslik)
                {

                    baslikListe.Add(baslik.InnerText);
                }

                foreach (var marka in link.marka)
                {
                    markaListe.Add(marka.InnerText.Replace("\n", "").Replace("\t", "").Split(" ")[0]);
                }
                foreach (var fiyat in link.fiyat)
                {
                    double switched = double.Parse(fiyat.InnerText.Replace(".", "").Replace("TL", "").Replace("-", "").Replace(",", "."));
                    fiyatListe.Add(switched);
                }

                foreach (var resim in link.resim)
                {
                   
                        resimListe.Add("https://cdn.dsmcdn.com//ty513/product/media/images/20220822/16/163937942/117736341/1/1_org.jpg");
                }

                foreach (var url in link.url)
                {
                    urlListe.Add(url.GetAttributeValue("data-clickable-href", ""));
                }

            }
            for (int i = 0; i < baslikListe.Count; i++)
            {
                Laptop laptop = new Laptop
                {
                    Marka = markaListe[i],
                    Fiyat = fiyatListe[i],
                    Resim = resimListe[i],
                    Baslik = baslikListe[i],
                    Url = "https://www.mediamarkt.com.tr"+ urlListe[i],
                    islemciMarkası = "  ",
                    islemciNesli = "  ",
                    islemciTeknolojisi = " ",
                    ram = " ",
                    ekranBoyutu = " ",
                    ekranKartı = "  ",
                    diskKapasitesi = "  ",

                };
                DatabaseConnection.mediaMarktLaptops.Add(laptop);


            }
            DetailMediaMarkt();

        }
        private void ParseHtmlVatan(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var programmerLinks = htmlDoc.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "product-list product-list--list-page")

    .Take(30)
    .ToList();

            var data = programmerLinks.Select((node) =>
            {
                return new
                {
                    baslik = node.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "product-list__product-name"),

                    marka = node.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "product-list__product-name"),

                    fiyat = node.QuerySelectorAll("span")
                  .Where(e => e.GetAttributeValue("class", "") == "product-list__price"),

                    resim = node.QuerySelectorAll("img")
                  .Where(e => e.GetAttributeValue("class", "") == "lazyimg"),

                    url = node.QuerySelectorAll("a")
                  .Where(e => e.GetAttributeValue("class", "") == "product-list__image-safe-link sld")


                };
            }
                );
            // Marka , fiyat , resim , başlık , derece,url

            List<string> baslikListe = new List<string>();
            List<string> markaListe = new List<string>();
            List<double> fiyatListe = new List<double>();
            List<string> resimListe = new List<string>();
            List<string> urlListe = new List<string>();

            foreach (var link in data)
            {

                foreach (var baslik in link.baslik)
                {

                    baslikListe.Add(baslik.InnerText);
                }

                foreach (var marka in link.marka)
                {
                    markaListe.Add(marka.InnerText.Split(" ")[0]);
                }
                foreach (var fiyat in link.fiyat)
                {
                    double switched = double.Parse(fiyat.InnerText.Replace(".", "").Replace(",", "."));
                    fiyatListe.Add(switched);
                }

                foreach (var resim in link.resim)
                {
                    resimListe.Add(resim.GetAttributeValue("data-src", ""));
                }

                foreach (var url in link.url)
                {
                    urlListe.Add(url.GetAttributeValue("href", ""));
                }

            }
            for (int i = 0; i < baslikListe.Count; i++)
            {
                Laptop laptop = new Laptop
                {
                    Marka = markaListe[i],
                    Fiyat = fiyatListe[i],
                    Resim = resimListe[i],
                    Baslik = baslikListe[i],
                    Url = "https://www.vatanbilgisayar.com" + urlListe[i],
                    islemciMarkası = "  ",
                    islemciNesli = "  ",
                    islemciTeknolojisi = " ",
                    ram = " ",
                    ekranBoyutu = " ",
                    ekranKartı = "  ",
                    diskKapasitesi = "  ",

                };
                DatabaseConnection.vatanLaptops.Add(laptop);


            }
            DetailVatan();


        }
        private void ParseHtmln11(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var programmerLinks = htmlDoc.QuerySelectorAll("li")
                  .Where(e => e.GetAttributeValue("class", "") == "column ")


    .Take(30)
        .ToList();

            var data = programmerLinks.Select((node) =>
            {
                return new
                {
                    baslik = node.QuerySelectorAll("h3")
                  .Where(e => e.GetAttributeValue("class", "") == "productName"),

                    marka = node.QuerySelectorAll("h3")
                  .Where(e => e.GetAttributeValue("class", "") == "productName"),

                    fiyat = node.QuerySelectorAll("span")
                  .Where(e => e.GetAttributeValue("class", "") == "newPrice cPoint priceEventClick"),

                    resim = node.QuerySelectorAll("img")
                  .Where(e => e.GetAttributeValue("class", "") == "lazy cardImage"),

                    url = node.QuerySelectorAll("a")



                };
            }
                );
            // Marka , fiyat , resim , başlık , derece,url

            List<string> baslikListe = new List<string>();
            List<string> markaListe = new List<string>();
            List<double> fiyatListe = new List<double>();
            List<string> resimListe = new List<string>();
            List<string> urlListe = new List<string>();

            foreach (var link in data)
            {

                foreach (var baslik in link.baslik)
                {

                    baslikListe.Add(baslik.InnerText);
                }

                foreach (var marka in link.marka)
                {
                    markaListe.Add(marka.InnerText.Split(" ")[0]);
                }
                foreach (var fiyat in link.fiyat)
                {
                    double switched = double.Parse(fiyat.InnerText.Replace(".", "").Replace(",", ".").Replace("TL", ""));
                    fiyatListe.Add(switched);
                }

                foreach (var resim in link.resim)
                {
                    resimListe.Add(resim.GetAttributeValue("data-src", ""));
                }

                foreach (var url in link.url)
                {
                    urlListe.Add(url.GetAttributeValue("href", ""));
                }

            }
            for (int i = 0; i < baslikListe.Count; i++)
            {
                Laptop laptop = new Laptop()
                {
                    Marka = markaListe[i],
                    Fiyat = fiyatListe[i],
                    Resim = resimListe[i],
                    Baslik = baslikListe[i],
                    Url = urlListe[i],
                    islemciMarkası = "  ",
                    islemciNesli = "  ",
                    islemciTeknolojisi = " ",
                    ram = " ",
                    ekranBoyutu = " ",
                    ekranKartı = "  ",
                    diskKapasitesi = "  ",

                };
                DatabaseConnection.n11Laptops.Add(laptop);


            }
            Detailn11();

        }
        public void DetailTrendyol()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var computerLinks = new List<List<HtmlNode>>();
            HttpClient client = new HttpClient(clientHandler);

            var requests = DatabaseConnection.trendyolLaptops.Select
               (
                   url => client.GetStringAsync(url.Url)
               ).ToList();

            //Wait for all the requests to finish
            // await Task.WhenAll(requests);

            //Get the responses
            var responses = requests.Select
                (
                    task => task.Result
                );
            //  await Task.WhenAll((Task)responses);
            foreach (var response in responses)
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response);

                var programmerLinks = htmlDoc.QuerySelectorAll("li")
                      .Where(e => e.GetAttributeValue("class", "") == "detail-attr-item")

        .Take(30)
        .ToList();
                computerLinks.Add(programmerLinks);


            }
            var index = 0;
            foreach (var item in computerLinks)
            {
                foreach (var feature in item)
                {
                    if (feature.InnerText.Contains("İşlemci Tipi"))
                    {
                        var MarkaTeknoloji = feature.InnerText.Replace("İşlemci Tipi", "").Replace("\n", "").Split(" ", 3);
                        if (MarkaTeknoloji[1] != null)
                            DatabaseConnection.trendyolLaptops[index].islemciMarkası = MarkaTeknoloji[1];
                        if (MarkaTeknoloji.Length > 2)
                            DatabaseConnection.trendyolLaptops[index].islemciTeknolojisi = MarkaTeknoloji[2];
                    }
                    if (feature.InnerText.Contains("İşlemci Nesli"))
                    {
                        DatabaseConnection.trendyolLaptops[index].islemciNesli = feature.InnerText.Replace("İşlemci Nesli", "").Replace("\n", "");
                    }
                    if (feature.InnerText.Contains("Ram (Sistem Belleği)") && !feature.InnerText.Contains("Tipi "))
                    {
                        DatabaseConnection.trendyolLaptops[index].ram = feature.InnerText.Replace("Ram (Sistem Belleği)", "").Replace("\n", "");
                    }
                    if (feature.InnerText.Contains("Ekran Boyutu"))
                    {
                        DatabaseConnection.trendyolLaptops[index].ekranBoyutu = feature.InnerText.Replace("Ekran Boyutu", "").Replace("\n", "");
                    }
                    if (feature.InnerText.Contains("Ekran Kartı") && !feature.InnerText.Contains("Tipi") && !feature.InnerText.Contains("Hafızası"))
                    {
                        DatabaseConnection.trendyolLaptops[index].ekranKartı = feature.InnerText.Replace("Ekran Kartı", "").Replace("\n", "");
                    }
                    if (feature.InnerText.Contains("SSD Kapasitesi"))
                    {
                        DatabaseConnection.trendyolLaptops[index].diskKapasitesi = feature.InnerText.Replace("SSD Kapasitesi", "").Replace("\n", "");
                    }


                }

                index++;

            }




        }
        public void DetailVatan()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var computerLinks = new List<List<HtmlNode>>();
            HttpClient client = new HttpClient(clientHandler);

            var requests = DatabaseConnection.vatanLaptops.Select
               (
                   url => client.GetStringAsync(url.Url)
               ).ToList();

            //Wait for all the requests to finish
            //  await Task.WhenAll(requests);

            //Get the responses
            var responses = requests.Select
                (
                    task => task.Result
                );
            //  await Task.WhenAll((Task)responses);
            foreach (var response in responses)
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response);

                /* var programmerLinks = htmlDoc.QuerySelectorAll("ul")
                       .Where(e => e.GetAttributeValue("class", "") == "pdetail-property-list").QuerySelectorAll("li")*/

                var programmerLinks = htmlDoc.QuerySelectorAll("table")
                .Where(e => e.GetAttributeValue("class", "") == "product-table").QuerySelectorAll("tr")


  .Take(30)
  .ToList();
                computerLinks.Add(programmerLinks);
            }
            var index = 0;
            foreach (var item in computerLinks)
            {
                foreach (var feature in item)
                {
                    if (feature.InnerText.Contains("İşlemci Markası"))
                    {
                        DatabaseConnection.vatanLaptops[index].islemciMarkası = feature.InnerText.Replace("İşlemci Markası", "").Replace("&nbsp; İzle", "").Replace("\n", "").Replace("&#174;", "");
                    }
                    if (feature.InnerText.Contains("İşlemci Nesli"))
                    {
                        DatabaseConnection.vatanLaptops[index].islemciNesli = feature.InnerText.Replace("İşlemci Nesli", "").Replace("\n", "").Replace("&nbsp; İzle", "");
                    }
                    if (feature.InnerText.Contains("İşlemci Teknolojisi"))
                    {
                        DatabaseConnection.vatanLaptops[index].islemciTeknolojisi = feature.InnerText.Replace("İşlemci Teknolojisi", "").Replace("\n", "").Replace("&nbsp; İzle", "");
                    }
                    if (feature.InnerText.Contains("Ram (Sistem Belleği)"))
                    {
                        DatabaseConnection.vatanLaptops[index].ram = feature.InnerText.Replace("Ram (Sistem Belleği)", "").Replace("\n", "").Replace("&nbsp; İzle", "");
                    }
                    if (feature.InnerText.Contains("Ekran Boyutu"))
                    {
                        DatabaseConnection.vatanLaptops[index].ekranBoyutu = feature.InnerText.Replace("Ekran Boyutu", "").Replace("\n", "").Replace("&nbsp; İzle", "");
                    }
                    if (feature.InnerText.Contains("Ekran Kartı Chipseti"))
                    {
                        DatabaseConnection.vatanLaptops[index].ekranKartı = feature.InnerText.Replace("Ekran Kartı Tipi", "").Replace("Ekran Kartı Chipseti", "").Replace("Ekran Kartı Chipset Marka", "").Replace("\n", "").Replace("&nbsp; İzle", "").Replace("&#174;", "");
                    }
                    if (feature.InnerText.Contains("Disk Kapasitesi"))
                    {
                        DatabaseConnection.vatanLaptops[index].diskKapasitesi = feature.InnerText.Replace("Disk Kapasitesi", "").Replace("&nbsp; İzle", "").Replace("\n", "");
                    }


                }

                index++;

            }



        }
        public void DetailMediaMarkt()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var computerLinks = new List<List<HtmlNode>>();
            var computerLinksData = new List<List<HtmlNode>>();
            HttpClient client = new HttpClient(clientHandler);

            var requests = DatabaseConnection.mediaMarktLaptops.Select
               (
                   url => client.GetStringAsync(url.Url)
               ).ToList();

            //Wait for all the requests to finish
            //  await Task.WhenAll(requests);

            //Get the responses
            var responses = requests.Select
                (
                    task => task.Result
                );
            //  await Task.WhenAll((Task)responses);
            foreach (var response in responses)
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response);

                /* var programmerLinks = htmlDoc.QuerySelectorAll("ul")
                       .Where(e => e.GetAttributeValue("class", "") == "pdetail-property-list").QuerySelectorAll("li")*/

                var programmerLinks = htmlDoc.QuerySelectorAll("dl")
                .Where(e => e.GetAttributeValue("class", "") == "specification").QuerySelectorAll("dt")

  .Take(30)
  .ToList();
                var programmerLinksData = htmlDoc.QuerySelectorAll("dl")
                .Where(e => e.GetAttributeValue("class", "") == "specification").QuerySelectorAll("dd")

  .Take(30)
  .ToList();
                computerLinksData.Add(programmerLinksData);
                computerLinks.Add(programmerLinks);
            }
            var index = 0;
            foreach (var item in computerLinks)
            {
                var indexFeature = 0;
                foreach (var feature in item)
                {
                   
                    if (feature.InnerText.Contains("İşlemci Nesli"))
                    {
                        DatabaseConnection.mediaMarktLaptops[index].islemciNesli = feature.InnerText.Replace("İşlemci Nesli", "").Replace("\n", "").Replace("&nbsp; İzle", "");
                    }
                   if (feature.InnerText.Contains("İşlemci Markası:"))
                     {
                         DatabaseConnection.mediaMarktLaptops[index].islemciMarkası = computerLinksData[index][indexFeature].InnerText.Replace("İşlemci Markası:", "").Replace("Intel dünyanın en büyük işlemci üreticisidir vesabit disk (SSD) alanında da  öncüdür. ", "").Replace("\n", "").Replace("&#174;", "");
                     }
                    
                     if (feature.InnerText.Contains("İşlemci Modeli:"))
                     {
                         DatabaseConnection.mediaMarktLaptops[index].islemciTeknolojisi = computerLinksData[index][indexFeature].InnerText.Replace("İşlemci Modeli:", "").Replace("\n", "").Replace("&nbsp; İzle", "");
                     }
                    if (feature.InnerText.Contains("RAM Bellek Boyutu:"))
                    {
                        DatabaseConnection.mediaMarktLaptops[index].ram = computerLinksData[index][indexFeature].InnerText.Replace("RAM Bellek Boyutu:", "").Replace("\n", "").Replace("&nbsp; İzle", "");
                    }
                    if (feature.InnerText.Contains("Ekran Boyutu (in&ccedil;):"))
                    {
                        DatabaseConnection.mediaMarktLaptops[index].ekranBoyutu = computerLinksData[index][indexFeature].InnerText.Replace("Ekran Boyutu (in&ccedil;):", "").Replace("\n", "").Replace("&nbsp; İzle", "");
                    }
                    if (feature.InnerText.Contains("Ekran kartı:"))
                    {
                        DatabaseConnection.mediaMarktLaptops[index].ekranKartı = computerLinksData[index][indexFeature].InnerText.Replace("Ekran kartı:", "").Replace("Ekran Kartı Chipseti", "").Replace("Ekran Kartı Chipset Marka", "").Replace("\n", "").Replace("&nbsp; İzle", "").Replace("&#174;", "");
                    }
                    if (feature.InnerText.Contains("Sabit disk kapasitesi:"))
                    {
                        DatabaseConnection.mediaMarktLaptops[index].diskKapasitesi = computerLinksData[index][indexFeature].InnerText.Replace("Sabit disk kapasitesi:", "").Replace("&nbsp; İzle", "").Replace("\n", "");
                    }

                    indexFeature++;
                }

                index++;

            }



        }
        public void Detailn11()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var computerLinks = new List<List<HtmlNode>>();
            HttpClient client = new HttpClient(clientHandler);

            var requests = DatabaseConnection.n11Laptops.Select
               (
                   url => client.GetStringAsync(url.Url)
               ).ToList();

            //Wait for all the requests to finish
            //  await Task.WhenAll(requests);

            //Get the responses
            var responses = requests.Select
                (
                    task => task.Result
                );
            // await Task.WhenAll((Task)responses);
            foreach (var response in responses)
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response);

                /* var programmerLinks = htmlDoc.QuerySelectorAll("ul")
                       .Where(e => e.GetAttributeValue("class", "") == "pdetail-property-list").QuerySelectorAll("li")*/

                var programmerLinks = htmlDoc.QuerySelectorAll("li")
                .Where(e => e.GetAttributeValue("class", "") == "unf-prop-list-item")


  .Take(30)
  .ToList();
                computerLinks.Add(programmerLinks);
            }
            var index = 0;
            foreach (var item in computerLinks)
            {
                foreach (var feature in item)
                {
                    if (feature.InnerText.Contains("İşlemci") && !feature.InnerText.Contains("İşlemci Çekirdek Sayısı") && !feature.InnerText.Contains("İşlemci Modeli") && !feature.InnerText.Contains("İşlemci Hızı"))
                    {
                        var MarkaTeknoloji = feature.InnerText.Replace("İşlemci", "").Replace("\n", "").Replace("\t", "").Split(" ", 15);

                        if (MarkaTeknoloji[13] != null)
                            DatabaseConnection.n11Laptops[index].islemciMarkası = MarkaTeknoloji[13];
                        if (MarkaTeknoloji.Length > 14)
                            DatabaseConnection.n11Laptops[index].islemciTeknolojisi = MarkaTeknoloji[14];
                    }
                    if (feature.InnerText.Contains("İşlemci Nesli"))
                    {
                        DatabaseConnection.n11Laptops[index].islemciNesli = feature.InnerText.Replace("İşlemci Nesli", "").Replace("\n", "");
                    }
                    if (feature.InnerText.Contains("İşlemci Teknolojisi"))
                    {
                        DatabaseConnection.n11Laptops[index].islemciTeknolojisi = feature.InnerText.Replace("İşlemci Teknolojisi", "").Replace("\n", "");
                    }
                    if (feature.InnerText.Contains("Bellek Kapasitesi"))
                    {
                        DatabaseConnection.n11Laptops[index].ram = feature.InnerText.Replace("Bellek Kapasitesi", "").Replace("\n", "");
                    }
                    if (feature.InnerText.Contains("Ekran Boyutu"))
                    {
                        DatabaseConnection.n11Laptops[index].ekranBoyutu = feature.InnerText.Replace("Ekran Boyutu", "").Replace("\n", "").Replace("&quot", "").Replace(";", "");
                    }
                    if (feature.InnerText.Contains("Ekran Kartı Modeli"))
                    {
                        DatabaseConnection.n11Laptops[index].ekranKartı = feature.InnerText.Replace("Ekran Kartı Modeli", "").Replace("\n", "");
                    }
                    if (feature.InnerText.Contains("Disk Kapasitesi"))
                    {
                        DatabaseConnection.n11Laptops[index].diskKapasitesi = feature.InnerText.Replace("Disk Kapasitesi", "").Replace("\n", "");
                    }


                }

                index++;

            }



        }
        private void ParseHtmlTrendyol(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var programmerLinks = htmlDoc.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "p-card-wrppr with-campaign-view")

    .Take(30)
    .ToList();

            var data = programmerLinks.Select((node) =>
            {
                return new
                {
                    baslik = node.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "prdct-desc-cntnr-ttl-w two-line-text"),

                    marka = node.QuerySelectorAll("span")
                  .Where(e => e.GetAttributeValue("class", "") == "prdct-desc-cntnr-ttl"),

                    fiyat = node.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "prc-box-dscntd"),

                    resim = node.QuerySelectorAll("img")
                  .Where(e => e.GetAttributeValue("class", "") == "p-card-img"),

                    url = node.QuerySelectorAll("div")
                  .Where(e => e.GetAttributeValue("class", "") == "p-card-chldrn-cntnr card-border")


                };
            }
                );
            // Marka , fiyat , resim , başlık , derece,url

            List<string> baslikListe = new List<string>();
            List<string> markaListe = new List<string>();
            List<double> fiyatListe = new List<double>();
            List<string> resimListe = new List<string>();
            List<string> urlListe = new List<string>();
            foreach (var link in data)
            {

                foreach (var baslik in link.baslik)
                {

                    baslikListe.Add(baslik.InnerText);
                }

                foreach (var marka in link.marka)
                {
                    markaListe.Add(marka.InnerText);
                }
                foreach (var fiyat in link.fiyat)
                {
                    double switched = double.Parse(fiyat.InnerText.Replace(".", "").Replace(",", ".").Replace("TL", ""));
                    fiyatListe.Add(switched);
                }

                foreach (var resim in link.resim)
                {
                    resimListe.Add("https://img-itopya.mncdn.com/cdn/250/yeni-proje-2022-05-26t134806037-03e7c8.jpg");
                }

                foreach (var url in link.url)
                {
                    urlListe.Add(url.FirstChild.GetAttributeValue("href", ""));
                }

            }
            for (int i = 0; i < baslikListe.Count; i++)
            {
                Laptop laptop = new Laptop
                {
                    Marka = markaListe[i],
                    Fiyat = fiyatListe[i],
                    Resim = resimListe[i],
                    Baslik = baslikListe[i],
                    Url = "https://www.trendyol.com" + urlListe[i],
                    islemciMarkası = "  ",
                    islemciNesli = "  ",
                    islemciTeknolojisi = " ",
                    ram = " ",
                    ekranBoyutu = " ",
                    ekranKartı = "  ",
                    diskKapasitesi = "  ",
                };
                DatabaseConnection.trendyolLaptops.Add(laptop);


            }
            DetailTrendyol();

        }
        private ActionResult Search()
        {
            string search = Request.Method == "POST" ? Request.Form["search"] : string.Empty;
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            var Result = collection.Find(a => a.Baslik.Contains(search) || a.ekranBoyutu.Contains(search) || a.Marka.Contains(search) || a.ekranKartı.Contains(search) || a.diskKapasitesi.Contains(search) || a.islemciMarkası.Contains(search) || a.islemciNesli.Contains(search) || a.islemciTeknolojisi.Contains(search) || a.ram.Contains(search) || a.Url.Contains(search)).ToList();

            return View(Result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string k)
        {
            string marka = Request.Method == "POST" ? Request.Form["marka"] : string.Empty;
            string model = Request.Method == "POST" ? Request.Form["model"] : string.Empty;
            string fiyat = Request.Method == "POST" ? Request.Form["fiyat"] : string.Empty;
            string baslik = Request.Method == "POST" ? Request.Form["baslik"] : string.Empty;
            string url = Request.Method == "POST" ? Request.Form["url"] : string.Empty;
            string islemciMarkasi = Request.Method == "POST" ? Request.Form["islemciMarkasi"] : string.Empty;
            string islemciNesli = Request.Method == "POST" ? Request.Form["islemciNesli"] : string.Empty;
            string islemciTeknolojisi = Request.Method == "POST" ? Request.Form["islemciTeknolojisi"] : string.Empty;
            string ram = Request.Method == "POST" ? Request.Form["ram"] : string.Empty;
            string ekranBoyutu = Request.Method == "POST" ? Request.Form["ekranBoyutu"] : string.Empty;
            string ekranKartı = Request.Method == "POST" ? Request.Form["ekranKartı"] : string.Empty;
            string diskKapasitesi = Request.Method == "POST" ? Request.Form["diskKapasitesi"] : string.Empty;

            double price;
            if (fiyat == "")
            {
                price = 0;
            }
            else
            {
                price = double.Parse(fiyat);
            }

            Laptop laptop = new Laptop
            {
                Marka = marka,
                Fiyat = price,
                Resim = "",
                Baslik = baslik,
                Url = url,
                islemciMarkası = islemciMarkasi,
                islemciNesli = islemciNesli,
                islemciTeknolojisi = islemciTeknolojisi,
                ram = ram,
                ekranBoyutu = ekranBoyutu,
                ekranKartı = ekranKartı,
                diskKapasitesi = diskKapasitesi,

            };


            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            collection.InsertOne(laptop);
            return Redirect("../Admin/Edit");
        }
        [HttpGet]
        public IActionResult Sil(string baslik)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            collection.DeleteOne(a => a.Baslik == baslik);

            return Redirect("../Admin/Edit");
        }

        [HttpGet]
        public IActionResult Update(string id,string bos)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
           var Result= collection.Find(a => a.Id == id).FirstOrDefault();

           

            return View(Result);
        }

        [HttpPost]
        public IActionResult Update(string buton)
        {
            string id = Request.Method == "POST" ? Request.Form["id"] : string.Empty;
            string marka = Request.Method == "POST" ? Request.Form["marka"] : string.Empty;
            string model = Request.Method == "POST" ? Request.Form["model"] : string.Empty;
            string fiyat = Request.Method == "POST" ? Request.Form["fiyat"] : string.Empty;
            string baslik = Request.Method == "POST" ? Request.Form["baslik"] : string.Empty;
            string url = Request.Method == "POST" ? Request.Form["url"] : string.Empty;
            string islemciMarkasi = Request.Method == "POST" ? Request.Form["islemciMarkasi"] : string.Empty;
            string islemciNesli = Request.Method == "POST" ? Request.Form["islemciNesli"] : string.Empty;
            string islemciTeknolojisi = Request.Method == "POST" ? Request.Form["islemciTeknolojisi"] : string.Empty;
            string ram = Request.Method == "POST" ? Request.Form["ram"] : string.Empty;
            string ekranBoyutu = Request.Method == "POST" ? Request.Form["ekranBoyutu"] : string.Empty;
            string ekranKartı = Request.Method == "POST" ? Request.Form["ekranKartı"] : string.Empty;
            string diskKapasitesi = Request.Method == "POST" ? Request.Form["diskKapasitesi"] : string.Empty;
            double price;
            if (fiyat == "")
            {
                price = 0;
            }
            else
            {
                price = double.Parse(fiyat);
            }
            Laptop laptop = new Laptop
            {
                Id=id,
                Marka = marka,
                Fiyat = price,
                Resim = "",
                Baslik = baslik,
                Url = url,
                islemciMarkası = islemciMarkasi,
                islemciNesli = islemciNesli,
                islemciTeknolojisi = islemciTeknolojisi,
                ram = ram,
                ekranBoyutu = ekranBoyutu,
                ekranKartı = ekranKartı,
                diskKapasitesi = diskKapasitesi,

            };
         

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            collection.ReplaceOne(a => a.Id == id , laptop);

            return Redirect("../Edit");
        }

    }


}