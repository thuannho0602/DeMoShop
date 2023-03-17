﻿// <auto-generated />
using System;
using Demo.DataBase.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo.DataBase.Migrations
{
    [DbContext(typeof(DemoDbcontext))]
    [Migration("20230317100418_AddColumData")]
    partial class AddColumData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Demo.DataBase.Entity.Appconfig", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.ToTable("AppConfig", (string)null);

                    b.HasData(
                        new
                        {
                            Key = "Nguyen Minh Thuan",
                            Value = "afdfdfds"
                        },
                        new
                        {
                            Key = " Minh Thuan",
                            Value = "afdfdfvddfdds"
                        },
                        new
                        {
                            Key = "Nguyen Minh ",
                            Value = "afdfdfds"
                        });
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProcductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcductId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsShowonHome")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsShowonHome = true,
                            SortOrder = 1,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            IsShowonHome = true,
                            SortOrder = 1,
                            Status = 1
                        });
                });

            modelBuilder.Entity("Demo.DataBase.Entity.CategoryTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SeoAlias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoDesCription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SeoTile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LanguageId");

                    b.ToTable("CategoryTranslation", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            LanguageId = "vi",
                            Name = "Áo Nam",
                            SeoAlias = "Ao-Nam",
                            SeoDesCription = "Sẩn Phẩm Thời Trang Nam ",
                            SeoTile = "Sẩn Phẩm Thời Trang Nam"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            LanguageId = "en",
                            Name = "Men-Shirt",
                            SeoAlias = "Men-Shirt",
                            SeoDesCription = "Men's Fashion Products ",
                            SeoTile = "Men's Fashion Products"
                        });
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contact", (string)null);
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Language", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "vi",
                            IsDefault = true,
                            Name = "Tiếng Việt"
                        },
                        new
                        {
                            Id = "en",
                            IsDefault = false,
                            Name = "English"
                        });
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderDatailOrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderDatailProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderDatailOrderId", "OrderDatailProductId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Demo.DataBase.Entity.OrderDatail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDatail", (string)null);
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreacted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFeaatured")
                        .HasColumnType("bit");

                    b.Property<decimal>("Originalprice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ViewCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreacted = new DateTime(2023, 3, 17, 17, 4, 17, 813, DateTimeKind.Local).AddTicks(6987),
                            IsFeaatured = false,
                            Originalprice = 10000m,
                            Price = 2000m,
                            Stock = 0,
                            ViewCount = 0
                        },
                        new
                        {
                            Id = 2,
                            DateCreacted = new DateTime(2023, 3, 17, 17, 4, 17, 813, DateTimeKind.Local).AddTicks(7004),
                            IsFeaatured = false,
                            Originalprice = 10000m,
                            Price = 2000m,
                            Stock = 0,
                            ViewCount = 0
                        });
                });

            modelBuilder.Entity("Demo.DataBase.Entity.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<long>("Filesize")
                        .HasColumnType("bigint");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.ProductInCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProcductInCategory", (string)null);

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        });
                });

            modelBuilder.Entity("Demo.DataBase.Entity.ProductTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SeoDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTranslation", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Áo Sơ Mi Nam Trắng Minh Thuận",
                            Details = "Áo Sơ Mi Nam Trắng Minh Thuận",
                            LanguageId = "vi",
                            Name = "Áo Sơ Mi Nam Trắng Minh Thuận",
                            ProductId = 1,
                            SeoAlias = "ao-so-mi-nam-trang-minh-thuan",
                            SeoDescription = "Áo Sơ Mi Nam Trắng Minh Thuận ",
                            SeoTitle = "Áo Sơ Mi Nam Trắng Minh Thuận"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Minh Thuan Men's White Shirt",
                            Details = "Minh Thuan Men's White Shirt",
                            LanguageId = "en",
                            Name = "Minh Thuan Men's White Shirt",
                            ProductId = 2,
                            SeoAlias = "minh-thuan-men's-white-shirt",
                            SeoDescription = "Minh Thuan Men's White Shirt ",
                            SeoTitle = "Minh Thuan Men's White Shirt"
                        });
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("ApplyForAll")
                        .HasColumnType("bit");

                    b.Property<decimal?>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("DiscountPrecent")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProducCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Promotion", (string)null);
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Slide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Slide", (string)null);
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ExternalTransactionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resulr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TranSaction", (string)null);
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Cart", b =>
                {
                    b.HasOne("Demo.DataBase.Entity.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProcductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.CategoryTranslation", b =>
                {
                    b.HasOne("Demo.DataBase.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demo.DataBase.Entity.Language", "Language")
                        .WithMany("CategoryTranslations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Order", b =>
                {
                    b.HasOne("Demo.DataBase.Entity.OrderDatail", null)
                        .WithMany("Orders")
                        .HasForeignKey("OrderDatailOrderId", "OrderDatailProductId");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.OrderDatail", b =>
                {
                    b.HasOne("Demo.DataBase.Entity.Order", "Order")
                        .WithMany("OrderDatails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demo.DataBase.Entity.Product", "Product")
                        .WithMany("OrderDatails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.ProductImage", b =>
                {
                    b.HasOne("Demo.DataBase.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.ProductInCategory", b =>
                {
                    b.HasOne("Demo.DataBase.Entity.Category", "Category")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demo.DataBase.Entity.Product", "Product")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.ProductTranslation", b =>
                {
                    b.HasOne("Demo.DataBase.Entity.Language", "Language")
                        .WithMany("ProductTranslations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demo.DataBase.Entity.Product", "Product")
                        .WithMany("ProductTranslations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Category", b =>
                {
                    b.Navigation("ProductInCategories");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Language", b =>
                {
                    b.Navigation("CategoryTranslations");

                    b.Navigation("ProductTranslations");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Order", b =>
                {
                    b.Navigation("OrderDatails");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.OrderDatail", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Demo.DataBase.Entity.Product", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("OrderDatails");

                    b.Navigation("ProductInCategories");

                    b.Navigation("ProductTranslations");
                });
#pragma warning restore 612, 618
        }
    }
}
