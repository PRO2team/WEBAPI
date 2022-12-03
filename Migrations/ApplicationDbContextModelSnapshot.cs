<<<<<<< HEAD
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
                        .IsRequired()
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

                    b.HasKey("AmentityID");

                    b.HasIndex("IconPictureID");

                    b.ToTable("Amentities");
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

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentTypeID");

                    b.HasIndex("SalonID");

                    b.ToTable("AppointmentTypes");
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

            modelBuilder.Entity("Webapi.Models.Picture", b =>
                {
                    b.Property<int>("PictureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureID"), 1L, 1);

                    b.Property<int?>("AppointmentTypeID")
                        .HasColumnType("int");

                    b.Property<byte[]>("Bytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filepath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PictureID");

                    b.HasIndex("AppointmentTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Webapi.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"), 1L, 1);

                    b.Property<int>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("AppointmentID");

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

                    b.Property<int>("PictureID")
                        .HasColumnType("int");

                    b.Property<string>("WebsiteURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalonID");

                    b.HasIndex("AddressID");

                    b.HasIndex("PictureID");

                    b.ToTable("Salons");
                });

            modelBuilder.Entity("Webapi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserCredentialsID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

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

                    b.Navigation("Icon");
                });

            modelBuilder.Entity("Webapi.Models.Appointment", b =>
                {
                    b.HasOne("Webapi.Models.AppointmentType", "AppointmentType")
                        .WithMany()
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
                    b.HasOne("Webapi.Models.Salon", null)
                        .WithMany("AppointmentTypes")
                        .HasForeignKey("SalonID");
                });

            modelBuilder.Entity("Webapi.Models.DayHours", b =>
                {
                    b.HasOne("Webapi.Models.Salon", null)
                        .WithMany("OpenHours")
                        .HasForeignKey("SalonID");
                });

            modelBuilder.Entity("Webapi.Models.Picture", b =>
                {
                    b.HasOne("Webapi.Models.AppointmentType", null)
                        .WithMany("Pictures")
                        .HasForeignKey("AppointmentTypeID");

                    b.HasOne("Webapi.Models.User", null)
                        .WithMany("ProfilePictures")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Webapi.Models.Review", b =>
                {
                    b.HasOne("Webapi.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Webapi.Models.Salon", b =>
                {
                    b.HasOne("Webapi.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi.Models.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("Webapi.Models.User", b =>
                {
                    b.HasOne("Webapi.Models.UserCredentials", "UserCredentials")
                        .WithMany()
                        .HasForeignKey("UserCredentialsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCredentials");
                });

            modelBuilder.Entity("Webapi.Models.AppointmentType", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("Webapi.Models.Salon", b =>
                {
                    b.Navigation("AppointmentTypes");

                    b.Navigation("OpenHours");
                });

            modelBuilder.Entity("Webapi.Models.User", b =>
                {
                    b.Navigation("ProfilePictures");
                });
#pragma warning restore 612, 618
        }
    }
}
=======
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
                        .IsRequired()
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

                    b.HasKey("AmentityID");

                    b.HasIndex("IconPictureID");

                    b.ToTable("Amentities");
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

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentTypeID");

                    b.HasIndex("SalonID");

                    b.ToTable("AppointmentTypes");
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

            modelBuilder.Entity("Webapi.Models.Picture", b =>
                {
                    b.Property<int>("PictureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureID"), 1L, 1);

                    b.Property<int?>("AppointmentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Filepath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PictureID");

                    b.HasIndex("AppointmentTypeID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Webapi.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"), 1L, 1);

                    b.Property<int>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("AppointmentID");

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

                    b.Property<string>("WebsiteURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalonID");

                    b.HasIndex("AddressID");

                    b.ToTable("Salons");
                });

            modelBuilder.Entity("Webapi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SelfiePictureID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserCredentialsID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("SelfiePictureID");

                    b.HasIndex("UserCredentialsID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Webapi.Models.UserCredentials", b =>
                {
                    b.Property<int>("UserCredentialsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserCredentialsID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHashed")
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

                    b.Navigation("Icon");
                });

            modelBuilder.Entity("Webapi.Models.Appointment", b =>
                {
                    b.HasOne("Webapi.Models.AppointmentType", "AppointmentType")
                        .WithMany()
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
                    b.HasOne("Webapi.Models.Salon", null)
                        .WithMany("AppointmentTypes")
                        .HasForeignKey("SalonID");
                });

            modelBuilder.Entity("Webapi.Models.DayHours", b =>
                {
                    b.HasOne("Webapi.Models.Salon", null)
                        .WithMany("OpenHours")
                        .HasForeignKey("SalonID");
                });

            modelBuilder.Entity("Webapi.Models.Picture", b =>
                {
                    b.HasOne("Webapi.Models.AppointmentType", null)
                        .WithMany("Pictures")
                        .HasForeignKey("AppointmentTypeID");
                });

            modelBuilder.Entity("Webapi.Models.Review", b =>
                {
                    b.HasOne("Webapi.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Webapi.Models.Salon", b =>
                {
                    b.HasOne("Webapi.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Webapi.Models.User", b =>
                {
                    b.HasOne("Webapi.Models.Picture", "Selfie")
                        .WithMany()
                        .HasForeignKey("SelfiePictureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi.Models.UserCredentials", "UserCredentials")
                        .WithMany()
                        .HasForeignKey("UserCredentialsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Selfie");

                    b.Navigation("UserCredentials");
                });

            modelBuilder.Entity("Webapi.Models.AppointmentType", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("Webapi.Models.Salon", b =>
                {
                    b.Navigation("AppointmentTypes");

                    b.Navigation("OpenHours");
                });
#pragma warning restore 612, 618
        }
    }
}
>>>>>>> 885ce6c3f4ead2c34edf8f810e97aaa8db77b916
