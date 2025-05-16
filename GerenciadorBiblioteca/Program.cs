using System;
using BibliotecaPOO.Models;
using BibliotecaPOO.Services;

namespace BibliotecaPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            var biblioteca = new SistemaBiblioteca();

            // Cadastro de alguns livros
            biblioteca.CadastrarLivro(new Livro("Dom Casmurro", "Machado de Assis", 1899, "978-85-7232-297-1"));
            biblioteca.CadastrarLivro(new Livro("1984", "George Orwell", 1949, "978-85-359-0496-0"));
            biblioteca.CadastrarLivro(new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", 1954, "978-85-359-0277-5"));

            // Cadastro de alguns usuários
            biblioteca.CadastrarUsuario(new Aluno("João Silva", 1, "Engenharia", "20230001"));
            biblioteca.CadastrarUsuario(new Aluno("Maria Souza", 2, "Medicina", "20230002"));
            biblioteca.CadastrarUsuario(new Professor("Carlos Oliveira", 3, "Matemática", "PROF1234"));

            // Menu interativo
            while (true)
            {
                Console.WriteLine("\n=== SISTEMA DE BIBLIOTECA ===");
                Console.WriteLine("1. Listar livros");
                Console.WriteLine("2. Listar usuários");
                Console.WriteLine("3. Realizar empréstimo");
                Console.WriteLine("4. Registrar devolução");
                Console.WriteLine("5. Listar empréstimos ativos");
                Console.WriteLine("6. Relatório de livros disponíveis");
                Console.WriteLine("7. Relatório histórico por usuário");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        biblioteca.ListarLivros();
                        break;
                    case "2":
                        biblioteca.ListarUsuarios();
                        break;
                    case "3":
                        Console.Write("ID do usuário: ");
                        int usuarioId = int.Parse(Console.ReadLine());
                        Console.Write("ISBN do livro: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Prazo em dias: ");
                        int prazo = int.Parse(Console.ReadLine());
                        biblioteca.RealizarEmprestimo(usuarioId, isbn, prazo);
                        break;
                    case "4":
                        Console.Write("ISBN do livro a devolver: ");
                        string isbnDevolucao = Console.ReadLine();
                        biblioteca.RegistrarDevolucao(isbnDevolucao);
                        break;
                    case "5":
                        biblioteca.ListarEmprestimosAtivos();
                        break;
                    case "6":
                        biblioteca.GerarRelatorioLivrosDisponiveis();
                        break;
                    case "7":
                        Console.Write("ID do usuário: ");
                        int idUsuario = int.Parse(Console.ReadLine());
                        biblioteca.GerarRelatorioHistoricoUsuario(idUsuario);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}