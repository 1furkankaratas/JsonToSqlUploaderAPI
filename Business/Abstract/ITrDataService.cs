using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITrDataService
    {
        IDataResult<List<TrData>> GetAll();
        IDataResult<TrData> GetbyId(int id);
        IResult Add(TrData data);
        IResult AddAll(List<TrData> datas);
        IResult Delete(TrData data);
        IResult Update(TrData data);
    }
}