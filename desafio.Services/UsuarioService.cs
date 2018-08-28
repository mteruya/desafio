using desafio.Data.Interfaces;
using desafio.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.Services
{
    public class UsuarioService
    {
        private IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public Usuario ObterUsuario(String login, String senha)
        {
            var usuario = _repository.Login(login, senha);
            return usuario;
        }
    }
}
