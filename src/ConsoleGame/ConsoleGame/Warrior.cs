using System;

namespace ConsoleGame
{
    public class Warrior
    {

        private readonly string _nome; // Nome 
        private double _life; // Vida
        public bool Dead; // Está Vivo ?
        private double _armor; // Armor
        private double _stamina; // Stamina
        private readonly Random _rand;
        
        public Warrior(string nome, double life, double armor, double stamina)
        {
            this._nome = nome;
            this._life = life;
            this.Dead = false;
            this._armor = armor;
            this._stamina = stamina;
            this._rand = new Random();
        }

        private void Attack(Warrior enemy)
        {
            var damageWeaponR = _rand.Next(15, 25); // Número aleatório (simula o dano em diferentes zonas)
            var damageWeapon = (_stamina / 100) * damageWeaponR; // Calcula o damage considerando a stamina
            if (_stamina - damageWeapon >= 0) // Confirma que a stamina não fica negativa
            {
                _stamina -= damageWeapon;
            }
            else
            {
                _stamina = 0;
            }
            Console.WriteLine($"{_nome} deu {damageWeapon:N2} de dano, ficou com {_stamina:N2} de stamina");
            enemy.Damage(damageWeapon, _nome); // Aplica o damage ao inimigo
        }

        private void Descansar()
        {
            if (_stamina + 15 > 60) // Verifica se a stamina não é maior que os 50
            {
                _stamina = 60;
            }
            else
            {
                _stamina += 15;
            }
            
            Console.WriteLine($"{_nome} não atacou, a stamina aumentou para {_stamina:N2} \n");
        }

        private void Damage(double damage, string nome)
        {
            var damageBack = damage; // Cria um backup do damage
            if (_armor > 0) // Confirma se ainda tem armor
            {
                damage -= _armor; // Se o resultado for negativo quer dizer que tem suficiente armor para aguentar o damage
                if (damage < 0)
                {
                    _armor = -(damage); // Torna o damage positivo e igual a armor, pois a subtração já está feita
                }
                else
                {
                    _armor = 0; // Igual a armor a zero
                    _life -= damage; // Subtrai o resto do damage à life
                }
            } 
            else // Já não tem armor
            {
                _life -= damage; // Subtrai o damage à life
                if (_life <= 0) // Verifica se a vida for menor ou igual a zero
                {
                    Dead = true; // Fica morto, o método Play da Class AutoGameplay já não executa mais nenhum Ataque/Descanso
                    _life = 0; // Mete a Life a 0 para aparecer 0 e não um número negativo
                }
            }

            Console.WriteLine($"{_nome} levou {damageBack:N2} de dano, tem {_life:N2} de vida, {_armor:N2} de armor \n");
            // Não é necessário dizer a stamina, pk ao receber dano a stamina não muda
            if (Dead) // Verifica se está morto
            {
                Morreu(nome); // Chama o método Morreu
            }

        }

        public void AttackDescansar(int probs, Warrior enemy)
        {
            if (probs > _stamina) // Se as probs forem maiores que a _stamina Descansa
            {
                Descansar();
            }
            else
            {
                Attack(enemy);
            }
        }

        private void Morreu(string nome)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{_nome} morreu!");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{nome} Ganhou!");
            Console.ResetColor();
        }

    }
}