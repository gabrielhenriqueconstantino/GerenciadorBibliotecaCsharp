using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaPOO.Enums;
using BibliotecaPOO.Models;
using GerenciadorBiblioteca.Enums;

namespace BibliotecaPOO.Services
{
    public class SistemaBiblioteca
    {
        private List<Livro> livros;
        private List<Usuario> usuarios;
        private List<Emprestimo> emprestimos;

        public SistemaBiblioteca()
        {
            livros = new List<Livro>();
            usuarios = new List<Usuario>();
            emprestimos = new List<Emprestimo>();
        }

        public void CadastrarLivro(Livro livro)
        {
            livros.Add(livro);
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void ListarLivros()
        {
            Console.WriteLine("=== LISTA DE LIVROS ===");
            foreach (var livro in livros)
            {
                livro.ExibirInformacoes();
            }
        }

        public void ListarUsuarios()
        {
            Console.WriteLine("=== LISTA DE USUÁRIOS ===");
            foreach (var usuario in usuarios)
            {
                usuario.ExibirInformacoes();
            }
        }

        public void ListarEmprestimosAtivos()
        {
            Console.WriteLine("=== EMPRÉSTIMOS ATIVOS ===");
            var ativos = emprestimos.Where(e => e.Status == StatusEmprestimo.Ativo);
            foreach (var emp in ativos)
            {
                emp.ExibirResumo();
            }
        }

        public void RealizarEmprestimo(int usuarioId, string livroIsbn, int prazoDias)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioId);
            var livro = livros.FirstOrDefault(l => l.Isbn == livroIsbn && l.Status == StatusLivro.Disponivel);

            if (usuario == null || livro == null)
            {
                Console.WriteLine("Usuário não encontrado ou livro não disponível!");
                return;
            }

            var emprestimo = new Emprestimo(usuario, livro, DateTime.Now, prazoDias);
            emprestimos.Add(emprestimo);
            Console.WriteLine("Empréstimo realizado com sucesso!");
        }

        public void RegistrarDevolucao(string livroIsbn)
        {
            var emprestimo = emprestimos.FirstOrDefault(e =>
                e.Livro.Isbn == livroIsbn && e.Status == StatusEmprestimo.Ativo);

            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo ativo não encontrado para este livro!");
                return;
            }

            emprestimo.RegistrarDevolucao();
            Console.WriteLine("Devolução registrada com sucesso!");
        }

        public void GerarRelatorioLivrosDisponiveis()
        {
            Console.WriteLine("=== LIVROS DISPONÍVEIS ===");
            var disponiveis = livros.Where(l => l.Status == StatusLivro.Disponivel);
            foreach (var livro in disponiveis)
            {
                livro.ExibirInformacoes();
            }
        }

        public void GerarRelatorioHistoricoUsuario(int usuarioId)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario == null)
            {
                Console.WriteLine("Usuário não encontrado!");
                return;
            }

            Console.WriteLine($"=== HISTÓRICO DE EMPRÉSTIMOS DE {usuario.Nome.ToUpper()} ===");
            var historico = emprestimos.Where(e => e.Usuario.Id == usuarioId);
            foreach (var emp in historico)
            {
                emp.ExibirResumo();
            }
        }

        public bool RemoverLivro(string isbn)
        {
            var livro = livros.FirstOrDefault(l => l.Isbn == isbn);

            if (livro == null)
            {
                return false; // Livro não encontrado
            }

            // Verifica se o livro está emprestado
            bool estaEmprestado = emprestimos.Any(e => e.Livro.Isbn == isbn && e.Status == StatusEmprestimo.Ativo);
            if (estaEmprestado)
            {
                Console.WriteLine("O livro está emprestado e não pode ser removido.");
                return false;
            }

            livros.Remove(livro);
            return true;
        }
    }
}
