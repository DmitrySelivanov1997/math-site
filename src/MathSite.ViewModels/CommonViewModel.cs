﻿using System;
using System.Collections.Generic;
using MathSite.ViewModels.SharedModels;

namespace MathSite.ViewModels
{
	public abstract class CommonViewModel
	{
		public PageTitleViewModel PageTitle { get; set; }
		public string Description { get; set; }
		public string Keywords { get; set; }
		public IEnumerable<MenuItemViewModel> MenuItems { get; set; } = new List<MenuItemViewModel>();

		public Tuple<IEnumerable<MenuItemViewModel>, IEnumerable<MenuItemViewModel>, IEnumerable<MenuItemViewModel>, IEnumerable<MenuItemViewModel>> FooterMenus { get; set; }
	}
}