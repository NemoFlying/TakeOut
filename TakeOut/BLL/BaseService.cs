using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeOut.DAL;

namespace TakeOut.BLL
{
    public abstract partial class BaseService<T> where T : class, new()
    {
        public IBaseDAL<T> _dAL { get; set; }

        //public bool Add(T entity)
        //{
        //    Dal
        //}

        //public bool DeleteModlesByIds(List<int> Ids)
        //{
        //    Ids.ForEach(id =>
        //    {
        //        T.Delete(
        //            _userDAL.GetModels(con => con.Id == id)
        //            .FirstOrDefault()
        //            );
        //    });
        //    try
        //    {
        //        return _userDAL.SaveChanges();
        //    }
        //    catch
        //    {
        //        //日志记录
        //        return false;
        //    }
        //}

    }
}