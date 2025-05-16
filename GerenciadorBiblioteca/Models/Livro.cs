using BibliotecaPOO.Enums;
using GerenciadorBiblioteca.Enums;

namespace BibliotecaPOO.Models
{
    public class Livro
    {
        private string titulo;
        private string autor;
        private int ano;
        private string isbn;
        private StatusLivro status;

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public int Ano { get => ano; set => ano = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public StatusLivro Status { get => status; set => status = value; }

        public Livro(string titulo, string autor, int ano, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Isbn = isbn;
            Status = StatusLivro.Disponivel;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"ISBN: {Isbn}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine();
        }

        public void MarcarComoEmprestado()
        {
            Status = StatusLivro.Emprestado;
        }

        public void MarcarComoDevolvido()
        {
            Status = StatusLivro.Disponivel;
        }
    }
}