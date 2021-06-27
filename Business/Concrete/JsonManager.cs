using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    [SecuredOperation("user")]
    [ValidationAspect(typeof(JsonValidator))]
    public class JsonManager : IJsonService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public JsonManager(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task<IDataResult<List<TrData>>> SaveToDatabaseTrDatas(IFormFile jsonData)
        {
            dynamic o;
            var serializer = new Newtonsoft.Json.JsonSerializer();
            string dir = _hostingEnvironment.WebRootPath;
            string fileName = "tr";
            string extension = Path.GetExtension(jsonData.FileName);
            fileName = fileName + extension;
            string savePath = Path.Combine(dir, fileName);


            List<TrData> datas = new List<TrData>();


            using (var stream = System.IO.File.Create(savePath))
            {
                await jsonData.CopyToAsync(stream);
            }

            using (FileStream s = System.IO.File.Open(savePath, FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        TrData data = new TrData();
                        o = serializer.Deserialize(reader);
                        data.Id = o["ID"];
                        data.dc_Kategori = o["dc_Kategori"];
                        data.dc_Zaman = o["dc_Zaman"];
                        data.dc_Olay = o["dc_Olay"];
                        datas.Add(data);
                    }
                }
            }

            return new SuccessDataResult<List<TrData>>(datas);

        }

        public async Task<IDataResult<List<ItData>>> SaveToDatabaseItDatas(IFormFile jsonData)
        {
            dynamic o;
            var serializer = new Newtonsoft.Json.JsonSerializer();
            string dir = _hostingEnvironment.WebRootPath;
            string fileName = "it";
            string extension = Path.GetExtension(jsonData.FileName);
            fileName = fileName + extension;
            string savePath = Path.Combine(dir, fileName);


            List<ItData> datas = new List<ItData>();

            using (var stream = System.IO.File.Create(savePath))
            {
                await jsonData.CopyToAsync(stream);
            }
            using (FileStream s = System.IO.File.Open(savePath, FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        ItData data = new ItData();
                        o = serializer.Deserialize(reader);
                        data.Id = o["ID"];
                        data.dc_Categoria = o["dc_Categoria"];
                        data.dc_Evento = o["dc_Evento"];
                        data.dc_Orario = o["dc_Orario"];
                        datas.Add(data);
                    }
                }
            }

            return new SuccessDataResult<List<ItData>>(datas);
        }
    }
}