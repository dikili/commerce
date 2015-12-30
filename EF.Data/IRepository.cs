using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EF.Data
{
    public interface IRepository<T> where T: class
    {
        bool Save(T Entity);
        IQueryable<T> GetAll();
        T GetById(int Id);
    }
}