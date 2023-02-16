﻿// <auto-generated />
using System;
using Kurs2.sakila;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kurs2.Migrations
{
    [DbContext(typeof(MagazContext))]
    [Migration("20230209164055_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Kurs2.sakila.Заказ", b =>
                {
                    b.Property<int>("IdЗаказ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_заказ");

                    b.Property<int>("IdПользователя")
                        .HasColumnType("int")
                        .HasColumnName("id_пользователя");

                    b.Property<string>("Адрес")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("ОбщаяСтоимость")
                        .HasColumnType("int")
                        .HasColumnName("Общая стоимость");

                    b.Property<string>("СпособОплаты")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Способ оплаты");

                    b.HasKey("IdЗаказ")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdПользователя" }, "id_пользователь_idx");

                    b.ToTable("заказ", (string)null);
                });

            modelBuilder.Entity("Kurs2.sakila.Корзина", b =>
                {
                    b.Property<int>("IdКорзина")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_корзина");

                    b.Property<int>("IdПользователь")
                        .HasColumnType("int")
                        .HasColumnName("пользователь_Id_пользователь");

                    b.Property<int?>("Количество")
                        .HasColumnType("int");

                    b.Property<int?>("ОбщаяСтоимость")
                        .HasColumnType("int")
                        .HasColumnName("Общая стоимость");

                    b.HasKey("IdКорзина")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdПользователь" }, "id_корзина_idx");

                    b.ToTable("корзина", (string)null);
                });

            modelBuilder.Entity("Kurs2.sakila.Пользователь", b =>
                {
                    b.Property<int>("IdПользователь")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_пользователь");

                    b.Property<string>("Логин")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Пароль")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Роль")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdПользователь")
                        .HasName("PRIMARY");

                    b.ToTable("пользователь", (string)null);
                });

            modelBuilder.Entity("Kurs2.sakila.Товар", b =>
                {
                    b.Property<int>("IdТовар")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_товар");

                    b.Property<string>("Категория")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("Количество")
                        .HasColumnType("int");

                    b.Property<string>("Название")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Стоимость")
                        .HasColumnType("int");

                    b.Property<byte[]>("Фото")
                        .HasColumnType("longblob");

                    b.HasKey("IdТовар")
                        .HasName("PRIMARY");

                    b.ToTable("товар", (string)null);
                });

            modelBuilder.Entity("КорзинаHasТовар", b =>
                {
                    b.Property<int>("КорзинаIdКорзина")
                        .HasColumnType("int");

                    b.Property<int>("ТоварIdТовар")
                        .HasColumnType("int");

                    b.HasKey("КорзинаIdКорзина", "ТоварIdТовар")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "КорзинаIdКорзина" }, "fk_корзина_has_товар_корзина1_idx");

                    b.HasIndex(new[] { "ТоварIdТовар" }, "fk_корзина_has_товар_товар1_idx");

                    b.ToTable("корзина_has_товар", (string)null);
                });

            modelBuilder.Entity("Kurs2.sakila.Заказ", b =>
                {
                    b.HasOne("Kurs2.sakila.Пользователь", "IdПользователяNavigation")
                        .WithMany("Заказs")
                        .HasForeignKey("IdПользователя")
                        .IsRequired()
                        .HasConstraintName("id_пользователя");

                    b.Navigation("IdПользователяNavigation");
                });

            modelBuilder.Entity("Kurs2.sakila.Корзина", b =>
                {
                    b.HasOne("Kurs2.sakila.Пользователь", "ПользовательIdПользовательNavigation")
                        .WithMany("Корзинаs")
                        .HasForeignKey("IdПользователь")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("id_корзина");

                    b.Navigation("ПользовательIdПользовательNavigation");
                });

            modelBuilder.Entity("КорзинаHasТовар", b =>
                {
                    b.HasOne("Kurs2.sakila.Корзина", null)
                        .WithMany()
                        .HasForeignKey("КорзинаIdКорзина")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_корзина_has_товар_корзина1");

                    b.HasOne("Kurs2.sakila.Товар", null)
                        .WithMany()
                        .HasForeignKey("ТоварIdТовар")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_корзина_has_товар_товар1");
                });

            modelBuilder.Entity("Kurs2.sakila.Пользователь", b =>
                {
                    b.Navigation("Заказs");

                    b.Navigation("Корзинаs");
                });
#pragma warning restore 612, 618
        }
    }
}
