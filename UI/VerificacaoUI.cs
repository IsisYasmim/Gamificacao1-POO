namespace Game1
{
    public class Verificacao
    {
        public static string VerificarNulidade(string entrada)
        {
            while(string.IsNullOrEmpty(entrada))
            {
                Console.WriteLine("O campo não pode ser nulo!");
                Console.WriteLine("Inisira um dado não nulo");
                entrada = Console.ReadLine();
            }
            return entrada;
        }
        public static int VerificarNumero(string entrada)
        {
            int numero;
            while(!int.TryParse(entrada, out numero))
            {
                Console.WriteLine("Por favor, digite apenas números");
                entrada = Console.ReadLine();
            }
            return numero;
        }

        public static double VerificarDouble(string entrada)
        {
            double numero;
            while (!double.TryParse(entrada, out numero))
            {
                Console.WriteLine("Por favor, digite apenas números (use ponto ao invés de virgula (exemplo: 5.99))");
                entrada = Console.ReadLine();
            }
            return numero;
        }
    }
}