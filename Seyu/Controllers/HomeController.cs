using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using Seyu;
using Seyu.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Intrinsics.Arm;
using System.Security.Policy;
using System.Threading.Tasks;

namespace SeYu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
     


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Index()
        {
            WebScraping();
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            var Result = collection.Find(a => true).ToList();


            return View(Result);
        }

        public async Task WebScraping()
        {
              HttpClient client = new HttpClient();

            //Start with a list of URLs
            var urls = new string[]
                {
        "https://www.trendyol.com/laptop-x-c103108?pi=2",
        "https://www.vatanbilgisayar.com/notebook/"
                };

            //Start requests for all of them
            var requests = urls.Select
                (
                    url => client.GetStringAsync(url)
                ).ToList();

            //Wait for all the requests to finish
            await Task.WhenAll(requests);

            //Get the responses
            var responses = requests.Select
                (
                    task => task.Result
                );

            var index = 0;
            foreach (var response in responses)
            {
                if (index == 0)
                {
                    var liste = ParseHtmlTrendyol(response);

                }
                if (index == 1)
                {
                    var listeHepsiburada = ParseHtmlVatan(response);
                }
                index++;

            }
        }
        private List<string> ParseHtmlVatan(string html)
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
            List<string> fiyatListe = new List<string>();
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
                    fiyatListe.Add(fiyat.InnerText);
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
                    islemciMarkası="  ",
                    islemciNesli="  ",
                    islemciTeknolojisi = " ",
                    ram =  " ",
                    ekranBoyutu = " ",
                    ekranKartı="  ",
                    diskKapasitesi="  ",

                };
                DatabaseConnection.vatanLaptops.Add(laptop);


            }
            DetailVatan();
           
            return baslikListe;
        }
        public async Task DetailTrendyol()
        {
            var computerLinks = new List<List<HtmlNode>>();
            HttpClient client = new HttpClient();

            var requests = DatabaseConnection.trendyolLaptops.Select
               (
                   url => client.GetStringAsync(url.Url)
               ).ToList();

            //Wait for all the requests to finish
            await Task.WhenAll(requests);

            //Get the responses
            var responses = requests.Select
                (
                    task => task.Result
                );
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
                        DatabaseConnection.trendyolLaptops[index].islemciMarkası = feature.InnerText.Replace("İşlemci Tipi", "").Replace("\n", "");
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

            DatabaseConnection.TrendyolConnect();


        }
        public async Task DetailVatan()
        {
            var computerLinks = new List<List<HtmlNode>>();
            HttpClient client = new HttpClient();

            var requests = DatabaseConnection.vatanLaptops.Select
               (
                   url => client.GetStringAsync(url.Url)
               ).ToList();

            //Wait for all the requests to finish
            await Task.WhenAll(requests);

            //Get the responses
            var responses = requests.Select
                (
                    task => task.Result
                );
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
                foreach(var item in computerLinks)
                {
                    foreach(var feature in item)
                    {
                        if (feature.InnerText.Contains("İşlemci Markası"))
                        {
                            DatabaseConnection.vatanLaptops[index].islemciMarkası = feature.InnerText.Replace("İşlemci Markası","").Replace("&nbsp; İzle","").Replace("\n", "");
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
                        if (feature.InnerText.Contains("Ekran Kartı"))
                        {
                            DatabaseConnection.vatanLaptops[index].ekranKartı = feature.InnerText.Replace("Ekran Kartı Tipi", "").Replace("Ekran Kartı Chipset Marka", "").Replace("\n", "").Replace("&nbsp; İzle", "");
                        }
                        if (feature.InnerText.Contains("Disk Kapasitesi"))
                        {
                            DatabaseConnection.vatanLaptops[index].diskKapasitesi = feature.InnerText.Replace("Disk Kapasitesi", "").Replace("&nbsp; İzle", "").Replace("\n", "");
                        }


                    }

                    index++;

                }

            DatabaseConnection.VatanConnect();

        }
       
        private List<string> ParseHtmlTrendyol(string html)
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
            List<string> fiyatListe = new List<string>();
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
                    fiyatListe.Add(fiyat.InnerText);
                }

                foreach (var resim in link.resim)
                {
                    resimListe.Add(resim.GetAttributeValue("src", ""));
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
            return baslikListe;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
