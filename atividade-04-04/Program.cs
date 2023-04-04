namespace atividade_04_04
{
internal class Program
{
    static void Main(string[] args)
    {
        List<Carteira> carteiras = new List<Carteira>();
        string entrada;
        do
        {
            Console.WriteLine("Digite 1 para criar conta:");
            Console.WriteLine("Digite 2 para Acessar conta:");
            Console.WriteLine("Digite 3 para Listar Todas as contas:");
            Console.WriteLine("Digite 4 para sair:");

            entrada = Console.ReadLine();

            switch (entrada)
            {
                case "1":
                    Carteira novaCarteira = CriarConta();
                    carteiras.Add(novaCarteira);
                    break;
                case "3":
                    foreach (var c in carteiras)
                        Console.WriteLine(c.Dono);
                    break;
                case "2":
                    Console.WriteLine("Entre com Nome de acesso:");
                    string dono = Console.ReadLine();
                    Carteira catual = carteiras.FirstOrDefault(o => o.Dono == dono);
                    if (catual != null)
                        AcessarCarteira(catual, carteiras);
                    else
                        Console.WriteLine("Acesso negado!");
                    break;
            }
        } while (entrada != "4");

    }

    public static Carteira CriarConta()
    {
        string Nome; double Valor;
        Console.WriteLine("Entre com nome do Titular:");
        Nome = Console.ReadLine();
        Console.WriteLine("Entre com valor do 1 deposito:");
        Valor = Convert.ToDouble(Console.ReadLine());
        Carteira carteira = new Carteira();
        carteira.Dono = Nome;
        carteira.Depositar(Valor);
        return carteira;
    }

    public static void AcessarCarteira(Carteira carteira, List<Carteira> dados)
    {
        Console.WriteLine("Digite 1 para transferir");
        Console.WriteLine("Digite 2 para sacar");
        Console.WriteLine("Digite 3 para depositar");
        Console.WriteLine("Digite 4 para verificar saldo");
        string entrada = Console.ReadLine();

        switch (entrada)
        {
            case "1":
                Console.WriteLine("Entre com a carteira de destino");
                string dono = Console.ReadLine();

                Carteira destino = dados.FirstOrDefault(o => o.Dono == dono);
                if (destino == null)
                {
                    Console.WriteLine("Destinatio invalido");
                    return;
                }

                Console.WriteLine("Entre com valor:");
                double valor = Convert.ToDouble(Console.ReadLine());
                bool tOk = carteira.Transferir(destino, valor);

                if (tOk)
                    Console.WriteLine("Transferencia realizada com sucesso!");
                else
                    Console.WriteLine("ERRO- transacao abortada!");
                break;

            case "2":
                Console.WriteLine("Entre com a quantidade que deseja sacar:");
                double saque = Convert.ToDouble(Console.ReadLine());


                if (carteira.saldo < saque)
                {
                    Console.WriteLine("saldo insuficiente!!");
                    return;
                }
                else
                {
                    carteira.sacar(saque);
                    Console.WriteLine("Saque efetuado com sucesso!");
                }
                break;


            case "3":
                Console.WriteLine("Entre com um valor para deposito:");
                double deposito = Convert.ToDouble(Console.ReadLine());
                carteira.Depositar(deposito);
                break;

            case "4":

                Console.WriteLine("seu saldo é de:" + carteira.saldo);
                break;

        }



    }


}
}
