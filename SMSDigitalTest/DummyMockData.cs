using SMSDigitalCodingProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDigitalTest
{
    public class MockData
    {
        public static List<CityDetail> GetAllCities()
        {

            return new List<CityDetail> {

                 new CityDetail()
                {
                    Id = 1,
                    City = "Noida",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Color = "#ff099",
                    Price = 20,
                    Status = "Seldom"
                },
                new CityDetail()
                {
                    Id = 2,
                    City = "Delhi",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Color = "#ff098",
                    Price = 30,
                    Status = "Active"
                },
                new CityDetail()
                {
                    Id = 3,
                    City = "Mumbai",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Color = "#ff5055",
                    Price = (decimal?)22.49,
                    Status = "Yearly"
                }
            };

        }

        // existing code hidden for display purpose
        public static CityDetail NewCity()
        {
            return new CityDetail
            {
                Id = 0,
                City = "Lancai",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Color = "#ff5055",
                Price = (decimal?)22.99,
                Status = "Yearly"
            };
        }
    }
}
