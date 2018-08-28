using desafio.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.Data.Interfaces
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Usuario Login(String login, String senha);

    }
}
