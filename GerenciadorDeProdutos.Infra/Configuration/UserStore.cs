namespace GerenciadorDeProdutos.Infra.Configuration
{
    public static class UserStore
    {
        public static List<(string Username, string Password, string Role)> Users = new()
    {
        ("gerente", "123456", "Gerente"),
        ("funcionario", "123456", "Funcionario"),
        ("cliente", "123456", "Cliente")
    };
    }
}
