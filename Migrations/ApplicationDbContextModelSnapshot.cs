﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webapi.Contexts;

#nullable disable

namespace Webapi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Webapi.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Webapi.Models.Amentity", b =>
                {
                    b.Property<int>("AmentityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AmentityID"), 1L, 1);

                    b.Property<int>("IconPictureID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("AmentityID");

                    b.HasIndex("IconPictureID");

                    b.HasIndex("SalonID");

                    b.ToTable("Amentities");
                });

            modelBuilder.Entity("Webapi.Models.ApplicationForm", b =>
                {
                    b.Property<int>("ApplicationFormID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationFormID"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationFormID");

                    b.ToTable("ApplicationForms");
                });

            modelBuilder.Entity("Webapi.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"), 1L, 1);

                    b.Property<int>("AppointmentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("CalendarAppointmentURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentID");

                    b.HasIndex("AppointmentTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Webapi.Models.AppointmentType", b =>
                {
                    b.Property<int>("AppointmentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentTypeID"), 1L, 1);

                    b.Property<int>("LengthMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PromotionID")
                        .HasColumnType("int");

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentTypeID");

                    b.HasIndex("PromotionID");

                    b.HasIndex("SalonID");

                    b.ToTable("AppointmentTypes");
                });

            modelBuilder.Entity("Webapi.Models.ContactForm", b =>
                {
                    b.Property<int>("ContactFormID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactFormID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactFormID");

                    b.ToTable("ContactForms");
                });

            modelBuilder.Entity("Webapi.Models.DayHours", b =>
                {
                    b.Property<int>("DayHoursID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DayHoursID"), 1L, 1);

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("DayHoursID");

                    b.HasIndex("SalonID");

                    b.ToTable("DayHours");
                });

            modelBuilder.Entity("Webapi.Models.Email", b =>
                {
                    b.Property<int>("EmailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmailID"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailID");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Webapi.Models.Picture", b =>
                {
                    b.Property<int>("PictureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureID"), 1L, 1);

                    b.Property<byte[]>("Bytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("PictureID");

                    b.HasIndex("SalonID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Webapi.Models.Promotion", b =>
                {
                    b.Property<int>("PromotionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromotionID"), 1L, 1);

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountInPercent")
                        .HasColumnType("int");

                    b.HasKey("PromotionID");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Webapi.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("SalonID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Webapi.Models.Salon", b =>
                {
                    b.Property<int>("SalonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalonID"), 1L, 1);

                    b.Property<int>("AddressID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerUserID")
                        .HasColumnType("int");

                    b.Property<int?>("SalonPicturePictureID")
                        .HasColumnType("int");

                    b.Property<string>("SalonType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalonID");

                    b.HasIndex("AddressID");

                    b.HasIndex("OwnerUserID");

                    b.HasIndex("SalonPicturePictureID");

                    b.ToTable("Salons");
                });

            modelBuilder.Entity("Webapi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfilePicturePictureID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalSpent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserCredentialsID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("ProfilePicturePictureID");

                    b.HasIndex("UserCredentialsID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Webapi.Models.UserCredentials", b =>
                {
                    b.Property<int>("UserCredentialsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserCredentialsID"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHashed")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("RefreshTokenExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserCredentialsID");

                    b.ToTable("UserCredentials");
                });

            modelBuilder.Entity("Webapi.Models.Amentity", b =>
                {
                    b.HasOne("Webapi.Models.Picture", "Icon")
                        .WithMany()
                        .HasForeignKey("IconPictureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi.Models.Salon", null)
                        .WithMany("Amentities")
                        .HasForeignKey("SalonID");

                    b.Navigation("Icon");
                });

            modelBuilder.Entity("Webapi.Models.Appointment", b =>
                {
                    b.HasOne("Webapi.Models.AppointmentType", "AppointmentType")
                        .WithMany("Appointments")
                        .HasForeignKey("AppointmentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Webapi.Models.AppointmentType", b =>
                {
                    b.HasOne("Webapi.Models.Promotion", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionID");

                    b.HasOne("Webapi.Models.Salon", null)
                        .WithMany("AppointmentTypes")
                        .HasForeignKey("SalonID");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("Webapi.Models.DayHours", b =>
                {
                    b.HasOne("Webapi.Models.Salon", null)
                        .WithMany("OpenHours")
                        .HasForeignKey("SalonID");
                });

            modelBuilder.Entity("Webapi.Models.Picture", b =>
                {
                    b.HasOne("Webapi.Models.Salon", null)
                        .WithMany("Portfolio")
                        .HasForeignKey("SalonID");
                });

            modelBuilder.Entity("Webapi.Models.Review", b =>
                {
                    b.HasOne("Webapi.Models.Salon", null)
                        .WithMany("Reviews")
                        .HasForeignKey("SalonID");

                    b.HasOne("Webapi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Webapi.Models.Salon", b =>
                {
                    b.HasOne("Webapi.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi.Models.User", "Owner")
                        .WithMany("FavouriteSalons")
                        .HasForeignKey("OwnerUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi.Models.Picture", "SalonPicture")
                        .WithMany()
                        .HasForeignKey("SalonPicturePictureID");

                    b.Navigation("Address");

                    b.Navigation("Owner");

                    b.Navigation("SalonPicture");
                });

            modelBuilder.Entity("Webapi.Models.User", b =>
                {
                    b.HasOne("Webapi.Models.Picture", "ProfilePicture")
                        .WithMany()
                        .HasForeignKey("ProfilePicturePictureID");

                    b.HasOne("Webapi.Models.UserCredentials", "UserCredentials")
                        .WithMany()
                        .HasForeignKey("UserCredentialsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfilePicture");

                    b.Navigation("UserCredentials");
                });

            modelBuilder.Entity("Webapi.Models.AppointmentType", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Webapi.Models.Salon", b =>
                {
                    b.Navigation("Amentities");

                    b.Navigation("AppointmentTypes");

                    b.Navigation("OpenHours");

                    b.Navigation("Portfolio");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Webapi.Models.User", b =>
                {
                    b.Navigation("FavouriteSalons");
                });
#pragma warning restore 612, 618
        }
    }
}
