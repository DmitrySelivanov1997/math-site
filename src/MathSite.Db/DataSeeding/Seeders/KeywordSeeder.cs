﻿using System.Collections.Generic;
using MathSite.Entities;
using Microsoft.Extensions.Logging;

namespace MathSite.Db.DataSeeding.Seeders
{
	public class KeywordSeeder : AbstractSeeder<Keywords>
	{
		/// <inheritdoc />
		public KeywordSeeder(ILogger logger, MathSiteDbContext context) : base(logger, context)
		{
		}

		/// <inheritdoc />
		public override string SeedingObjectName { get; } = nameof(Keywords);

		/// <inheritdoc />
		protected override void SeedData()
		{
			var firstKeyword = CreateKeyword("Student", "StudentAlias");
			var secondKeyword = CreateKeyword("Employee", "EmployeeAlias");

			var keywords = new[]
			{
				firstKeyword,
				secondKeyword
			};

			Context.Keywords.AddRange(keywords);
		}

		private static Keywords CreateKeyword(string name, string alias)
		{
			return new Keywords
			{
				Name = name,
				Alias = alias,
				Posts = new List<PostKeywords>()
			};
		}
	}
}