﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MathSite.BasicAdmin.ViewModels.SharedModels;
using MathSite.BasicAdmin.ViewModels.SharedModels.Menu;
using MathSite.Controllers;
using MathSite.Db.DataSeeding.StaticData;
using MathSite.Facades.SiteSettings;
using MathSite.Facades.UserValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathSite.Areas.Manager.Controllers
{
	[Area("manager"), Authorize("admin")]
	public class HomeController : BaseController
	{
		private readonly ISiteSettingsFacade _siteSettingsFacade;

		public HomeController(IUserValidationFacade userValidationFacade, ISiteSettingsFacade siteSettingsFacade) : base(userValidationFacade)
		{
			_siteSettingsFacade = siteSettingsFacade;
		}

		public async Task<IActionResult> Index()
		{
			return View(new AdminPageBaseViewModel(
				new PageTitleViewModel(
					"Dashboard",
					await _siteSettingsFacade[SiteSettingsNames.TitleDelimiter],
					await _siteSettingsFacade[SiteSettingsNames.SiteName]
				),
				new List<MenuLink>
				{
					new MenuLink("Dashboard", "/manager", true),
					new MenuLink("Статьи", "/manager", false),
					new MenuLink("Новости", "/manager/news", false),
					new MenuLink("Файлы", "/manager", false),
					new MenuLink("Пользователи", "/manager", false),
					new MenuLink("Настройки", "/manager", false),
				}
			));
		}
	}
}