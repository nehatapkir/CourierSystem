using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDeliveryCost
{
    public enum PackageType
    {
        Small,
        Medium,
        Large,
        XL,       
        NA,
    }

    public static class PackageDetailsUtil
    {      
        public static PackageType GetPackageType(Box box)
        {   
            var dimensions = new List<double>() { box.Length, box.Breadth, box.Height };
           
            if(dimensions.Any(l=> l >= 100))
            {
                return PackageType.XL;
            }
            else if(dimensions.Any(l => l >= 50))
            {
                return PackageType.Large;
            }
            else if (dimensions.Any(l => l >= 10))
            {
                return PackageType.Medium;
            }
            else if (dimensions.All(l => l > 0 && l < 10 ))
            {
                return PackageType.Small;
            }
            return PackageType.NA;
        }
    }
}
