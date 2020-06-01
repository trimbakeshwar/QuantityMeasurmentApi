﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuantityMeasurmentRL.DBContext;

namespace QuantityMeasurmentRL.Migrations
{
    [DbContext(typeof(OperationsDBContext))]
    partial class OperationsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuantityMeasurmentCL.CamparisonsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Result");

                    b.Property<decimal>("ValueOne")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ValueOneUnit")
                        .IsRequired();

                    b.Property<decimal>("ValueTwo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ValueTwoUnit")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Comparisons");
                });

            modelBuilder.Entity("QuantityMeasurmentCL.ConversionsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OperationType")
                        .IsRequired();

                    b.Property<decimal>("Result")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Conversions");
                });
#pragma warning restore 612, 618
        }
    }
}
