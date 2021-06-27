using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IItDataService
    {
        IDataResult<List<ItData>> GetAll();
        IDataResult<ItData> GetbyId(int id);
        IResult Add(ItData data);
        IResult AddAll(List<ItData> datas);
        IResult Delete(ItData data);
        IResult Update(ItData data);
    }
}