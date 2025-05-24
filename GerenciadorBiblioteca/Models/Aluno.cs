namespace BibliotecaPOO.Models
{
    public class Aluno : Usuario
    {
        private string curso;
        private string matricula;

        public string Curso { get => curso; set => curso = value; }
        public string Matricula { get => matricula; set => matricula = value; }

        public Aluno(string nome, int id, string curso, string matricula)
            : base(nome, id, "Aluno")
        {
            Curso = curso;
            Matricula = matricula;
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Curso: {Curso}");
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine();
        }
    }
}