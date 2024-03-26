using ExoEntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
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
            builder.HasCheckConstraint("CK_AnneeSortie","AnneeSortie > 1975");
            builder.HasIndex(f => f.Title).IsUnique();


            //Injecter des données lors de la migration
            builder.HasData(new Film
            {
                Title = "",
                AnneeSortie = 1976,
                Acteur = "",
                Genre = ""
            });
        }
    }
}
