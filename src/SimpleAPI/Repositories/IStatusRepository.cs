using SimpleAPI.Models;

namespace SimpleAPI.Repositories
{
    public interface IStatusRepository
    {
        Task<Status?> Get(int id);
        Task<(IEnumerable<Status> Collection, int Size)> Get();
        Task<Status> Add(Status element);
        Task<Status> Update(Status element);
        Task<bool> DeleteItem(Status entity);
        Task<bool> Exists(byte[] uuid);
    }
}