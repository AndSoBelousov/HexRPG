using UnityEngine;

namespace HEXRPG.Core
{
    public class HealthPotion : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //проверяем, столкнулся ли персонаж с аптечкой
            if (other.CompareTag("Player"))
            {
                //получаем компонент здоровья персонажа
                Health health = other.GetComponent<Health>();
    
                //проверяем, есть ли у персонажа компонент здоровья
                if (health != null)
                {
                    health.Heal();
                    
                    //удаляем банку хп
                    Destroy(gameObject);
                }
            }
        }
    }
}

