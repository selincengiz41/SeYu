using MongoDB.Driver;
using Seyu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seyu
{
    public class DatabaseConnection
    {
        public static List<Laptop> vatanLaptops = new List<Laptop>();
        public static List<Laptop> trendyolLaptops = new List<Laptop>();
        public static List<Laptop> n11Laptops = new List<Laptop>();
        public static List<Laptop> mediaMarktLaptops = new List<Laptop>();
        public static List<Laptop> Laptops = new List<Laptop>();
        public static void TrendyolConnect()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            Laptops.AddRange(trendyolLaptops);
            collection.InsertMany(trendyolLaptops);
        }
        public static void VatanConnect()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            Laptops.AddRange(vatanLaptops);
            collection.InsertMany(vatanLaptops);
        }
        public static void n11Connect()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            Laptops.AddRange(n11Laptops);
            collection.InsertMany(n11Laptops);
        }

        public static void mediaMarktConnect()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            Laptops.AddRange(mediaMarktLaptops);
            collection.InsertMany(mediaMarktLaptops);
        }

        public static void ClearData()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbSeyu:q123q123q@cluster0.vaizm.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("seyuDb");
            var collection = database.GetCollection<Laptop>("computer");
            collection.DeleteMany(a => true);
         

        }
    }
} 
