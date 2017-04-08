﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathSite.Models
{
	public class PostSettings
	{
		public Guid Id { get; set; }
		public bool? IsCommentsAllowed { get; set; }
		public bool? CanBeRated { get; set; }
		public bool? PostOnStartPage { get; set; }
		public Guid? PostId { get; set; }
		public Post Post { get; set; }
		public Guid? PostTypeId { get; set; }
		public PostType PostType { get; set; }
		public Guid? PreviewImageId { get; set; }
		public File PreviewImage { get; set; }
	}
}
