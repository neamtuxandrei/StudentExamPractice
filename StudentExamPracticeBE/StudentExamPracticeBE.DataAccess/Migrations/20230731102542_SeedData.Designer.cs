﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentExamPracticeBE.DataAccess;

#nullable disable

namespace StudentExamPracticeBE.DataAccess.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20230731102542_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentExamPracticeBE.Domain.ExamTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExamTasks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b85c580d-c6fd-4ad9-86dd-bf6ca587915c"),
                            Description = "Efectuare comparatii pentru a sorta n elemente",
                            Status = "Created",
                            Title = "Quicksort"
                        },
                        new
                        {
                            Id = new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"),
                            Description = "Parcurge in mod repetat lista element cu element comparand cu precedentul",
                            Status = "Created",
                            Title = "BubbleSort"
                        },
                        new
                        {
                            Id = new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"),
                            Description = "Creati 3 clase respectand principiile OOP.",
                            Status = "Created",
                            Title = "OOP design"
                        });
                });

            modelBuilder.Entity("StudentExamPracticeBE.Domain.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("583b3dcc-1135-482f-a7a2-f2e7699b1b61"),
                            EmailAddress = "neamtuandrei26@yahoo.com",
                            FirstName = "Andrei",
                            LastName = "Neamtu"
                        },
                        new
                        {
                            Id = new Guid("8e2df4ea-4825-4961-8c54-fe3e372b2133"),
                            EmailAddress = "motoc212@yahoo.com",
                            FirstName = "Gabriel",
                            LastName = "Motoc"
                        },
                        new
                        {
                            Id = new Guid("466daa7b-2238-4119-b133-c73fbc991f30"),
                            EmailAddress = "vlad.lupu@gmail.com",
                            FirstName = "Vlad",
                            LastName = "Lupu"
                        },
                        new
                        {
                            Id = new Guid("189752e7-0093-4497-9a75-9b6684a39aa6"),
                            EmailAddress = "mihnea.sanda@gmail.com",
                            FirstName = "Mihnea",
                            LastName = "Sanda"
                        },
                        new
                        {
                            Id = new Guid("1f2dc7e1-3a5d-43ba-9234-1c256f9f09d3"),
                            EmailAddress = "dicu_aurel9@yahoo.com",
                            FirstName = "Aurel",
                            LastName = "Dicu"
                        },
                        new
                        {
                            Id = new Guid("3c0250b0-4d43-420f-9dfc-c7ce4d890945"),
                            EmailAddress = "ionescu@gmail.com",
                            FirstName = "Andrei",
                            LastName = "Ionescu"
                        },
                        new
                        {
                            Id = new Guid("d26a3312-d30b-4419-b496-2608cd5ed504"),
                            EmailAddress = "tonceamihai99@yahoo.com",
                            FirstName = "Mihai",
                            LastName = "Toncea"
                        },
                        new
                        {
                            Id = new Guid("0dbd5e04-670c-4886-88f3-9659d1541965"),
                            EmailAddress = "anitaclaudiu@gmail.com",
                            FirstName = "Claudiu",
                            LastName = "Anita"
                        },
                        new
                        {
                            Id = new Guid("0b1fff26-ebb9-405e-ba20-b401d22c9dbc"),
                            EmailAddress = "andrei89@yahoo.com",
                            FirstName = "Majon",
                            LastName = "Andrei"
                        },
                        new
                        {
                            Id = new Guid("c9710c8a-72fb-40e7-b5bf-e94d8cbce9c3"),
                            EmailAddress = "baranescu@yahoo.com",
                            FirstName = "Andrei",
                            LastName = "Baranescu"
                        });
                });

            modelBuilder.Entity("StudentTask", b =>
                {
                    b.Property<Guid>("ExamTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExamTaskId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentTask");

                    b.HasData(
                        new
                        {
                            ExamTaskId = new Guid("b85c580d-c6fd-4ad9-86dd-bf6ca587915c"),
                            StudentId = new Guid("583b3dcc-1135-482f-a7a2-f2e7699b1b61")
                        },
                        new
                        {
                            ExamTaskId = new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"),
                            StudentId = new Guid("583b3dcc-1135-482f-a7a2-f2e7699b1b61")
                        },
                        new
                        {
                            ExamTaskId = new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"),
                            StudentId = new Guid("583b3dcc-1135-482f-a7a2-f2e7699b1b61")
                        },
                        new
                        {
                            ExamTaskId = new Guid("b85c580d-c6fd-4ad9-86dd-bf6ca587915c"),
                            StudentId = new Guid("8e2df4ea-4825-4961-8c54-fe3e372b2133")
                        },
                        new
                        {
                            ExamTaskId = new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"),
                            StudentId = new Guid("8e2df4ea-4825-4961-8c54-fe3e372b2133")
                        },
                        new
                        {
                            ExamTaskId = new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"),
                            StudentId = new Guid("466daa7b-2238-4119-b133-c73fbc991f30")
                        },
                        new
                        {
                            ExamTaskId = new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"),
                            StudentId = new Guid("189752e7-0093-4497-9a75-9b6684a39aa6")
                        },
                        new
                        {
                            ExamTaskId = new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"),
                            StudentId = new Guid("1f2dc7e1-3a5d-43ba-9234-1c256f9f09d3")
                        },
                        new
                        {
                            ExamTaskId = new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"),
                            StudentId = new Guid("3c0250b0-4d43-420f-9dfc-c7ce4d890945")
                        },
                        new
                        {
                            ExamTaskId = new Guid("b6b1501c-9408-4d5f-94a6-5341fb2d269c"),
                            StudentId = new Guid("d26a3312-d30b-4419-b496-2608cd5ed504")
                        },
                        new
                        {
                            ExamTaskId = new Guid("b85c580d-c6fd-4ad9-86dd-bf6ca587915c"),
                            StudentId = new Guid("0dbd5e04-670c-4886-88f3-9659d1541965")
                        },
                        new
                        {
                            ExamTaskId = new Guid("9e727cee-e590-4a99-a6c6-8618824bdf56"),
                            StudentId = new Guid("0b1fff26-ebb9-405e-ba20-b401d22c9dbc")
                        });
                });

            modelBuilder.Entity("StudentTask", b =>
                {
                    b.HasOne("StudentExamPracticeBE.Domain.ExamTask", null)
                        .WithMany()
                        .HasForeignKey("ExamTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentExamPracticeBE.Domain.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}