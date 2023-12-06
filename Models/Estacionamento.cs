using System;
using System.Collections.Generic;

namespace SistemaEstacionamento.Models
{
    public class Estacionamento
    {
        public decimal PrecoInicial { get; private set; }
        public decimal PrecoPorHora { get; private set; }
        private List<string> Veiculos { get; }

        public Estacionamento()
        {
            Veiculos = new List<string>();
        }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
            : this()
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo(string placa)
        {
            Veiculos.Add(placa);
            Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento.");
        }

        public void RemoverVeiculo(string placa)
        {
            if (Veiculos.Contains(placa))
            {
                Console.Write($"Digite a quantidade de horas que o veículo {placa} permaneceu estacionado: ");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorCobrado = CalcularValorCobrado(horas);
                    Console.WriteLine($"Valor cobrado pelo veículo {placa}: R${valorCobrado:F2}");
                    Veiculos.Remove(placa);
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Operação cancelada.");
                }
            }
            else
            {
                Console.WriteLine($"Veículo com placa {placa} não encontrado no estacionamento.");
            }
        }

        public void ListarVeiculos()
        {
            if (Veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
            else
            {
                Console.WriteLine("Veículos estacionados:");
                foreach (var veiculo in Veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
        }

        private decimal CalcularValorCobrado(int horas)
        {
            return PrecoInicial + (PrecoPorHora * horas);
        }
    }
}
