﻿using AirSoft.Service.Contracts.Models;

namespace AirSoft.Service.Contracts.Team.Create;

public class CreateTeamRequest
{
    public CreateTeamRequest(string title, string? city, DateTime? foundationDate, byte[]? avatar)
    {
        Title = title;
        City = city;
        FoundationDate = foundationDate;
        Avatar = avatar;
    }

    public string Title { get; set; }

    public string? City { get; }

    public DateTime? FoundationDate { get; }

    public byte[]? Avatar { get; }
}