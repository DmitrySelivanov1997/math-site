﻿using System;
using System.Collections.Generic;
using System.Linq;
using MathSite.Entities;
using Microsoft.Extensions.Logging;

namespace MathSite.Db.DataSeeding.Seeders
{
	public class FileSeeder : AbstractSeeder<File>
	{
		/// <inheritdoc />
		public FileSeeder(ILogger logger, IMathSiteDbContext context) : base(logger, context)
		{
		}

		/// <inheritdoc />
		public override string SeedingObjectName { get; } = "File";
		
		/// <inheritdoc />
		protected override void SeedData()
		{
			var firstFile = CreateFile(
				"FirstFile",
				DateTime.Now,
				"first file path",
				"first extension",
				GetPersonBySurname("Девяткин"));

			var secondFile = CreateFile(
				"SecondFile",
				DateTime.Now,
				"second file path",
				"second extension",
				GetPersonBySurname("Мокеев"));

			var files = new[]
			{
				firstFile,
				secondFile
			};

			Context.Files.AddRange(files);
		}

		private Person GetPersonBySurname(string surname)
		{
			return Context.Persons.First(person => person.Surname == surname);
		}

		private static File CreateFile(string name, DateTime dateAdded, string filePath, string extension, Person person)
		{
			return new File
			{
				FileName = name,
				DateAdded = dateAdded,
				FilePath = filePath,
				Extension = extension,
				Person = person,
				PostSettings = new List<PostSettings>(),
				PostAttachments = new List<PostAttachment>()
			};
		}
	}
}