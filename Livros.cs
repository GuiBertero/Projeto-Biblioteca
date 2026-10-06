using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class Livros
    {
        private List<Livro> acervo;

        public Livros()
        {
            acervo = new List<Livro>();
        }

        public void adicionar(Livro livro)
        {
            acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro)
        {
            for (int i = 0; i < acervo.Count; i++)
            {
                if (acervo[i].getIsbn() == livro.getIsbn())
                {
                    return acervo[i];
                }
            }

            return null;
        }

        public List<Livro> getAcervo()
        {
            return acervo;
        }
    }
}
