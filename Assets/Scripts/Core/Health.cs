using System;
using UnityEngine;
using UnityEngine.UI;
using HEXRPG.GUI;

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

        public void Heal()
        {
            _maxHealth += 100; //Увеличиваем текущее здоровье на заданное значение
            UpdateHealthBar();
            if (_maxHealth > 100)
            {
                _maxHealth = 100; //Убеждаемся, что текущее здоровье не превышает максимальное значение
            }
        }
        
        private void Death()
        {
            if (isDead) return;
            isDead = true;
            if (CompareTag("Player"))
            {
                GetComponent<Animator>().SetTrigger("Death");
                FindObjectOfType<GameOverScript>().ShowGameOverMenu();
            }
            else
            {
                if (CompareTag("BossEnemy"))
                {
                    GetComponent<Animator>().SetTrigger("Death");
                    FindObjectOfType<WinPanel>().ShowWinPanel();
                }
                GetComponent<Animator>().SetTrigger("Death");
            }
            GetComponent<ActionManager>().CancelCurrentAction();
        }
    }
}