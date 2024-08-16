using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OdamOlsun.Entities.EntityConfig.Abstract;
using OdamOlsun.Entities.Models.Concrete;

namespace OdamOlsun.Entities.EntityConfig.Concrete
{
    public class ResimConfig : BaseConfig<Resim>
    {
        public override void Configure(EntityTypeBuilder<Resim> builder)
        {
            base.Configure(builder);
        }
    }
}