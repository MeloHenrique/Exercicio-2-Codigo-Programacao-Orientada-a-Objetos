using System;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            
            Console.Write("Nome do Jogador 1:");
            var warrior1 = new Warrior(Console.ReadLine(), 100, rand.Next(30, 61), rand.Next(35, 61)); // Cria o primeiro objeto
            Console.Write("Nome do Jogador 2:");
            var warrior2 = new Warrior(Console.ReadLine(), 100, rand.Next(30, 61), rand.Next(35, 61)); // Cria o segundo objeto
            
            var gamePlay = new AutoGameplay(warrior1, warrior2); // Cria o objeto que controla o modo de jogo
            gamePlay.Play(); // Inicia o jogo
        }
    }
}