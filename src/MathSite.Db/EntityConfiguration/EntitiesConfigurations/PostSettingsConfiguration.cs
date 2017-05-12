﻿using MathSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MathSite.Db.EntityConfiguration.EntitiesConfigurations
{
	public class PostSettingsConfiguration : AbstractEntityConfiguration
	{
		/// <inheritdoc />
		protected override void SetPrimaryKey(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PostSettings>()
				.HasKey(postSettings => postSettings.Id);
		}

		/// <inheritdoc />
		protected override void SetFields(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PostSettings>()
				.Property(postSettings => postSettings.IsCommentsAllowed)
				.IsRequired(false);

			modelBuilder.Entity<PostSettings>()
				.Property(postSettings => postSettings.CanBeRated)
				.IsRequired(false);

			modelBuilder.Entity<PostSettings>()
				.Property(postSettings => postSettings.PostOnStartPage)
				.IsRequired(false);
		}

		/// <inheritdoc />
		protected override void SetRelationships(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PostSettings>()
				.HasOne(postSettings => postSettings.PostType)
				.WithOne(postType => postType.DefaultPostsSettings)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<PostSettings>()
				.HasOne(postSettings => postSettings.Post)
				.WithOne(post => post.PostSettings)
				.HasForeignKey<Post>(post => post.PostSettingsId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<PostSettings>()
				.HasOne(postSettings => postSettings.PreviewImage)
				.WithMany(previewImage => previewImage.PostSettings)
				.HasForeignKey(postSettings => postSettings.PreviewImageId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Cascade);
		}

		/// <inheritdoc />
		public override string ConfigurationName { get; } = "PostSettings";
	}
}