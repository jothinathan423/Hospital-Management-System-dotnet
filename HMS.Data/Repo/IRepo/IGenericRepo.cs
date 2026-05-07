using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Data.Repo.IRepo
{
    public interface IGenericRepo<T> where T : class

    {

        Task<T> AddAsync(T entity);

        Task<List<T>> GetAllAsync();

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);



    }
}
