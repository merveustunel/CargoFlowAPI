#nullable enable
using CargoFlow.Business.DTOs.Dashboard;
using System.Threading.Tasks;

namespace CargoFlow.Business.Abstract
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}
