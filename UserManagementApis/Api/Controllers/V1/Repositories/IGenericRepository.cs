namespace UserManagementApi.Api.Controllers.V1.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task Create(T data);

        Task Update(T data, int id);

        Task Delete(int id);
    }
}
