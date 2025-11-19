namespace Projeto_Resenha.Dominio1
{
    public class Resenha
    {
        
        private int pkid_resenha;
        private int fk_usuario;
        private int fk_livro;
        private string titulo;
        private string conteudo;

        
        public Resenha() { }

        public Resenha(int pkid_resenha, int fk_usuario, int fk_livro, string titulo, string conteudo)
        {
            this.pkid_resenha = pkid_resenha;
            this.fk_usuario = fk_usuario;
            this.fk_livro = fk_livro;
            this.titulo = titulo;
            this.conteudo = conteudo;
        }

        
        public int getPkid_resenha() => pkid_resenha;
        public void setPkid_resenha(int pkid_resenha) => this.pkid_resenha = pkid_resenha;

        public int getFk_usuario() => fk_usuario;
        public void setFk_usuario(int fk_usuario) => this.fk_usuario = fk_usuario;

        public int getFk_livro() => fk_livro;
        public void setFk_livro(int fk_livro) => this.fk_livro = fk_livro;

        public string getTitulo() => titulo;
        public void setTitulo(string titulo) => this.titulo = titulo;

        public string getConteudo() => conteudo;
        public void setConteudo(string conteudo) => this.conteudo = conteudo;

        
        public int pkid_resenha_prop { get => pkid_resenha; set => pkid_resenha = value; }
        public int fk_usuario_prop { get => fk_usuario; set => fk_usuario = value; }
        public int fk_livro_prop { get => fk_livro; set => fk_livro = value; }
        public string titulo_prop { get => titulo; set => titulo = value; }
        public string conteudo_prop { get => conteudo; set => conteudo = value; }

        
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
    }
}
