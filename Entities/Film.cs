using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoEntityFrameWork.Entities
{
    public class Film 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        [NotNull]
        public string Title { get; set; }
        [NotNull]
        [Range(1976, int.MaxValue, ErrorMessage = "L'année de production doit être supérieure à 1975")]
        [Column(TypeName = "varchar(100)")]
        public int AnneeSortie { get; set; }
        [NotNull]
        [Column(TypeName = "varchar(100)")]
        public string Acteur { get; set; }
        [NotNull]
        [Column(TypeName = "varchar(100)")]
        public string Genre { get; set; }

    }
}
