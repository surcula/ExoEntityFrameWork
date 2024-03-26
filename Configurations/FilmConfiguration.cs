using ExoEntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExoEntityFrameWork.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            //Donne un nom à la table
            builder.ToTable("Films");
            //Définis la clé primaire et l'auto incrémente
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            //builder.HasKey("Id"); Autre façon de faire
            //Rendre le titre unique
            builder.HasIndex(f => f.Title).IsUnique();
            //Les strings non null et limité à 100
            builder.Property(f => f.Title)
                .HasMaxLength(100)
                //.HasColumnName("Title")
                //.HasColumnType("VARCHAR")
                .IsRequired();
            builder.Property(f => f.Realisateur)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(f => f.Acteur)
                .HasMaxLength(100)
                .IsRequired();

            //builder.HasCheckConstraint("CK_AnneeSortie","AnneeSortie > 1975");
            builder.ToTable(t => t.HasCheckConstraint("CK_Films_AnneeSortie", "AnneeSortie > 1975"));


        //    //Injecter des données lors de la migration
        //    builder.HasData(new Film
        //    {
        //        Title = "",
        //        AnneeSortie = 1976,
        //        Acteur = "",
        //        Genre = "",
        //        Realisateur = ""
        //    });
        }
    }
}
