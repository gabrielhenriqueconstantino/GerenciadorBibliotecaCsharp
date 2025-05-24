namespace BibliotecaPOO.Models
{
    public abstract class Usuario
    {
        private string nome;
        private int id;
        private string tipo;

        public string Nome { get => nome; set => nome = value; }
        public int Id { get => id; set => id = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public Usuario(string nome, int id, string tipo)
        {
            Nome = nome;
            Id = id;
            Tipo = tipo;
        }

        public abstract void ExibirInformacoes();
    }
}