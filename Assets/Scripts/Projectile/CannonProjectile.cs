using UnityEngine;
using System.Collections;

namespace TestJob
{
    public class CannonProjectile : MonoBehaviour, IProjectileInit
    {
        private float m_speed;
        private float m_damage;
		private Vector3 m_direction;

		private void Start()
		{
			m_direction = Vector3.forward * m_speed;
		}

        public void Init(float speed, float damage, GameObject target)
        {
            m_speed = speed;
            m_damage = damage;
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            var monster = other.gameObject.GetComponent<EnemyController>();
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
            transform.Translate(m_direction * Time.deltaTime);
        }
    }
}
