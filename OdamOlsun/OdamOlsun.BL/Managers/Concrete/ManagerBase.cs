using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdamOlsun.BL.Managers.Abstract;
using OdamOlsun.DAL.Repository.Concrete;
using OdamOlsun.Entities.Models.Abstract;

namespace OdamOlsun.BL.Managers.Concrete
{
    public class ManagerBase<T>:Repository<T>, IManager<T> where T : BaseEntity
    {
        
    }
}