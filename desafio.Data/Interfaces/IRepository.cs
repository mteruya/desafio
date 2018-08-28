using desafio.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace desafio.Data.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T Add(T dados);
        IEnumerable<T> Listar();
        T Get(int Id);
        void Edit(T dados);

    }
}
