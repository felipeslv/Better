﻿using System.Collections.Generic;

namespace Better.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class 
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
