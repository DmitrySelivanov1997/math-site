﻿using MathSite.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathSite.Db.EntityConfiguration.EntitiesConfigurations
{
	/// <inheritdoc />
	public class UserRightsConfiguration : AbstractEntityConfiguration<UsersRights>
	{
		/// <inheritdoc />
		protected override void SetPrimaryKey(EntityTypeBuilder<UsersRights> modelBuilder)
		{
			modelBuilder
				.HasKey(gr => gr.Id);

		}

		/// <inheritdoc />
		protected override void SetFields(EntityTypeBuilder<UsersRights> modelBuilder)
		{
			modelBuilder
				.Property(gr => gr.Allowed)
				.IsRequired();
		}

		/// <inheritdoc />
		protected override void SetRelationships(EntityTypeBuilder<UsersRights> modelBuilder)
		{
			modelBuilder
				.HasOne(usersRights => usersRights.User)
				.WithMany(user => user.UserRights)
				.HasForeignKey(usersRights => usersRights.UserId)
				.OnDelete(DeleteBehavior.Cascade);
			modelBuilder
				.HasOne(usersRights => usersRights.Right)
				.WithMany(right => right.UsersRights)
				.HasForeignKey(usersRights => usersRights.RightId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}