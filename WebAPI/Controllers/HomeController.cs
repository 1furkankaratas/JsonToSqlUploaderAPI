using System.Collections.Generic;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Business.Abstract;
using Microsoft.Extensions.Localization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IJsonService _jsonService;
        private ITrDataService _trDataService;
        private IItDataService _itDataService;
        private IStringLocalizer<HomeController> _localizer;


        public HomeController(IJsonService jsonService, ITrDataService trDataService, IItDataService itDataService, IStringLocalizer<HomeController> localizer)
        {
            _jsonService = jsonService;
            _trDataService = trDataService;
            _itDataService = itDataService;
            _localizer = localizer;
        }

        [HttpPost]
        public IActionResult AddJsonFiles([FromForm] JsonData data)
        {
            List<TrData> trDatas = _jsonService.SaveToDatabaseTrDatas(data.TrDatas).Result.Data;
            List<ItData> itDatas = _jsonService.SaveToDatabaseItDatas(data.ItDatas).Result.Data;



            _itDataService.AddAll(itDatas);
            _trDataService.AddAll(trDatas);



            return Ok("test");
        }

        [HttpPost]
        public IActionResult Add([FromBody]DataModel data)
        {

            _itDataService.Add(data.ItData);
            _trDataService.Add(data.TrData);



            return Ok("test");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] DataModel data)
        {

            _itDataService.Delete(data.ItData);
            _trDataService.Delete(data.TrData);



            return Ok("test");
        }

        [HttpPut]
        public IActionResult Update([FromBody] DataModel data)
        {

            _itDataService.Update(data.ItData);
            _trDataService.Update(data.TrData);



            return Ok("test");
        }

        [HttpGet]
        public IActionResult GetById([FromQuery] string culture, [FromQuery] int id)
        {
            if (culture != null)
            {
                switch (culture)
                {
                    case "tr-TR":
                        return Ok(_trDataService.GetbyId(id));

                    case "it-IT":
                        return Ok(_itDataService.GetbyId(id));
                    default:
                        return Ok(_trDataService.GetbyId(id));
                }
            }
            else
            {
                return Ok(_trDataService.GetbyId(id));
            }

        }

        [HttpGet]
        public IActionResult Test([FromQuery] int id)
        {
            var trdata = _localizer["data",id];


            return Ok();
        }



        [HttpGet]
        public IActionResult GetAll([FromQuery] string culture)
        {
            if (culture != null)
            {
                switch (culture)
                {
                    case "tr-TR":
                        return Ok(_trDataService.GetAll());

                    case "it-IT":
                        return Ok(_itDataService.GetAll());
                    default:
                        return Ok(_trDataService.GetAll());
                }
            }
            else
            {
                return Ok(_trDataService.GetAll());
            }
        }
        
    }
}