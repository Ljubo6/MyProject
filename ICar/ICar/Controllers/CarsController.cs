using ICar.Data.Intrfaces;
using ICar.Data.Models;
using ICar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars,ICarsCategory iCarsCategory)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCategory;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars
                        .Where(i => i.Category.CategoryName.Equals("Електроавтомобили"))
                        .OrderBy(i => i.Id);
                    currentCategory = "Електроавтомобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars
                        .Where(i => i.Category.CategoryName.Equals("Класически автомобили"))
                        .OrderBy(i => i.Id);
                    currentCategory = "Класически автомобили";
                }

                


            }

            var carObject = new CarsListViewModel
            {
                AllCars = cars,
                CarCategory = currentCategory
            };
            ViewBag.Title = "Страница с автомобили";

            return View(carObject);
        }
    }
}
