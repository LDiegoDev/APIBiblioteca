using System;
using System.Collections.Generic;

namespace Biblioteca.Business.Models
{
    public class Livro : Entity
    {
        public Guid EditoraId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        public int Paginas { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public Editora Editora { get; set; }
        public IEnumerable<Autor> Autores { get; set; }

    }
}
