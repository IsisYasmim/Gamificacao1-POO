namespace Game1{
  public class Categoria{
    public int id { get; set; }
    public String nome { get; set; }
    public String descricao { get; set; }
    
    public Categoria(int id, string nome, string descricao)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
        }
    
         public override string ToString()
        {
            return string.Format("{0}", nome);
        }
  }
}