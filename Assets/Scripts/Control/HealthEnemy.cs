using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        _maxHealth = Mathf.Max(_maxHealth - damage, 0);
        if (_maxHealth == 0)
        {
            Death();
        }
    }

    private void Death()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("DeathSkeleton");
    }
}
