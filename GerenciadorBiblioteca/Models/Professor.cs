namespace BibliotecaPOO.Models
{
    public class Professor : Usuario
    {
        private string departamento;
        private string registro;

        public string Departamento { get => departamento; set => departamento = value; }
        public string Registro { get => registro; set => registro = value; }

        public Professor(string nome, int id, string departamento, string registro)
            : base(nome, id, "Professor")
        {
            Departamento = departamento;
            Registro = registro;
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Registro: {Registro}");
            Console.WriteLine();
        }
    }
}