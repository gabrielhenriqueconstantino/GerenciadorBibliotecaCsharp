using BibliotecaPOO.Enums;
using BibliotecaPOO.Models;

namespace BibliotecaPOO.Models
{
    public class Emprestimo
    {
        private Usuario usuario;
        private Livro livro;
        private DateTime dataEmprestimo;
        private DateTime dataDevolucao;
        private StatusEmprestimo status;

        public Usuario Usuario { get => usuario; set => usuario = value; }
        public Livro Livro { get => livro; set => livro = value; }
        public DateTime DataEmprestimo { get => dataEmprestimo; set => dataEmprestimo = value; }
        public DateTime DataDevolucao { get => dataDevolucao; set => dataDevolucao = value; }
        public StatusEmprestimo Status { get => status; set => status = value; }

        public Emprestimo(Usuario usuario, Livro livro, DateTime dataEmprestimo, int prazoDias)
        {
            Usuario = usuario;
            Livro = livro;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataEmprestimo.AddDays(prazoDias);
            Status = StatusEmprestimo.Ativo;
            livro.MarcarComoEmprestado();
        }

        public void RegistrarDevolucao()
        {
            Status = StatusEmprestimo.Concluido;
            Livro.MarcarComoDevolvido();
        }

        public void ExibirResumo()
        {
            Console.WriteLine($"Usuário: {Usuario.Nome} ({Usuario.Tipo})");
            Console.WriteLine($"Livro: {Livro.Titulo}");
            Console.WriteLine($"Data do empréstimo: {DataEmprestimo.ToShortDateString()}");
            Console.WriteLine($"Data prevista de devolução: {DataDevolucao.ToShortDateString()}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine();
        }
    }
}