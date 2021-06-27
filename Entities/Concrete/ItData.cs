using Core.Entities;

namespace Entities.Concrete
{
    public class ItData: IEntity
    {
        public int Id { get; set; }
        public string dc_Orario { get; set; }
        public string dc_Categoria { get; set; }
        public string dc_Evento { get; set; }
    }
}