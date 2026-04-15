using Microsoft.EntityFrameworkCore;
using realty_api_practice.Entities.Data;

namespace realty_api_practice.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        //connection to db
        protected readonly ApplicationDbContext _context;
        //represents a table l(like properties, users et)
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;

            //ef dynamically figuers out which table absed on T // ex T=property=> dbset=context.properties
            _dbSet = context.Set<T>();
        }


        //go to this table and return all rows  (like in sql (Select * from table))
        public async Task<List<T>> GetAllAsync()
            => await _dbSet.ToListAsync();


        //find by primary key returns null if found 
       //sql = Select * from Table where id = 5 
        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);


        // add 
        public async Task<T> AddAsync(T entity)
        {
            //ef 2 steps, 1 track changes 2. save changes. 
            await _dbSet.AddAsync(entity); //stage insert 
            await _context.SaveChangesAsync(); //execute sql else/nothign goes 
            return entity;
        }


        //ef marks entity as modified 
        //then pushes to db 
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }


        //if entity doesnt exist, dont crash, 
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            
            if(entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
