﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MathSite.Db;

namespace MathSite.Migrations
{
    [DbContext(typeof(MathSiteDbContext))]
    partial class MathSiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("MathSite.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Alias");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MathSite.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Edited");

                    b.Property<Guid>("PostId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MathSite.Entities.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Extension");

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<string>("FilePath")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("MathSite.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<string>("Description");

                    b.Property<Guid>("GroupTypeId");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentGroupId");

                    b.HasKey("Id");

                    b.HasIndex("GroupTypeId");

                    b.HasIndex("ParentGroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MathSite.Entities.GroupsRights", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<Guid>("GroupId");

                    b.Property<Guid>("RightId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("RightId");

                    b.ToTable("GroupsRights");
                });

            modelBuilder.Entity("MathSite.Entities.GroupType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("GroupTypes");
                });

            modelBuilder.Entity("MathSite.Entities.Keywords", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Alias");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("MathSite.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalPhone");

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<Guid?>("PhotoId");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MathSite.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Excerpt")
                        .IsRequired();

                    b.Property<Guid>("PostSeoSettingsId");

                    b.Property<Guid>("PostSettingsId");

                    b.Property<Guid>("PostTypeId");

                    b.Property<DateTime>("PublishDate");

                    b.Property<bool>("Published");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostSeoSettingsId")
                        .IsUnique();

                    b.HasIndex("PostSettingsId")
                        .IsUnique();

                    b.HasIndex("PostTypeId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MathSite.Entities.PostAttachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<Guid>("FileId");

                    b.Property<Guid>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("PostId");

                    b.ToTable("PostAttachments");
                });

            modelBuilder.Entity("MathSite.Entities.PostCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<Guid>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("MathSite.Entities.PostGroupsAllowed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<Guid?>("GroupId");

                    b.Property<Guid?>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("PostId");

                    b.ToTable("PostGroupsAlloweds");
                });

            modelBuilder.Entity("MathSite.Entities.PostKeywords", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("KeywordId");

                    b.Property<Guid>("PostSeoSettingsId");

                    b.HasKey("Id");

                    b.HasIndex("KeywordId");

                    b.HasIndex("PostSeoSettingsId");

                    b.ToTable("PostKeywords");
                });

            modelBuilder.Entity("MathSite.Entities.PostOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PostId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostOwners");
                });

            modelBuilder.Entity("MathSite.Entities.PostRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<Guid>("PostId");

                    b.Property<Guid>("UserId");

                    b.Property<bool?>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostRatings");
                });

            modelBuilder.Entity("MathSite.Entities.PostSeoSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("PostSeoSettings");
                });

            modelBuilder.Entity("MathSite.Entities.PostSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("CanBeRated");

                    b.Property<bool?>("IsCommentsAllowed");

                    b.Property<bool?>("PostOnStartPage");

                    b.Property<Guid>("PostTypeId");

                    b.Property<Guid?>("PreviewImageId");

                    b.HasKey("Id");

                    b.HasIndex("PostTypeId")
                        .IsUnique();

                    b.HasIndex("PreviewImageId");

                    b.ToTable("PostSettings");
                });

            modelBuilder.Entity("MathSite.Entities.PostType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("PostTypes");
                });

            modelBuilder.Entity("MathSite.Entities.PostUserAllowed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<Guid>("PostId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostUserAlloweds");
                });

            modelBuilder.Entity("MathSite.Entities.Right", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Alias");

                    b.ToTable("Rights");
                });

            modelBuilder.Entity("MathSite.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("GroupId");

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MathSite.Entities.UserSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<string>("Namespace")
                        .IsRequired();

                    b.Property<Guid>("UserId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSettingses");
                });

            modelBuilder.Entity("MathSite.Entities.UsersRights", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<Guid>("RightId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RightId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersRights");
                });

            modelBuilder.Entity("MathSite.Entities.Comment", b =>
                {
                    b.HasOne("MathSite.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.Group", b =>
                {
                    b.HasOne("MathSite.Entities.GroupType", "GroupType")
                        .WithMany("Groups")
                        .HasForeignKey("GroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.Group", "ParentGroup")
                        .WithMany()
                        .HasForeignKey("ParentGroupId");
                });

            modelBuilder.Entity("MathSite.Entities.GroupsRights", b =>
                {
                    b.HasOne("MathSite.Entities.Group", "Group")
                        .WithMany("GroupsRights")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.Right", "Right")
                        .WithMany("GroupsRights")
                        .HasForeignKey("RightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.Person", b =>
                {
                    b.HasOne("MathSite.Entities.File", "Photo")
                        .WithOne("Person")
                        .HasForeignKey("MathSite.Entities.Person", "PhotoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.User", "User")
                        .WithOne("Person")
                        .HasForeignKey("MathSite.Entities.Person", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.Post", b =>
                {
                    b.HasOne("MathSite.Entities.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.PostSeoSettings", "PostSeoSettings")
                        .WithOne("Post")
                        .HasForeignKey("MathSite.Entities.Post", "PostSeoSettingsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.PostSettings", "PostSettings")
                        .WithOne("Post")
                        .HasForeignKey("MathSite.Entities.Post", "PostSettingsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.PostType", "PostType")
                        .WithMany("Posts")
                        .HasForeignKey("PostTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.PostAttachment", b =>
                {
                    b.HasOne("MathSite.Entities.File", "File")
                        .WithMany("PostAttachments")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.Post", "Post")
                        .WithMany("PostAttachments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.PostCategory", b =>
                {
                    b.HasOne("MathSite.Entities.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.PostGroupsAllowed", b =>
                {
                    b.HasOne("MathSite.Entities.Group", "Group")
                        .WithMany("PostGroupsAllowed")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.Post", "Post")
                        .WithMany("GroupsAllowed")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.PostKeywords", b =>
                {
                    b.HasOne("MathSite.Entities.Keywords", "Keyword")
                        .WithMany("Posts")
                        .HasForeignKey("KeywordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.PostSeoSettings", "PostSeoSettings")
                        .WithMany("PostKeywords")
                        .HasForeignKey("PostSeoSettingsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.PostOwner", b =>
                {
                    b.HasOne("MathSite.Entities.Post", "Post")
                        .WithMany("PostOwners")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.User", "User")
                        .WithMany("PostsOwner")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.PostRating", b =>
                {
                    b.HasOne("MathSite.Entities.Post", "Post")
                        .WithMany("PostRatings")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.User", "User")
                        .WithMany("PostsRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.PostSettings", b =>
                {
                    b.HasOne("MathSite.Entities.PostType", "PostType")
                        .WithOne("DefaultPostsSettings")
                        .HasForeignKey("MathSite.Entities.PostSettings", "PostTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.File", "PreviewImage")
                        .WithMany("PostSettings")
                        .HasForeignKey("PreviewImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.PostUserAllowed", b =>
                {
                    b.HasOne("MathSite.Entities.Post", "Post")
                        .WithMany("UsersAllowed")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.User", "User")
                        .WithMany("AllowedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.User", b =>
                {
                    b.HasOne("MathSite.Entities.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.UserSettings", b =>
                {
                    b.HasOne("MathSite.Entities.User", "User")
                        .WithMany("Settings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MathSite.Entities.UsersRights", b =>
                {
                    b.HasOne("MathSite.Entities.Right", "Right")
                        .WithMany("UsersRights")
                        .HasForeignKey("RightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MathSite.Entities.User", "User")
                        .WithMany("UserRights")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
