﻿using System.Net.Mime;
using AuditBridgePlatform.IAM.Domain.Services;
using AuditBridgePlatform.IAM.Interfaces.REST.Resources;
using AuditBridgePlatform.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuditBridgePlatform.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController(IUserCommandService userCommandService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
        await userCommandService.Handle(signUpCommand);
        return Ok(new { message = "User created successfully" });
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
        var authenticatedUser = await userCommandService.Handle(signInCommand);
        var authenticatedUserResource =
            AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user,
                authenticatedUser.token);
        return Ok(authenticatedUserResource);
    }
}