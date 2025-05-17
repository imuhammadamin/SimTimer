using ActualLab.DependencyInjection;
using ActualLab.Fusion;
using SimTimer.Models;
using System.Linq.Expressions;

namespace SimTimer.Services;

public interface ITimerServices// : IComputeService
{
    Task<TimerModel> AddAsync(TimerModel entity);
    //[ComputeMethod]
    Task<TimerModel?> GetAsync(Expression<Func<TimerModel, bool>> expression);
    //[ComputeMethod]
    Task<List<TimerModel>> GetAllAsync(Expression<Func<TimerModel, bool>>? expression = null);
    Task<bool> DeleteAsync(int id);
    Task<TimerModel> UpdateAsync(TimerModel entity);
}
