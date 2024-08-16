using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OdamOlsun.Entities.Models.Abstract;

namespace OdamOlsun.Entities.Models.Concrete
{
    public class Ilan : BaseEntity
    {
        public string Title { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public int Deposit { get; set; }
        public string Address { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloorOfBuild { get; set; }
        public int FloorOfHouse { get; set; }
        public int AgeOfBuild { get; set; }
        public bool Furnished { get; set; }
        public bool Cigarette { get; set; }
        public bool Animal { get; set; }
        public string? RoomAndHomeDetails { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Semt { get; set; }
        public ICollection<Resim> Resims { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}