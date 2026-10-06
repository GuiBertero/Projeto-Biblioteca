using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
            emprestimos = new List<Emprestimo>();
        }

        public int getTombo()
        {
            return tombo;
        }

        public bool emprestar()
        {
            if (!disponivel())
            {
                return false;
            }

            Emprestimo emprestimo = new Emprestimo();

            emprestimos.Add(emprestimo);

            return true;
        }

        public bool devolver()
        {
            for (int i = 0; i < emprestimos.Count; i++)
            {
                if (emprestimos[i].estaAberto())
                {
                    emprestimos[i].devolver();

                    return true;
                }
            }

            return false;
        }

        public bool disponivel()
        {
            for (int i = 0; i < emprestimos.Count; i++)
            {
                if (emprestimos[i].estaAberto())
                {
                    return false;
                }
            }

            return true;
        }

        public int qtdeEmprestimos()
        {
            return emprestimos.Count;
        }

        public List<Emprestimo> getEmprestimos()
        {
            return emprestimos;
        }
    }
}
