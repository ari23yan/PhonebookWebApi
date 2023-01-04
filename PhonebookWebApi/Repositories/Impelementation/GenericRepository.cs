using Microsoft.EntityFrameworkCore;
using PhonebookWebApi.Data.Context;
using PhonebookWebApi.Repositories.Interfaces;

namespace PhonebookWebApi.Repositories.Impelementation
{
    public class GenericRepository<T> : IGenerciRepository<T> where T : class
    {
        private readonly PhoneBookWebApiDbContext _Context;
        private DbSet<T> entities;
        public GenericRepository(PhoneBookWebApiDbContext Context)
        {
            _Context = Context;
            entities = _Context.Set<T>();
        }

        public async Task AddAsync(T model)
        {
            if (model != null)
                entities.Add(model);
            await SaveChange();
        }


        public async Task UpdateAsync(T model)
        {
            if (model != null)
                entities.Update(model);
                await SaveChange();
        }
        public async Task SaveChange()
        {
            await _Context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T model)
        {
            if (model != null)
                entities.Remove(model);
            await SaveChange();
        }
    }
}
