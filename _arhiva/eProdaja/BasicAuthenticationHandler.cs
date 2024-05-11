﻿using eProdaja.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions> {
    public IKorisniciService KorisniciService { get; set; }
    public BasicAuthenticationHandler(IKorisniciService KorisniciService , IOptionsMonitor<AuthenticationSchemeOptions> 
        options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) :
        base(options, logger, encoder, clock) { this.KorisniciService = KorisniciService; }
    
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
        if (!Request.Headers.ContainsKey("Authorization")) {
            return AuthenticateResult.Fail("Missing Authorization header");}

        var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
        var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(":");
        var username = credentials[0];
        var password = credentials[1];

        var user = KorisniciService.Login(username, password);
        if (user == null) return AuthenticateResult.Fail("Missing Authorization header");

        var claims = new List<Claim> {
            new Claim (ClaimTypes.NameIdentifier, username),
            new Claim (ClaimTypes.Name , user.Ime)};

        foreach (var role in user.KorisniciUloges) 
            { claims.Add(new Claim(ClaimTypes.Role, role.Uloga.Naziv)); }

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var pricipal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(pricipal, Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }
}