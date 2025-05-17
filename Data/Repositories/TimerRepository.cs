using Microsoft.EntityFrameworkCore;
using SimTimer.Data.DbContexts;
using SimTimer.Models;
using System.Linq.Expressions;

namespace SimTimer.Data.Repositories;

public class TimerRepository : ITimerRepository
{
    private readonly AppDbContext context;

    public TimerRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<TimerModel> AddAsync(TimerModel entity)
    {
        try
        {
            var entry = await context.Timers.AddAsync(entity);
            await context.SaveChangesAsync();
            return entry.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.Timers.FindAsync(id);
        if (entity is null) return false;

        context.Timers.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public Task<List<TimerModel>> GetAllAsync(Expression<Func<TimerModel, bool>>? expression = null) =>
        expression is null ? context.Timers.ToListAsync() : context.Timers.Where(expression).ToListAsync();

    public Task<TimerModel?> GetAsync(Expression<Func<TimerModel, bool>> expression) =>
        context.Timers.FirstOrDefaultAsync(expression);

    public async Task<TimerModel> UpdateAsync(TimerModel entity)
    {
        var entry = context.Timers.Update(entity);
        await context.SaveChangesAsync();
        return entry.Entity;
    }
}
