using desafio.Data.Interfaces;
using desafio.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization; 

namespace desafio.Services
{
    public class CartaoService
    {
        private ICartaoRepository _repository;
        private ILoteArquivoRepository _Loterepository;
        public CartaoService(ICartaoRepository repository, ILoteArquivoRepository Loterepository)
        {
            _repository = repository;
            _Loterepository = Loterepository;
        }

        public Cartao Obter(int id)
        {
            var cartao = _repository.Get(id);
            cartao.NumCartao = SegurancaService.Encriptar(cartao.NumCartao);
            return cartao;
        }

        public Cartao ObterporNumeroCartao(String numCartao)
        {
            numCartao = SegurancaService.Encriptar(numCartao);
            var cartao = _repository.ObterporNumeroCartao(numCartao);
            cartao.NumCartao = SegurancaService.Desencriptar(cartao.NumCartao);

            return cartao;
        }

        public Cartao InserirCartao(Cartao cartao)
        {
            cartao.NumCartao = SegurancaService.Encriptar(cartao.NumCartao);
            var retCartao = _repository.Add(cartao);
            return retCartao;

        }
        private void InserirLote(LoteArquivo lote)
        {
            var id = _Loterepository.AdiconarLote(lote);
            foreach(var cartao in lote.Cartoes)
            {
                var item = new Cartao() {
                    LoteArquivoId = id,
                    NumCartao = SegurancaService.Encriptar(cartao.NumCartao),
                    UsuarioId = 1
                };
                _repository.Add(item);
            }
        }

        public String InserirCartaoLote(string arquivo)
        {
            var bArquivo = Convert.FromBase64String(arquivo);
            int i = 0;
            LoteArquivo dadosArquivo = new LoteArquivo();
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(new System.IO.MemoryStream(bArquivo)))
                {
                    string line;
                    dadosArquivo = new LoteArquivo();
                    dadosArquivo.Cartoes = new List<Cartao>();
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Substring(0, 1).Equals("C"))
                        {
                            Console.WriteLine(line);
                            dadosArquivo.Cartoes.Add(new Cartao()
                            {
                                NumCartao = line.Substring(7, line.Length - 7).Trim()  
                            });
                        }
                        else
                        {
                            if (i == 0)
                            {
                                dadosArquivo.Nome = line.Substring(0, 28).Trim();
                                dadosArquivo.DataArquivo = DateTime.ParseExact(line.Substring(29, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
                                dadosArquivo.Lote = line.Substring(37, 8);
                                dadosArquivo.TotalRegistros = Convert.ToInt32(line.Substring(45, 6).Trim());
                            }
                        }
                        i++;
                    }
                }

                InserirLote(dadosArquivo);

                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }
    }
}
