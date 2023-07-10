using UnityEngine;
using UnityEngine.UI;

namespace HEXRPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 100f;
        public Image fill;
            
        bool isDead = false;
        
        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            _maxHealth = Mathf.Max(_maxHealth - damage, 0);
            UpdateHealthBar();
            if (_maxHealth == 0)
            {
                Death();
            }
        }

        private void UpdateHealthBar()
        {
            float hpBar = _maxHealth / 100;
            fill.fillAmount = hpBar;
        }

        private void Death()
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<ActionManager>().CancelCurrentAction();
        }
    }
}