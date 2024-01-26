using System.Globalization;
using System.Runtime.CompilerServices;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private const int capacidadeMaxima = 5;
        private Dictionary<string, DateTime> horarioEntrada = new Dictionary<string, DateTime>();
        

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public bool ValidarPlaca(string placa)
        {
            
            if (placa.Length != 7)
                return false;

            
            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(placa[i]))
                    return false;
            }

            
            for (int i = 3; i < 7; i++)
            {
                if (!char.IsDigit(placa[i]))
                    return false;
            }

            return true;
        }


        public void AdicionarVeiculo(string veiculo)
        {

            if (veiculos.Count >= capacidadeMaxima)
            {
                Console.WriteLine("Capacidade máxima do estacionamento atingida. Não é possível adicionar mais veículos.");
                return;
            }

            if (ValidarPlaca(veiculo))
            {
                veiculos.Add(veiculo);
                horarioEntrada[veiculo] = DateTime.Now; 
                Console.WriteLine($"Veículo {veiculo} adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida. A placa deve estar no formato Mercosul (3 letras e 4 números).");
            }

        }

        public void RemoverVeiculo(string placa)
        {

            DateTime entrada = horarioEntrada[placa];
            DateTime saida = DateTime.Now;
            TimeSpan tempoEstacionado = saida - entrada;


            string tempoFormatado = String.Format("{0} hora(s) e {1} minuto(s)",
                                                 tempoEstacionado.Hours,
                                                 tempoEstacionado.Minutes);
         
            
            int horas = (int)Math.Ceiling(tempoEstacionado.TotalHours);
            

            decimal valorTotal = precoInicial + precoPorHora * horas;
            veiculos.Remove(placa);
            horarioEntrada.Remove(placa); 
            Console.WriteLine($"O veículo {placa} foi removido, o tempo estacionado foi de {tempoFormatado} e o preço total foi de: R$ {valorTotal}");

        }

        
        public bool ConsultarVeiculo(string placa)
        {

            return veiculos.Any(x => x.ToUpper() == placa.ToUpper());

        }

        public List<string> ListarVeiculos()
        {
            
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
