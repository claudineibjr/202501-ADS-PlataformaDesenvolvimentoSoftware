namespace Exemplo25_0_API_Pedidos.DTO
{
    public class ClienteDTOInput
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
    }

    public class ClienteDTOOutput
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public ClienteDTOOutput(string id, string nome, string email, string cpf)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.CPF = cpf;
        }
    }
}
