using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeOut.DAL;

namespace TakeOut.BLL
{
    public abstract partial class BaseService<T> where T : class, new()
    {
        public IBaseDAL<T> Dal { get; set; }

        //public bool Add(T entity)
        //{
        //    Dal
        //}
    }
}