using ICar.Data.Intrfaces;
using ICar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName = "Електроавтомобили",Description = "Съвременен вид транспорт"},
                    new Category{CategoryName = "Класически автомобили",Description = "Автомобили с двигатели на вътрешно горене"}

                };
            }
        }

    }
}
