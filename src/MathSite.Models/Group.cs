﻿using System;
using System.Collections.Generic;

namespace MathSite.Models
{
	public class Group
	{
		public Guid Id { get; set; }
		public string Alias { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual List<GroupsRights> GroupsRights { get; set; }
		public virtual List<User> Users { get; set; }
	}
}