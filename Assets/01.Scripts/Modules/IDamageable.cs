namespace _01.Scripts.Modules
{
    public interface IDamageable
    {
        void GetDamage(float damage, IAttackable attacker);
        void GetHeal(float heal);
    }
}