using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Data.Entity.ModelConfiguration;
using CarManager.Data.Domain;

namespace CarManager.Data.Mapping
{
    public class CarMap:EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.CarName).HasMaxLength(100).IsRequired();
        }
    }
}
