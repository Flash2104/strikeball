﻿using AirSoft.Service.Contracts;
using AirSoft.Service.Contracts.Member;
using AirSoft.Service.Contracts.Member.Get;
using AirSoft.Service.Contracts.Member.Update;
using AirSoft.Service.Contracts.Team;
using AirSoft.Service.Contracts.Team.GetCurrent;
using AirSoftApi.AuthPolicies;
using AirSoftApi.Models;
using AirSoftApi.Models.Member;
using AirSoftApi.Models.Member.GetCurrent;
using AirSoftApi.Models.Member.Update;
using AirSoftApi.Models.Team.GetCurrent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirSoftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeamController : RootController
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITeamService _teamService;
        private readonly ICorrelationService _correlationService;

        public TeamController(ILogger<TeamController> logger, ITeamService teamService, ICorrelationService correlationService) : base(logger)
        {
            _logger = logger;
            _teamService = teamService;
            _correlationService = correlationService;
        }

        [HttpGet("get-current")]
        [Authorize]
        public async Task<ServerResponseDto<GetCurrentTeamResponseDto>> GetCurrent()
        {
            var logPath = $"{_correlationService.GetUserId()}.{nameof(TeamController)} {nameof(GetCurrent)} | ";
            return await HandleRequest(
                _teamService.GetCurrent,
                res => new GetCurrentTeamResponseDto(res.TeamData),
                logPath
            );
        }
    }
}
