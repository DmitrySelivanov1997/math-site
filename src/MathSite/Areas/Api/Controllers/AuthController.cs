﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MathSite.Common.Crypto;
using MathSite.Db;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MathSite.Areas.Api.Controllers
{
	public enum AuthStatus
	{
		Success,
		WrongPassword,
		UserDoesntExists,
		AlreadySignedIn
	}

	public class AuthResult
	{
		public AuthResult(AuthStatus authStatus)
		{
			AuthStatus = authStatus;
		}

		public AuthStatus AuthStatus { get; }
	}

	[Area("Api")]
	public class AuthController : Controller
	{
		private readonly IMathSiteDbContext _dbContext;

		public AuthController(IMathSiteDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		//[HttpPost]
		public async Task<AuthResult> Login(string login, string password)
		{
			if (HttpContext.User.Identity.IsAuthenticated)
				return new AuthResult(AuthStatus.AlreadySignedIn);

			var ourUser = _dbContext.Users
				.Include(user => user.UsersRights)
				.Include(user => user.Group)
					.ThenInclude(group => group.GroupsRights)
					.ThenInclude(rights => rights.Right)
				.FirstOrDefault(u => u.Login == login);

			if (ourUser == null)
				return new AuthResult(AuthStatus.UserDoesntExists);

			if (Passwords.GetHash(password) != ourUser.PasswordHash)
				return new AuthResult(AuthStatus.WrongPassword);

			await HttpContext.Authentication.SignInAsync("Auth", new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
			{
				new Claim("UserId", ourUser.Id.ToString()),
				new Claim("Login", ourUser.Login),
				new Claim("GroupAlias", ourUser.Group.Alias)
			}, "Auth")), new AuthenticationProperties
			{
				ExpiresUtc = DateTime.UtcNow.AddMonths(12)
			});
			return new AuthResult(AuthStatus.Success);
		}
	}
}