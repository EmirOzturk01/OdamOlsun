using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdamOlsun.Entities.Models.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}