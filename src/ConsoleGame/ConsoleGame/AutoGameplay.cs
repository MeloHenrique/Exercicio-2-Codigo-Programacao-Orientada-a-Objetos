using System;

namespace ConsoleGame
{
    public class AutoGameplay
    {

        private readonly Warrior _warrior1;
        private readonly Warrior _warrior2;
        private bool _turn; // Controla o turno dos jogadores
        private readonly Random _rand;
        
        public AutoGameplay(Warrior warrior1, Warrior warrior2)
        {
            this._warrior1 = warrior1;
            this._warrior2 = warrior2;
            this._turn = true;
            this._rand = new Random();
        }

        public void Play()
        {

            while (!_warrior1.Dead && !_warrior2.Dead) // Enquanto nenhum jogador estiver morto executa
            {
                var attackRest = _rand.Next(0, 80); // Número random que controla se o jogador vai atacar ou descansar

                if (_turn)
                {
                    _warrior1.AttackDescansar(attackRest, _warrior2);
                }
                else
                {
                    _warrior2.AttackDescansar(attackRest, _warrior1);
                }

                _turn = !_turn; // Muda o turno para o outro jogador

            }

        }
        
    }
}