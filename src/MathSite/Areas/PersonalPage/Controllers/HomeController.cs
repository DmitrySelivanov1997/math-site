﻿using MathSite.Controllers;
using MathSite.Facades.Users;
using MathSite.Facades.UserValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathSite.Areas.PersonalPage.Controllers
{
    [Area("personal-page")]
    [Authorize("peronal-page")]
    public class HomeController : BaseController
    {
        public HomeController(IUserValidationFacade userValidationFacade, IUsersFacade usersFacade)
            : base(userValidationFacade, usersFacade)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}