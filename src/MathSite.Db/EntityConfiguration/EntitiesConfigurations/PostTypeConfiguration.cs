﻿using MathSite.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathSite.Db.EntityConfiguration.EntitiesConfigurations
{
	/// <inheritdoc />
	public class PostTypeConfiguration : AbstractEntityConfiguration<PostType>
	{
		protected override string TableName { get; } = nameof(PostType);

		/// <inheritdoc />
		protected override void SetKeys(EntityTypeBuilder<PostType> modelBuilder)
		{
			modelBuilder
				.HasKey(postType => postType.TypeName);
		}

		/// <inheritdoc />
		protected override void SetFields(EntityTypeBuilder<PostType> modelBuilder)
		{
			modelBuilder
				.Property(postType => postType.TypeName)
				.IsRequired();
		}

		/// <inheritdoc />
		protected override void SetRelationships(EntityTypeBuilder<PostType> modelBuilder)
		{
			modelBuilder
				.HasMany(postType => postType.Posts)
				.WithOne(posts => posts.PostType)
				.HasForeignKey(postType => postType.PostTypeName)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder
				.HasOne(postType => postType.DefaultPostsSettings)
				.WithOne(defaultPostsSettings => defaultPostsSettings.PostType)
				.HasForeignKey<PostSetting>(defaultPostsSettings => defaultPostsSettings.PostTypeName)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		}

		protected override void SetIndexes(EntityTypeBuilder<PostType> modelBuilder)
		{
		}
	}
}