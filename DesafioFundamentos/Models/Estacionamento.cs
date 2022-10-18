namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string repetir = "S";

            while (repetir != "N") {
                Console.Write("Digite a placa do veículo para estacionar: ");

                string placa = Console.ReadLine();

                if (placa == String.Empty || placa.Length != 8) {
                    Console.WriteLine("Placa digitada inválida");
                } else {
                    veiculos.Add(placa);

                    Console.WriteLine("Veículo incluído com sucesso!");
                    Console.Write("Deseja incluir outro veículo (S/N): ");

                    repetir = Console.ReadLine().ToUpper();
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0;
                bool repetir = true;

                while (repetir){
                    Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");

                    bool valido = Int32.TryParse(Console.ReadLine(), out horas);

                    if (!valido){
                        Console.WriteLine("Valor informado náo é válido");
                    } else {
                        veiculos.Remove(placa);
                        valorTotal = precoInicial + (precoPorHora * horas);
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                        repetir = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string veiculo in veiculos) {
                    Console.WriteLine("Veículo placa " + veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}