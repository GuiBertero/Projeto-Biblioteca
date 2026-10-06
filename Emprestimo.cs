using System;

namespace Biblioteca.Models
{
    public class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        public Emprestimo()
        {
            dtEmprestimo = DateTime.Now;
            dtDevolucao = DateTime.MinValue;
        }

        public DateTime getDtEmprestimo()
        {
            return dtEmprestimo;
        }

        public DateTime getDtDevolucao()
        {
            return dtDevolucao;
        }

        public void devolver()
        {
            dtDevolucao = DateTime.Now;
        }

        public bool estaAberto()
        {
            return dtDevolucao == DateTime.MinValue;
        }
    }
}
