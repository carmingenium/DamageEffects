public interface IDamagable
{
    // This script is to handle numbers for damages and health, not necessarily related to demo
    public void TakeDamage(float dmg);
    public void Die();
    public void Heal(float heal);
    public void Revive();
}