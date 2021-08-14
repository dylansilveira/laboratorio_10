using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorio10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa{Nome="Ana", DataNascimento=new DateTime(1980,3,14), Casada=true},
                new Pessoa{Nome="Paulo", DataNascimento=new DateTime(1978,10,23), Casada=true},
                new Pessoa{Nome="Maria", DataNascimento=new DateTime(2000,1,10), Casada=false},
                new Pessoa{Nome="Carlos", DataNascimento=new DateTime(1999,12,12), Casada=false}
            };

            var linq1 = 
                    from p in pessoas
                    where p.Casada && p.DataNascimento >= new DateTime(1980, 1, 1)
                    select p;

            Console.WriteLine("\nPessoas casadas que nasceram a partir de 1980:");
            foreach (var pessoa in linq1)
            {
                Console.WriteLine(pessoa);
            }

            var linq2 = pessoas.Where(p => p.Casada && p.DataNascimento >= new DateTime(1980, 1, 1));

            Console.WriteLine("\nPessoas casadas que nasceram a partir de 1980:");
            foreach (var pessoa in linq2)
            {
                Console.WriteLine(pessoa);
            }

            var grupos = pessoas.GroupBy(p => p.Casada);

            Console.WriteLine("\nPessoas agrupadas em casadas e solteiras:");
            foreach (var grupo in grupos)
            {
                Console.WriteLine((grupo.Key ? "Casados: " : "Solteiros: ") + grupo.Count());
                foreach (var p in grupo)
                {
                    Console.WriteLine(p);
                }
            }

            var maisVelho = pessoas.OrderBy(p => p.DataNascimento).First();
            Console.WriteLine($"\nPessoa mais velha:\n{maisVelho}");

            var maisNovoSolteiro = pessoas.Where(p => !p.Casada).OrderByDescending(p => p.DataNascimento).First();
            Console.WriteLine($"\nPessoa solteira mais nova:\n{maisNovoSolteiro}");
        }
    }
}