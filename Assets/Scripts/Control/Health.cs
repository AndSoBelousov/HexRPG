using UnityEngine;
using UnityEngine.UI;

namespace HEXRPG.Control
{
    public class Health : MonoBehaviour
    {
        [Tooltip("Полоска хп")] public Image healthBarFill;

        [Tooltip("Максимальное количество ХП")] 
        [SerializeField] private float _maxHealth = 100f;

        [Tooltip("Количество ХП в данный момент")] 
        [SerializeField] private float _currentHealth;

        private float MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        private float CurrentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = value; }
        }


        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        private void Update()
        {
            UpdateHealthBar();
        }

        //Получение урона (уменьшение полоски хп)
        public void TakeDamage(float damage)
        {
        }

        //Обновление полоски хп
        private void UpdateHealthBar()
        {
            float healthBar = CurrentHealth / MaxHealth;
            healthBarFill.fillAmount = healthBar;

            if (CurrentHealth <= 0)
                healthBarFill.fillAmount = 0;
        }
    }
}