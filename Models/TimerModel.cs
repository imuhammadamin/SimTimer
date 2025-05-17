using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimTimer.Models;

public class TimerModel
{
    [Key]
    public long Id { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsActive { get; set; }
    public bool IsPaused { get; set; }
    public TimeSpan ElapsedTime { get; set; }
    public TimeSpan RemainingTime => Duration - ElapsedTime;
}
