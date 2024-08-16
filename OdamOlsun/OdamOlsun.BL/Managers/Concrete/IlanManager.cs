using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdamOlsun.BL.Managers.Abstract;
using OdamOlsun.Entities.Models.Concrete;

namespace OdamOlsun.BL.Managers.Concrete
{
    
    public class IlanManager:ManagerBase<Ilan>,IIlanManager
    {
    }
}