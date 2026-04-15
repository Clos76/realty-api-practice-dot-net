namespace realty_api_practice.Repositories
{

    //basic crud operations
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(); //Select * from Table
        Task<T?> GetByIdAsync(int id); // select * from Table where id
        Task<T> AddAsync(T entity); //insert into table
        Task UpdateAsync(T entity); //update table
        Task DeleteAsync(int id); // delete from table where id 
    }
}
