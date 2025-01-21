using System;
using System.Collections.Generic;
using System.Security.Cryptography;

class Program
{
    public static void Main(string[] args)
    {
        int opcao = 0;
        bool validacao = false;
        bool miniloop;

        while (validacao == false)
        {
            try
            {
                Console.WriteLine("\nBem-vindo a calculadora MMM (MediaModaMediana)!");
                Console.WriteLine("\n1 - Média\n2 - Moda\n3 - Mediana");
                Console.Write("\nSelecione uma opção (somente números): ");
                opcao = Convert.ToInt16(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.Write("Por favor, digite os números para realizar a média (separe os números usando espaço ' '): ");
                    string numerosMedia = Console.ReadLine();
                    string[] vetmedia = numerosMedia.Split(' ');

                    var resultado = Media(vetmedia);

                    Console.WriteLine($"\nA media é: {resultado}");
                }
                else if (opcao == 2)
                {
                    Console.Write("Por favor, digite os números para realizar a moda (separe os números usando espaço ' '): ");
                    string numerosMedia = Console.ReadLine();
                    string[] vetmedia = numerosMedia.Split(' ');

                    var resultado = Moda(vetmedia);

                    Console.WriteLine($"\nA moda é: {resultado}");
                }
                else if (opcao == 3)
                {
                    Console.Write("Por favor, digite os números para realizar a mediana (separe os números usando espaço ' '): ");
                    string numerosMedia = Console.ReadLine();
                    string[] vetmedia = numerosMedia.Split(' ');

                    var resultado = Mediana(vetmedia);

                    Console.WriteLine($"\nA mediana é: {resultado}");
                }
                else if (opcao != 1 || opcao != 2 || opcao != 3)
                {
                    Console.WriteLine("\nErro: Por favor, selecione uma das opções!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nErro: Por favor, digite um valor válido!\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro inesperado: {ex.Message}\n");
            }

            miniloop = false;

            while (miniloop == false)
            {
                Console.Write("\nDeseja fazer outra operação?(s/n): ");
                string? resposta = Console.ReadLine();

                if (resposta == "s")
                {
                    validacao = false;
                    miniloop = true;
                }
                else if (resposta == "n")
                {
                    validacao = true;
                    miniloop = true;
                    break;
                }
                else
                {
                    miniloop = false;
                    Console.WriteLine("\nPor favor, use apenas 's' ou 'n'!\n");
                }
            }
        }
    }

    static double Media(string[] vet)
    {
        double d1 = 0;

        for (int x = 0; x < vet.Length; x++)
        {
            d1 += Convert.ToDouble(vet[x]);
        }
        int d2 = vet.Length;
        double r = d1 / d2;

        return r;
    }

    static string Moda(string[] vet)
    {
        Dictionary<string, int> frequencia = new Dictionary<string, int>();

        foreach (var item in vet)
        {
            if (frequencia.ContainsKey(item))
            {
                frequencia[item]++;
            }
            else
            {
                frequencia[item] = 1;
            }
        }

        int maxFrequencia = 0;
        List<string> moda = new List<string>();

        foreach (var item in frequencia)
        {
            if (item.Value > maxFrequencia)
            {
                maxFrequencia = item.Value;
                moda.Clear();
                moda.Add(item.Key);
            }
            else if (item.Value == maxFrequencia)
            {
                moda.Add(item.Key);
            }
        }

        return string.Join(", ", moda);
    }

    static double Mediana(string[] vet)
    {
        Array.Sort(vet);
        int meio = vet.Length / 2;

        if (vet.Length % 2 != 0)
        {
            return Convert.ToDouble(vet[meio]);
        }
        else
        {
            return (Convert.ToDouble(vet[meio]) + Convert.ToDouble(vet[meio - 1])) / 2.0;
        }
    }
}