namespace Game1{
  public class Categoria{
    public int Id { get; set; } // propriedade nome mais
    public String Nome { get; set; }
    public String Descricao { get; set; }
    
    public Categoria(int id, string nome, string descricao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
        }
    
         public override string ToString()
        {
            return string.Format("{0}", Nome);
        }
  }
}