using MongoDB.Driver;
using Seyu.Models;
using System;
using System.Collections.Generic;

namespace Seyu
{
    public class DatabaseConnection
    {
        public static List<Laptop> vatanLaptops = new List<Laptop>();
        public static List<Laptop> trendyolLaptops = new List<Laptop>();
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
    }
} 
