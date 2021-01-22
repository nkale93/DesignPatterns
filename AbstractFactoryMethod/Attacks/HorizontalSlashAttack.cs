using System;

namespace AbstractFactoryMethod
{
    internal class HorizontalSlashAttack : IAttack
    {
        public int Damage(int maxDamage)
        {
            Random random = new Random();

            int damage = random.Next(1, maxDamage);

            return damage;
        }
    }
}