using Core.Entities;

namespace Entities.Concrete
{
    public class TrData : IEntity
    {
        public int Id { get; set; }
        public string dc_Zaman { get; set; }
        public string dc_Kategori { get; set; }
        public string dc_Olay { get; set; }
    }
}