using System;
using Seliazacao_Json.Servide;

namespace Seliazacao_Json
{
    public class Input_Data
    {
        private static Serialization _serialization;
        public static void Main(string[] args)
        {
            while (true)
            {
                _serialization = new Serialization();
                Console.WriteLine("Serializar 'S' ou Deserializar 'D'");
                var Comando = Console.ReadLine();

                if (Comando.Equals("S"))
                {
                    Console.Write("Digite o nome: ");
                    var nome = Console.ReadLine();
                    Console.Write("Digite a idade: ");
                    var idade = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        _serialization.Serializar(nome, idade);
                        Console.WriteLine("Concluido");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.Message);
                    }                    

                }
                else if (Comando.Equals("D"))
                {
                    try
                    {
                        var pessoas = _serialization.Deserializar();
                        foreach (var p in pessoas)
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine("Nome: " + p.Nome);
                            Console.WriteLine("Idade: " + p.Idade);
                            Console.WriteLine("-------------------------");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.Message);
                    }
                }

                Console.WriteLine("Pressione qualquer tecla para continuar e 'S' para sair");
                var sair = Console.ReadKey();
                if (sair.Key == ConsoleKey.S)
                    break;
                Console.Clear();
            }
        }
    }
}
