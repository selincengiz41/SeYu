using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Seyu.Models;

namespace Seyu.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index(string baslik)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            var Result = collection.Find(a=> a.Baslik==baslik).FirstOrDefault();


            return View(Result);
           
        }
    }
}
