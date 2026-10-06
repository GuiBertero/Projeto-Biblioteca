using System;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;

            exemplares = new List<Exemplar>();
        }

        public int getIsbn()
        {
            return isbn;
        }

        public string getTitulo()
        {
            return titulo;
        }

        public string getAutor()
        {
            return autor;
        }

        public string getEditora()
        {
            return editora;
        }

        public void adicionarExemplar(Exemplar exemplar)
        {
            exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            return exemplares.Count;
        }

        public int qtdeDisponiveis()
        {
            int quantidade = 0;

            for (int i = 0; i < exemplares.Count; i++)
            {
                if (exemplares[i].disponivel())
                {
                    quantidade++;
                }
            }

            return quantidade;
        }

        public int qtdeEmprestimos()
        {
            int quantidade = 0;

            for (int i = 0; i < exemplares.Count; i++)
            {
                quantidade += exemplares[i].qtdeEmprestimos();
            }

            return quantidade;
        }

        public double percDisponibilidade()
        {
            if (qtdeExemplares() == 0)
            {
                return 0;
            }

            return (double)qtdeDisponiveis() / qtdeExemplares() * 100;
        }

        public List<Exemplar> getExemplares()
        {
            return exemplares;
        }
    }
}
