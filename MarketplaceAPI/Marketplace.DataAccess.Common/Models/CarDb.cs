namespace Marketplace.DataAccess.Common.Models
{
    public class CarDb
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Generation { get; set; }
        public string Photo { get; set; }
        public int? EngineId { get; set; }
        public virtual EngineDb Engine { get; set; }
    }
}