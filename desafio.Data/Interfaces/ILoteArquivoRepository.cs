using desafio.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.Data.Interfaces
{
    public interface ILoteArquivoRepository : IRepository<LoteArquivo>
    {
        int AdiconarLote(LoteArquivo dados);

    }
}
