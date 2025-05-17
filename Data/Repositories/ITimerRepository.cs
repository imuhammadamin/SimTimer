using SimTimer.Models;
using System.Linq.Expressions;

namespace SimTimer.Data.Repositories;

public interface ITimerRepository
{
    Task<TimerModel> AddAsync(TimerModel entity);
    Task<List<TimerModel>> GetAllAsync(Expression<Func<TimerModel, bool>>? expression = null);
    Task<TimerModel?> GetAsync(Expression<Func<TimerModel, bool>> expression);
    Task<bool> DeleteAsync(int id);
    Task<TimerModel> UpdateAsync(TimerModel entity);
}
