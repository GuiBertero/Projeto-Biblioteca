using System;
using Biblioteca.Models;

namespace Biblioteca
{
    class Program
    {
        static Livros livros = new Livros();

        static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.Clear();

                Console.WriteLine("========== BIBLIOTECA ==========");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar livro");
                Console.WriteLine("2 - Pesquisar livro (sintético)");
                Console.WriteLine("3 - Pesquisar livro (analítico)");
                Console.WriteLine("4 - Adicionar exemplar");
                Console.WriteLine("5 - Registrar empréstimo");
                Console.WriteLine("6 - Registrar devolução");
                Console.WriteLine("================================");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Programa encerrado.");
                        break;

                    case 1:
                        adicionarLivro();
                        break;

                    case 2:
                        pesquisarSintetico();
                        break;

                    case 3:
                        pesquisarAnalitico();
                        break;

                    case 4:
                        adicionarExemplar();
                        break;

                    case 5:
                        registrarEmprestimo();
                        break;

                    case 6:
                        registrarDevolucao();
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

        static void adicionarLivro()
        {
            Console.WriteLine("===== ADICIONAR LIVRO =====");

            Console.Write("ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Editora: ");
            string editora = Console.ReadLine();

            Livro livro = new Livro(
                isbn,
                titulo,
                autor,
                editora
            );

            if (livros.pesquisar(livro) == null)
            {
                livros.adicionar(livro);

                Console.WriteLine("Livro adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Já existe um livro com esse ISBN.");
            }
        }

        static Livro buscarLivro()
        {
            Console.Write("Digite o ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = new Livro(
                isbn,
                "",
                "",
                ""
            );

            return livros.pesquisar(livro);
        }

        static void pesquisarSintetico()
        {
            Console.WriteLine("===== PESQUISA SINTÉTICA =====");

            Livro livro = buscarLivro();

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("ISBN: " + livro.getIsbn());
            Console.WriteLine("Título: " + livro.getTitulo());
            Console.WriteLine("Autor: " + livro.getAutor());
            Console.WriteLine("Editora: " + livro.getEditora());
            Console.WriteLine("Quantidade de exemplares: " +
                              livro.qtdeExemplares());
            Console.WriteLine("Exemplares disponíveis: " +
                              livro.qtdeDisponiveis());
            Console.WriteLine("Quantidade de empréstimos: " +
                              livro.qtdeEmprestimos());
            Console.WriteLine("Disponibilidade: " +
                              livro.percDisponibilidade().ToString("F2") + "%");
        }

        static void pesquisarAnalitico()
        {
            Console.WriteLine("===== PESQUISA ANALÍTICA =====");

            Livro livro = buscarLivro();

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("ISBN: " + livro.getIsbn());
            Console.WriteLine("Título: " + livro.getTitulo());
            Console.WriteLine("Autor: " + livro.getAutor());
            Console.WriteLine("Editora: " + livro.getEditora());

            Console.WriteLine();
            Console.WriteLine("Quantidade de exemplares: " +
                              livro.qtdeExemplares());

            Console.WriteLine("Exemplares disponíveis: " +
                              livro.qtdeDisponiveis());

            Console.WriteLine("Quantidade de empréstimos: " +
                              livro.qtdeEmprestimos());

            Console.WriteLine("Disponibilidade: " +
                              livro.percDisponibilidade().ToString("F2") + "%");

            Console.WriteLine();
            Console.WriteLine("===== EXEMPLARES =====");

            for (int i = 0; i < livro.getExemplares().Count; i++)
            {
                Exemplar exemplar = livro.getExemplares()[i];

                Console.WriteLine();
                Console.WriteLine("Tombo: " + exemplar.getTombo());

                if (exemplar.disponivel())
                {
                    Console.WriteLine("Status: Disponível");
                }
                else
                {
                    Console.WriteLine("Status: Emprestado");
                }

                Console.WriteLine(
                    "Quantidade de empréstimos: " +
                    exemplar.qtdeEmprestimos()
                );

                for (int j = 0;
                     j < exemplar.getEmprestimos().Count;
                     j++)
                {
                    Emprestimo emprestimo =
                        exemplar.getEmprestimos()[j];

                    Console.WriteLine(
                        "  Empréstimo: " +
                        emprestimo.getDtEmprestimo()
                        .ToString("dd/MM/yyyy HH:mm")
                    );

                    if (emprestimo.estaAberto())
                    {
                        Console.WriteLine(
                            "  Devolução: Em aberto"
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            "  Devolução: " +
                            emprestimo.getDtDevolucao()
                            .ToString("dd/MM/yyyy HH:mm")
                        );
                    }
                }
            }
        }

        static void adicionarExemplar()
        {
            Console.WriteLine("===== ADICIONAR EXEMPLAR =====");

            Livro livro = buscarLivro();

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            Console.Write("Digite o número do tombo: ");
            int tombo = int.Parse(Console.ReadLine());

            Exemplar exemplar = new Exemplar(tombo);

            livro.adicionarExemplar(exemplar);

            Console.WriteLine(
                "Exemplar adicionado com sucesso!"
            );
        }

        static void registrarEmprestimo()
        {
            Console.WriteLine("===== REGISTRAR EMPRÉSTIMO =====");

            Livro livro = buscarLivro();

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            Console.Write("Digite o tombo do exemplar: ");
            int tombo = int.Parse(Console.ReadLine());

            Exemplar exemplar = encontrarExemplar(
                livro,
                tombo
            );

            if (exemplar == null)
            {
                Console.WriteLine("Exemplar não encontrado.");
                return;
            }

            if (exemplar.emprestar())
            {
                Console.WriteLine(
                    "Empréstimo registrado com sucesso!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Esse exemplar já está emprestado."
                );
            }
        }

        static void registrarDevolucao()
        {
            Console.WriteLine("===== REGISTRAR DEVOLUÇÃO =====");

            Livro livro = buscarLivro();

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            Console.Write("Digite o tombo do exemplar: ");
            int tombo = int.Parse(Console.ReadLine());

            Exemplar exemplar = encontrarExemplar(
                livro,
                tombo
            );

            if (exemplar == null)
            {
                Console.WriteLine("Exemplar não encontrado.");
                return;
            }

            if (exemplar.devolver())
            {
                Console.WriteLine(
                    "Devolução registrada com sucesso!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Esse exemplar não possui empréstimo em aberto."
                );
            }
        }

        static Exemplar encontrarExemplar(
            Livro livro,
            int tombo)
        {
            for (int i = 0;
                 i < livro.getExemplares().Count;
                 i++)
            {
                if (livro.getExemplares()[i].getTombo() == tombo)
                {
                    return livro.getExemplares()[i];
                }
            }

            return null;
        }
    }
}
