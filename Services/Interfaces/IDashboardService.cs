using Prueba_viamatica.Models.DTOs.Dashboard;

namespace Prueba_viamatica.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardResumenDto> GetResumenAsync();
    }
}