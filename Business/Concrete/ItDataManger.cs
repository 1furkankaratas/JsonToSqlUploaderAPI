using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    [SecuredOperation("user")]
    public class ItDataManger : IItDataService
    {
        private IItDataDal _itDataDal;

        public ItDataManger(IItDataDal itDataDal)
        {
            _itDataDal = itDataDal;
        }

        [CacheAspect]
        public IDataResult<List<ItData>> GetAll()
        {
            return new SuccessDataResult<List<ItData>>(_itDataDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<ItData> GetbyId(int id)
        {
            return new SuccessDataResult<ItData>(_itDataDal.Get(x => x.Id == id));
        }

        [CacheRemoveAspect("IItDataService.Get")]
        [ValidationAspect(typeof(ItDataModelAddValidator))]
        public IResult Add(ItData data)
        {
            var lastData = _itDataDal.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();
            data.Id = lastData.Id + 1;
            _itDataDal.Add(data);

            return new SuccessResult();
        }

        [CacheRemoveAspect("IItDataService.Get")]
        public IResult AddAll(List<ItData> datas)
        {
            foreach (var data in datas)
            {
                _itDataDal.Add(data);
            }

            return new SuccessResult();
        }

        [CacheRemoveAspect("IItDataService.Get")]
        [ValidationAspect(typeof(ItDataModelDeleteValidator))]
        public IResult Delete(ItData data)
        {
            _itDataDal.Delete(data);

            return new SuccessResult();
        }

        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ItDataModelUpdateValidator))]
        public IResult Update(ItData data)
        {
            _itDataDal.Update(data);

            return new SuccessResult();
        }
    }
}