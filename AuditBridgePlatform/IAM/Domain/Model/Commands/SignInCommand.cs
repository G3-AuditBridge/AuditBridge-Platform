﻿namespace AuditBridgePlatform.IAM.Domain.Model.Commands;

public record SignInCommand(string Username, string Password);