using ICar.Data.Intrfaces;
using ICar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars 
        {
            get
            {
                return new List<Car>
                {
                    new Car 
                    {
                        Name = "Tesla Model S",
                        ShortDescription = "Бърз автомобил",
                        LongDescription = "Красив,бърз и много тих автомобил на производителa Tesla",
                        Img = "/img/tesla.jpg",
                        Price = 45000,
                        IsFavorite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
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
                        Category = _categoryCars.AllCategories.Last()
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
                        Category = _categoryCars.AllCategories.Last()
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
                        Category = _categoryCars.AllCategories.Last()
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
                        Category = _categoryCars.AllCategories.First()
                    },
                };
            }
        }
        public IEnumerable<Car> GetFavcars { get; set; }

        public Car objectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
