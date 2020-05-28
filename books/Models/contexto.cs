using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace books.Models
{
    public class contexto: DbContext
    {
        public DbSet<cadastrarLivros> Livros { get; set; }
    }
}