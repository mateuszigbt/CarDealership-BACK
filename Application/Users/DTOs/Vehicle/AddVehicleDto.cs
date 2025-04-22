using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTOs.Vehicle
{
    public class AddVehicleDto
    {
        public string TypeOffer { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsImported { get; set; }
        public string Vin { get; set; }
        public int Distance { get; set; }
        public string RegistrationNumber { get; set; }
        public string FirstRegistration { get; set; }
        public int YearProduction { get; set; }
        public string BrandVehicle { get; set; }
        public string ModelVehicle { get; set; }
        public string TypeOfFuel { get; set; }
        public int HorsePower { get; set; }
        public int Displacement { get; set; }
        public int Doors { get; set; }
        public string Transmission { get; set; }
        public string Version { get; set; }
        public string Generation { get; set; }
        public string BodyType { get; set; }
        public string[] SourceImages { get; set; }
        public string TitleOffer { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
