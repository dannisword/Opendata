using Opendata.Models;
using Opendata.Entities;

namespace Opendata.Services
{
    public interface ITDXService
    {
        Task HandleDailyTimetable();
    }
}