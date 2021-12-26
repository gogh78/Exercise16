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
    //Разработать класс для моделирования объекта «Товар».
    //Предусмотреть члены класса «Код товара» (целое число),
    //«Название товара» (строка), «Цена товара» (вещественное число).
    //Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
    //Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».

    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");

                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                products[i] = new Product()
                {
                    NameProduct = name,
                    CodeProduct = code,
                    PriceProduct = price
                };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);
            //Console.WriteLine(jsonString);
            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
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
