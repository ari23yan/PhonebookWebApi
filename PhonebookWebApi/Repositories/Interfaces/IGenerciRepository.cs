using PhonebookWebApi.Data.Entities;

namespace PhonebookWebApi.Repositories.Interfaces
{
    public interface IGenerciRepository<T> 
    {
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(T model);
    }
}
