using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IJsonService
    {
        Task<IDataResult<List<TrData>>> SaveToDatabaseTrDatas(IFormFile jsonData);
        Task<IDataResult<List<ItData>>> SaveToDatabaseItDatas(IFormFile jsonData);
    }
}