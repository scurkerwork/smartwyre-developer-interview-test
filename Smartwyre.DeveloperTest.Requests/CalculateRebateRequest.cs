﻿using Smartwyre.DeveloperTest.Enums;

namespace Smartwyre.DeveloperTest.Requests;


public class CalculateRebateRequest
{
    public string? RebateIdentifier { get; set; }
    public string? ProductIdentifier { get; set; }
    public decimal Volume { get; set; }

    public IncentiveType? IncentiveType { get; set; } = null;
}
