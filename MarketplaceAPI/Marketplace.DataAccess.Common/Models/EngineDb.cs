using System.Collections.Generic;

namespace Marketplace.DataAccess.Common.Models
{
    public class EngineDb
    {
        public int Id { get; set; }
        public string FuelType { get; set; }
        public double Capacity { get; set; }
        public int Power { get; set; }
        public IEnumerable<CarDb> Cars { get; set; }
    }
}