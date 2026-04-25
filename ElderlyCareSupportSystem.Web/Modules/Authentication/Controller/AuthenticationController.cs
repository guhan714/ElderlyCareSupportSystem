using System.Security.Claims;
using ElderlyCareSupportSystem.Application.Extensions;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Application.Modules.Authentication.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElderlyCareSupportSystem.Web.Modules.Authentication.Controller;

[AllowAnonymous]
public class AuthenticationController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IValidator<LoginViewModel> _loginValidator;
    private readonly IAuthService _authenticationService;

    public AuthenticationController(IValidator<LoginViewModel> loginValidator, IAuthService authenticationService)
    {
        _loginValidator = loginValidator;
        _authenticationService = authenticationService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([FromBody] LoginViewModel loginDetails)
    {
        var validation = await _loginValidator.ValidateAsync(loginDetails);
        if (!validation.IsValid)
            return BadRequest(new JsonResult(new
                { success = false, messages = validation.Errors.Select(a => a.ErrorMessage) }));

        var authenticationResult = await _authenticationService.LoginAsync(loginDetails);

        if (!authenticationResult.IsSuccess)
            return Json(new { success = authenticationResult.IsSuccess, message = authenticationResult.Message });

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, authenticationResult.Data.Id.ToString()),
            new Claim(ClaimTypes.Email, authenticationResult.Data.Email),
            new Claim(ClaimTypes.Role, authenticationResult.Data.Role)
        };

        var identity = new ClaimsIdentity(claims, "ElderlyCareSupportCookie");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("ElderlyCareSupportCookie", principal);

        return Json(new { success = true, url = Url.Action("Index", "Home") });
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword([FromQuery] string userName)
    {
        if (userName.IsNullOrWhiteSpace())
            return BadRequest(new { message = "Username should not be empty"});

        return Json(new { success = true });
    }
}