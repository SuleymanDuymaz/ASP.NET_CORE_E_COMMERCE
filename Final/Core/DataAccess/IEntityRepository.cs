using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //********bu katman başka katmanı referans almaz bağımsız olmalı

    //class:referans tip

    //IEntity: IEntity olabilir ve ya IEntity implemente eden bir nesne olabilir.

    //new() : new'lenebilir olmalı

    //generic constraint
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //generic repository pattern

        //getallby category gibi
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
         
        T Get(Expression<Func<T, bool>> filter);
        // List<T> getAllByCategory(int categoryId);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
      
    }
}
