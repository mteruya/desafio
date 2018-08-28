using desafio.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.Data.Interfaces
{
    public interface ICartaoRepository : IRepository<Cartao>
    {
        Cartao ObterporNumeroCartao(String numCartao);
    }
}
