using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.Data.Models
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public List<Cartao> Cartoes { get; set; }
    }
}
