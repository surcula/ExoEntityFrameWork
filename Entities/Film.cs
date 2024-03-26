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
   

        public int Id { get; set; }

        public string Title { get; set; }
     
        public int AnneeSortie { get; set; }

        public string Acteur { get; set; }
       
        public Genre Genre { get; set; }
        public string Realisateur { get; set; }

        public Film()
        {
            
        }
    }
}
