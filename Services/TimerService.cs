using ActualLab.DependencyInjection;
using ActualLab.Fusion;
using Microsoft.EntityFrameworkCore;
using SimTimer.Data.Repositories;
using SimTimer.Models;
using System.Linq.Expressions;

namespace SimTimer.Services;

public class TimerService : ITimerService
{
    private readonly ITimerRepository timerRepository;

    public TimerService(ITimerRepository timerRepository)
    {
        this.timerRepository = timerRepository;
    }

    public Task<TimerModel> AddAsync(TimerModel entity) =>
        timerRepository.AddAsync(entity);

    public Task<bool> DeleteAsync(int id) =>
        timerRepository.DeleteAsync(id);

    //[ComputeMethod]
    public virtual async Task<List<TimerModel>> GetAllAsync(Expression<Func<TimerModel, bool>>? expression = null) =>
        (await timerRepository.GetAllAsync(expression)).OrderByDescending(x => x.Id).ToList();

    //[ComputeMethod]
    public virtual Task<TimerModel?> GetAsync(Expression<Func<TimerModel, bool>> expression) =>
        timerRepository.GetAsync(expression);

    public Task<TimerModel> UpdateAsync(TimerModel entity) =>
        timerRepository.UpdateAsync(entity);
}
