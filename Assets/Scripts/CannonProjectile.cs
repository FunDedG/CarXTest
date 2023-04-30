using UnityEngine;
using System.Collections;

namespace TestJob
{
    public class CannonProjectile : MonoBehaviour
    {
        private float m_speed;
        private float m_damage;

        public void Init(float speed, float damage)
        {
            m_speed = speed;
            m_damage = damage;
        }

        private void Update()
        {
            Move();
        }

        void OnTriggerEnter(Collider other)
        {
            var monster = other.gameObject.GetComponent<Enemy>();
            if (monster == null)
                return;

            monster.hp -= m_damage;
            if (monster.hp <= 0)
            {
                Destroy(monster.gameObject);
            }
            Destroy(gameObject);
        }

        private void Move()
        {
            transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
        }
    }
}
