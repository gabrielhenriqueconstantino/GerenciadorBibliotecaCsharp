using System; // Importa funcionalidades básicas do .NET, como entrada e saída no console.
using BibliotecaPOO.Models; // Importa as classes relacionadas a modelos de dados (ex: Livro, Aluno, Professor).
using BibliotecaPOO.Services; // Importa os serviços do sistema, como SistemaBiblioteca.

namespace BibliotecaPOO // Define o namespace (espaço de nomes) do projeto. Isso ajuda na organização do código.
{
    class Program // Define a classe principal do programa.
    {
        static void Main(string[] args) // Ponto de entrada do programa. Método obrigatório para iniciar a aplicação.
        {
            var biblioteca = new SistemaBiblioteca(); // Cria uma instância do sistema da biblioteca.

            // Cadastro de alguns livros
            biblioteca.CadastrarLivro(new Livro("Dom Casmurro", "Machado de Assis", 1899, "978-85-7232-297-1")); // Adiciona o livro "Dom Casmurro" ao sistema.
            biblioteca.CadastrarLivro(new Livro("1984", "George Orwell", 1949, "978-85-359-0496-0")); // Adiciona o livro "1984" ao sistema.
            biblioteca.CadastrarLivro(new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", 1954, "978-85-359-0277-5")); // Adiciona "O Senhor dos Anéis".

            // Cadastro de alguns usuários
            biblioteca.CadastrarUsuario(new Aluno("João Silva", 1, "Engenharia", "20230001")); // Cadastra um aluno.
            biblioteca.CadastrarUsuario(new Aluno("Maria Souza", 2, "Medicina", "20230002")); // Cadastra outro aluno.
            biblioteca.CadastrarUsuario(new Professor("Carlos Oliveira", 3, "Matemática", "PROF1234")); // Cadastra um professor.

            // Menu interativo
            while (true) // Loop infinito para manter o menu ativo até que o usuário escolha sair.
            {
                Console.WriteLine("\n=== SISTEMA DE BIBLIOTECA ==="); // Exibe o título do menu.
                Console.WriteLine("1. Listar livros"); // Opção 1: listar livros cadastrados.
                Console.WriteLine("2. Listar usuários"); // Opção 2: listar usuários cadastrados.
                Console.WriteLine("3. Realizar empréstimo"); // Opção 3: emprestar um livro.
                Console.WriteLine("4. Registrar devolução"); // Opção 4: registrar devolução de um livro.
                Console.WriteLine("5. Listar empréstimos ativos"); // Opção 5: listar empréstimos não devolvidos.
                Console.WriteLine("6. Relatório de livros disponíveis"); // Opção 6: gerar relatório dos livros disponíveis.
                Console.WriteLine("7. Relatório histórico por usuário"); // Opção 7: exibir histórico de empréstimos de um usuário.
                Console.WriteLine("0. Sair"); // Opção 0: sair do programa.
                Console.Write("Escolha uma opção: "); // Solicita que o usuário escolha uma opção.

                var opcao = Console.ReadLine(); // Lê a opção digitada pelo usuário.

                switch (opcao) // Verifica a opção escolhida.
                {
                    case "1":
                        biblioteca.ListarLivros(); // Chama o método para listar todos os livros.
                        break;
                    case "2":
                        biblioteca.ListarUsuarios(); // Chama o método para listar todos os usuários.
                        break;
                    case "3":
                        Console.Write("ID do usuário: "); // Solicita o ID do usuário.
                        int usuarioId = int.Parse(Console.ReadLine()); // Lê e converte para inteiro.
                        Console.Write("ISBN do livro: "); // Solicita o ISBN do livro.
                        string isbn = Console.ReadLine(); // Lê o ISBN.
                        Console.Write("Prazo em dias: "); // Solicita o prazo do empréstimo.
                        int prazo = int.Parse(Console.ReadLine()); // Lê e converte o prazo.
                        biblioteca.RealizarEmprestimo(usuarioId, isbn, prazo); // Chama o método para registrar o empréstimo.
                        break;
                    case "4":
                        Console.Write("ISBN do livro a devolver: "); // Solicita o ISBN do livro a ser devolvido.
                        string isbnDevolucao = Console.ReadLine(); // Lê o ISBN.
                        biblioteca.RegistrarDevolucao(isbnDevolucao); // Chama o método para registrar a devolução.
                        break;
                    case "5":
                        biblioteca.ListarEmprestimosAtivos(); // Chama o método para listar empréstimos ativos.
                        break;
                    case "6":
                        biblioteca.GerarRelatorioLivrosDisponiveis(); // Chama o método para gerar relatório de livros disponíveis.
                        break;
                    case "7":
                        Console.Write("ID do usuário: "); // Solicita o ID do usuário.
                        int idUsuario = int.Parse(Console.ReadLine()); // Lê e converte o ID.
                        biblioteca.GerarRelatorioHistoricoUsuario(idUsuario); // Gera relatório do histórico do usuário.
                        break;
                    case "0":
                        return; // Encerra o programa.
                    default:
                        Console.WriteLine("Opção inválida!"); // Informa que a opção digitada é inválida.
                        break;
                }
            }
        }
    }
}
