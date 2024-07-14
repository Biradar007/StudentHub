using SH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.BusinessLayer
{
    public partial class SHBusiness
    {
        public List<LocationVM> Location()
        {
            List<LocationVM> locations = new List<LocationVM>();
            locations.AddRange(new LocationVM[] {

                new LocationVM()
                {
                    States = "California",
                    Cities = new List<string> { "Los Angeles", "San Francisco" }
                },
                 new LocationVM()
                {
                    States = "Texas",
                    Cities = new List<string> { "Houston", "Austin" }
                },
                  new LocationVM()
                {
                    States = "New York",
                    Cities = new List<string> { "New York City", "Buffalo" }
                },
                   new LocationVM()
                {
                    States = "Florida",
                    Cities = new List<string> { "Miami", "Orlando" }
                },
                     new LocationVM()
                {
                    States = "Illinois",
                    Cities = new List<string> { "Chicago", "Springfield" }
                }
            });
            return locations;
        }
    }
}
