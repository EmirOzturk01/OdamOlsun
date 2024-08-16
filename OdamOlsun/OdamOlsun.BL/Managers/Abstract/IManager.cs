using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdamOlsun.DAL.Repository.Abstract;
using OdamOlsun.Entities.Models.Abstract;

namespace OdamOlsun.BL.Managers.Abstract
{
   public interface IManager<T>:IRepository<T> where T : BaseEntity
    {

    }
}