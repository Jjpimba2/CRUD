namespace CRUD.Model
{
    public class Cliente
    {
        public int Id { get; set; } // chave primária
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}