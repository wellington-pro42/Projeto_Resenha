namespace Projeto_Resenha.Dominio1
{
    public class Autor
    {
        
        private int pkid_autor;
        private string nome;
        private string nacionalidade;
        private DateTime data_nascimento;

        
        public Autor() { }

        public Autor(int pkid_autor, string nome, string nacionalidade, DateTime data_nascimento)
        {
            this.pkid_autor = pkid_autor;
            this.nome = nome;
            this.nacionalidade = nacionalidade;
            this.data_nascimento = data_nascimento;
        }

        
        public int getPkid_autor() => pkid_autor;
        public void setPkid_autor(int pkid_autor) => this.pkid_autor = pkid_autor;

        public string getNome() => nome;
        public void setNome(string nome) => this.nome = nome;

        public string getNacionalidade() => nacionalidade;
        public void setNacionalidade(string nacionalidade) => this.nacionalidade = nacionalidade;

        public DateTime getData_nascimento() => data_nascimento;
        public void setData_nascimento(DateTime data_nascimento) => this.data_nascimento = data_nascimento;

        
        public int pkid_autor_prop { get => pkid_autor; set => pkid_autor = value; }
        public string nome_prop { get => nome; set => nome = value; }
        public string nacionalidade_prop { get => nacionalidade; set => nacionalidade = value; }
        public DateTime data_nascimento_prop { get => data_nascimento; set => data_nascimento = value; }

        
        public ICollection<Livro> Livros { get; set; }
    }
}
