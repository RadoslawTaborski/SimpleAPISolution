using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models;

namespace SimpleAPI.Repositories;

public class StatusRepository : IDisposable, IStatusRepository
{
    private readonly TestContext _context;

    public StatusRepository(TestContext context)
    {
        this._context = context;
    }

    public async Task<Status?> Get(int id)
    {
        return await _context.Statuses.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<(IEnumerable<Status> Collection, int Size)> Get()
    {
        IEnumerable<Status> collection = await _context.Statuses.ToListAsync();

        return (collection, collection.Count());
    }

    public async Task<Status> Add(Status element)
    {
        _context.Statuses.Add(element);
        await _context.SaveChangesAsync();

        return element;
    }

    public async Task<Status> Update(Status element)
    {
        _context.Entry(element).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return element;
    }

    public async Task<bool> DeleteItem(Status entity)
    {
        _context.Statuses.Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Exists(byte[] uuid)
    {
        var entity = await _context.Statuses.FindAsync(uuid);
        return entity != null;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(!disposing)
            return;
        _context.Dispose();
    }

    ~StatusRepository()
    {
        Dispose(false);
    }
}