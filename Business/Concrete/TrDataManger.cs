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
    //[SecuredOperation("user")]
    public class TrDataManger : ITrDataService
    {
        private ITrDataDal _trDataDal;

        public TrDataManger(ITrDataDal trDataDal)
        {
            _trDataDal = trDataDal;
        }

        [CacheAspect]
        public IDataResult<List<TrData>> GetAll()
        {
            return new SuccessDataResult<List<TrData>>(_trDataDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<TrData> GetbyId(int id)
        {
            return new SuccessDataResult<TrData>(_trDataDal.Get(x => x.Id == id));
        }

        [CacheRemoveAspect("ITrDataService.Get")]
        [ValidationAspect(typeof(TrDataModelAddValidator))]
        public IResult Add(TrData data)
        {
            var lastData = _trDataDal.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();
            data.Id = lastData.Id + 1;
            _trDataDal.Add(data);

            return new SuccessResult();
        }

        [CacheRemoveAspect("ITrDataService.Get")]
        public IResult AddAll(List<TrData> datas)
        {
            foreach (var data in datas)
            {
                _trDataDal.Add(data);
            }

            return new SuccessResult();
        }

        [CacheRemoveAspect("ITrDataService.Get")]
        [ValidationAspect(typeof(TrDataModelDeleteValidator))]
        public IResult Delete(TrData data)
        {
            _trDataDal.Delete(data);

            return new SuccessResult();
        }

        [CacheRemoveAspect("ITrDataService.Get")]
        [ValidationAspect(typeof(TrDataModelUpdateValidator))]
        public IResult Update(TrData data)
        {
            _trDataDal.Update(data);

            return new SuccessResult();
        }
    }
}