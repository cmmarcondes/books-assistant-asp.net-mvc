using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace books.Models
{
    public class cadastrarLivros
    {
        [Key]
        public int LivroId { get; set; }
        [Required]
        [DisplayName("Nome ")]
        public string livroName { get; set; }
        [Required]
        [DisplayName("Gênero")]
        public string livroGenero { get; set; }
        [Required]
        [DisplayName("Status")]
        public string livroStatus { get; set; }
    }
}