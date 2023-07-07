﻿namespace InventoryManagementSystem.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int entity);
    }
}
