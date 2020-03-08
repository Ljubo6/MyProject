using ICar.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data
{
    public class DbObjects
    {
        
        public static void Initial(AppDbContext context)
        {

               

            if (!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Car.Any())
            {
                context.AddRange(

                     new Car
                     {
                         Name = "Tesla Model S",
                         ShortDescription = "Бърз автомобил",
                         LongDescription = "Красив,бърз и много тих автомобил на производителa Tesla",
                         Img = "/img/tesla.jpg",
                         Price = 45000,
                         IsFavorite = true,
                         Available = true,
                         Category = Categories["Електроавтомобили"]
                     },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDescription = "Тих и спокоен",
                        LongDescription = "Удобен автомобил за градски живот",
                        Img = "/img/fiesta.jpg",
                        Price = 11000,
                        IsFavorite = false,
                        Available = true,
                        Category = Categories["Класически автомобили"]
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        ShortDescription = "Предизвикателен и стилен",
                        LongDescription = "Удобен автомобил за градски живот",
                        Img = "/img/m3.jpg",
                        Price = 65000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Класически автомобили"]
                    },
                    new Car
                    {
                        Name = "Mercedes C class",
                        ShortDescription = "Голям и уютен",
                        LongDescription = "Удобен автомобил за градски живот",
                        Img = "/img/mercedes.jpg",
                        Price = 40000,
                        IsFavorite = false,
                        Available = false,
                        Category = Categories["Класически автомобили"]
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDescription = "Безшумен и икономичен",
                        LongDescription = "Удобен автомобил за градски живот",
                        Img = "/img/nissan.jpg",
                        Price = 14000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Електроавтомобили"]
                    }
                 ); 
            }

            context.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{CategoryName = "Електроавтомобили",Description = "Съвременен вид транспорт"},
                    new Category{CategoryName = "Класически автомобили",Description = "Автомобили с двигатели на вътрешно горене"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.CategoryName,el);
                    }
                }
                return category;
            }
        }
    }
}
