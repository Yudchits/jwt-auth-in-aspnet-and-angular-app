namespace Marketplace.Logic.Common.Models
{
    public class CarBLL
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Generation { get; set; }
        public string Photo { get; set; }
        public EngineBLL Engine { get; set; }
    }
}