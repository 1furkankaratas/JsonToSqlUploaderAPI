using Microsoft.AspNetCore.Http;

namespace Entities.Concrete
{
    public class JsonData
    {
        public IFormFile TrDatas { get; set; }
        public IFormFile ItDatas { get; set; }
    }
}