using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace Ex16
{
    //Необходимо разработать программу для получения информации о товаре из json-файла.
    //Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.

    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxProduct = products[0];
            foreach (Product i in products)
            {
                if (i.PriceProduct > maxProduct.PriceProduct)
                {
                    maxProduct = i;
                }
            }
            //Console.WriteLine($"{maxProduct.CodeProduct} {maxProduct.NameProduct} {maxProduct.PriceProduct}");
            Console.WriteLine("Товар с максимальной ценой:");
            Console.WriteLine("\"Код товара\": {0},", maxProduct.CodeProduct);
            Console.WriteLine("\"Название товара\": \"{0}\",", maxProduct.NameProduct);
            Console.WriteLine("\"Цена товара\": {0}", maxProduct.PriceProduct);
            Console.ReadKey();
        }
    }
    class Product
    {
        [JsonPropertyName("Код товара")]
        public int CodeProduct { get; set; }
        [JsonPropertyName("Название товара")]
        public string NameProduct { get; set; }
        [JsonPropertyName("Цена товара")]
        public decimal PriceProduct { get; set; }
    }
}
