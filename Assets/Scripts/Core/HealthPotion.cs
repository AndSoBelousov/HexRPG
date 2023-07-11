using UnityEngine;

namespace HEXRPG.Core
{
    public class HealthPotion : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //���������, ���������� �� �������� � ��������
            if (other.CompareTag("Player"))
            {
                //�������� ��������� �������� ���������
                Health health = other.GetComponent<Health>();
    
                //���������, ���� �� � ��������� ��������� ��������
                if (health != null)
                {
                    health.Heal();
                    
                    //������� ����� ��
                    Destroy(gameObject);
                }
            }
        }
    }
}

