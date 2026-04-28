using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Interfaces;

namespace WorkoutTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    // Wstrzykujemy interfejs
    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("stats")]
    public async Task<ActionResult> GetGeneralStats()
    {
        var stats = await _dashboardService.GetGeneralStatsAsync();
        return Ok(stats);
    }
}