using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.Data.Models
{
    public class Cartao : BaseModel
    {
        public string NumCartao { get; set; }
        public int? LoteArquivoId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
