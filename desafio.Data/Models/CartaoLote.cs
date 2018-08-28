using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.Data.Models
{
    public class CartaoLote
    {
        public string arquivo { get; set; }

    }
    public class LoteArquivo : BaseModel
    {
        public String Nome { get; set; }
        public String Lote { get; set; }
        public DateTime DataArquivo { get; set; }
        public int TotalRegistros { get; set; }

        public virtual ICollection<Cartao> Cartoes { get; set; }

    }

}
