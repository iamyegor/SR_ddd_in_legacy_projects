﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PackageDeliveryNew.Infrastructure;

#nullable disable

namespace PackageDeliveryNew.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240325185719_Snake_case_all_database_column_and_table_names")]
    partial class Snake_case_all_database_column_and_table_names
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PackageDeliveryNew.Deliveries.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<decimal?>("CostEstimate")
                        .HasColumnType("numeric")
                        .HasColumnName("cost_estimate");

                    b.Property<bool>("IsSyncNeeded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_sync_needed");

                    b.ComplexProperty<Dictionary<string, object>>("Destination", "PackageDeliveryNew.Deliveries.Delivery.Destination#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("destination_city");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("destination_state");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("destination_street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("destination_zip_code");
                        });

                    b.HasKey("Id");

                    b.ToTable("deliveries", (string)null);
                });

            modelBuilder.Entity("PackageDeliveryNew.Deliveries.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("WeightInPounds")
                        .HasColumnType("double precision")
                        .HasColumnName("weight_in_pounds");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("PackageDeliveryNew.Deliveries.ProductLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<int?>("delivery_id")
                        .HasColumnType("integer");

                    b.Property<int>("product_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("delivery_id");

                    b.HasIndex("product_id");

                    b.ToTable("product_lines", (string)null);
                });

            modelBuilder.Entity("PackageDeliveryNew.Infrastructure.Synchronization", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<bool>("IsSyncRequired")
                        .HasColumnType("boolean")
                        .HasColumnName("is_sync_required");

                    b.HasKey("Name");

                    b.ToTable("sync", (string)null);

                    b.HasData(
                        new
                        {
                            Name = "Delivery",
                            IsSyncRequired = false
                        });
                });

            modelBuilder.Entity("PackageDeliveryNew.Deliveries.ProductLine", b =>
                {
                    b.HasOne("PackageDeliveryNew.Deliveries.Delivery", null)
                        .WithMany("ProductLines")
                        .HasForeignKey("delivery_id");

                    b.HasOne("PackageDeliveryNew.Deliveries.Product", "Product")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PackageDeliveryNew.Deliveries.Delivery", b =>
                {
                    b.Navigation("ProductLines");
                });
#pragma warning restore 612, 618
        }
    }
}
