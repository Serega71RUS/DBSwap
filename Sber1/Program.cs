using Sber1.Models;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Sber1
{
    class Program
    {
        public static string Server(string json)
        {
            Auto CarList = JsonConvert.DeserializeObject<Auto>(json);
            //foreach (var item in CarList)
            //{
                Console.WriteLine($"{CarList.Manufacturer}, {CarList.Model}, {CarList.HP}, {CarList.Date}");
                Seller s;
                switch (CarList.Manufacturer)
                {
                    case "Lada":
                        s = new Seller { Salon = "Lada", Street = "Pr.Lenina", House = "25A", Price = 700000 };
                        break;
                    case "Nissan":
                        s = new Seller { Salon = "Lada", Street = "Sovetskaya", House = "42", Price = 1552000 };
                        break;
                    case "Toyota":
                        s = new Seller { Salon = "Lada", Street = "Oktabrskaya", House = "195", Price = 1245000 };
                        break;
                    default:
                        s = new Seller { Salon = "NaN", Street = "NaN", House = "NaN", Price = 0 };
                        break;
                }
                var newjson = JsonConvert.SerializeObject(s);
                return newjson;
            //}
            //return null;
        }
        static void Main(string[] args)
        {
            using var db = new DbCont();
            //var name = db.car.Select(c => c.Model).FirstOrDefault();
            var name = from auto in db.auto
                       select auto;
                       //select new { auto.Manufacturer, auto.Model, auto.HP, auto.Date };
            Console.WriteLine(name);
            var json = JsonConvert.SerializeObject(name);
            Console.WriteLine(json);
            string path = @"text.json";
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(json);
            }
            Console.WriteLine("Ok!");
            List<Auto> CarList = JsonConvert.DeserializeObject<List<Auto>>(json);
            foreach(var item in CarList)
            {
                Console.WriteLine($"{item.Manufacturer}, {item.Model}, {item.HP}, {item.Date}");
                var newjson = JsonConvert.SerializeObject(item);
                var newjs = Server(newjson);
                Seller Sel = JsonConvert.DeserializeObject<Seller>(newjs);
                Console.WriteLine($"{Sel.Salon}, {Sel.Street}, {Sel.House}, {Sel.Price}");
                //string sql = $"insert into car values(nextval('caridseq'), '"+car.manufacturer+"', '"+car.model+"')";
                Console.WriteLine(db.seller.Add(new Seller 
                { 
                    Salon = Sel.Salon, 
                    Street = Sel.Street, 
                    House = Sel.House,
                    Price = Sel.Price
                }).State);
                db.SaveChanges();
            }

        }
    }
}
