using System.Globalization;

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




        public void AdicionarVeiculo(string veiculo)
        {

            veiculos.Add(veiculo);

        }

        public void RemoverVeiculo(string placa, int horas)
        {
       
            decimal valorTotal = precoInicial + precoPorHora * horas;


            veiculos.Remove(placa);
            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

        }

        //Verifica se o veículo existe
        public bool ConsultarVeiculo(string placa)
        {

            return veiculos.Any(x => x.ToUpper() == placa.ToUpper());

        }

        public List<string> ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");


                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }

            }

            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }

            return veiculos; 

        }

    }
}
