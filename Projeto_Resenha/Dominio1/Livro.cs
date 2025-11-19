namespace Projeto_Resenha.Dominio1
{
    public class Livro
    {
        
        private int pkid_livro;
        private string titulo;
        private string genero;
        private int fkid_autor;
        private DateTime ano_publicacao;

        
        public Livro() { }

        public Livro(int pkid_livro, string titulo, string genero, int fkid_autor, DateTime ano_publicacao)
        {
            this.pkid_livro = pkid_livro;
            this.titulo = titulo;
            this.genero = genero;
            this.fkid_autor = fkid_autor;
            this.ano_publicacao = ano_publicacao;
        }

        
        public int getPkid_livro()
        {
            return pkid_livro;
        }

        public void setPkid_livro(int pkid_livro)
        {
            this.pkid_livro = pkid_livro;
        }

        public string getTitulo()
        {
            return titulo;
        }

        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public string getGenero()
        {
            return genero;
        }

        public void setGenero(string genero)
        {
            this.genero = genero;
        }

        public int getFkid_autor()
        {
            return fkid_autor;
        }

        public void setFkid_autor(int fkid_autor)
        {
            this.fkid_autor = fkid_autor;
        }

        public DateTime getAno_publicacao()
        {
            return ano_publicacao;
        }

        public void setAno_publicacao(DateTime ano_publicacao)
        {
            this.ano_publicacao = ano_publicacao;
        }

        
        public int pkid_livro_prop
        {
            get { return pkid_livro; }
            set { pkid_livro = value; }
        }

        public string titulo_prop
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string genero_prop
        {
            get { return genero; }
            set { genero = value; }
        }

        public int fkId_autor_prop
        {
            get { return fkid_autor; }
            set { fkid_autor = value; }
        }

        public DateTime ano_publicacao_prop
        {
            get { return ano_publicacao; }
            set { ano_publicacao = value; }
        }

        
        public Autor Autor { get; set; }
    }
}
