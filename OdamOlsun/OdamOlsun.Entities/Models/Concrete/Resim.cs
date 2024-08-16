using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdamOlsun.Entities.Models.Abstract;

namespace OdamOlsun.Entities.Models.Concrete
{
    public class Resim: BaseEntity
    {
        public string Url { get; set; }
        public int IlanId { get; set; }
        public Ilan Ilan { get; set; }

    }
}