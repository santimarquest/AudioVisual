﻿using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository<T> where T : IInt32Identity
    {
        IList<T> GetAll();

        T GetById(int id);

        void Save(T saveThis);

        void Delete(T deleteThis);
    }
}