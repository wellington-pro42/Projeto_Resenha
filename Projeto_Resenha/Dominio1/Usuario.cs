using ProjetoResenha.Models;

namespace Projeto_Resenha.Dominio1
{
    public class Usuario
    {
        
        private int pkid_usuario;
        private string nome;
        private string email;
        private string senha;

        
        public Usuario() { }

        public Usuario(int pkid_usuario, string nome, string email, string senha)
        {
            this.pkid_usuario = pkid_usuario;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
        }

     
        public int getPkid_usuario() => pkid_usuario;
        public void setPkid_usuario(int pkid_usuario) => this.pkid_usuario = pkid_usuario;

        public string getNome() => nome;
        public void setNome(string nome) => this.nome = nome;

        public string getEmail() => email;
        public void setEmail(string email) => this.email = email;

        public string getSenha() => senha;
        public void setSenha(string senha) => this.senha = senha;

        
        public int pkid_usuario_prop { get => pkid_usuario; set => pkid_usuario = value; }
        public string nome_prop { get => nome; set => nome = value; }
        public string email_prop { get => email; set => email = value; }
        public string senha_prop { get => senha; set => senha = value; }

        
        public ICollection<Resenha> Resenhas { get; set; }
    }
}
