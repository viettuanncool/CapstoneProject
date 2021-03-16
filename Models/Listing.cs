using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class Listing
    {
        public int HouseId { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string Province { get;set; }
        public int BedroomNum { get; set; }
        public int BathroomNum { get; set; }
        public int Storey { get; set; }
        public double LandWidth { get; set; }
        public double LandLength { get; set; }
        public double AnnualPropertyTaxes { get; set; }
        public Boolean BasementFinished { get; set; }
        public string Style { get; set; }
        public double Price { get; set; }
        public string Cooling { get; set; }
        public string Heating { get; set; }
        public string ParkingStyle { get; set; }
        public int ParkingSpace { get; set; }
        public string Pictures { get; set; }
        public bool Status { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
