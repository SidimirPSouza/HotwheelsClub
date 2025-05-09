namespace HotwheelsClub.Models
{
    public class HotwheelsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Modelo { get; set; }
        public double preco {  get; set; }
        public string Cor {  get; set; }
        public int Ano { get; set; }
        public virtual UsuarioModel Dono { get; set; }
    }
}
