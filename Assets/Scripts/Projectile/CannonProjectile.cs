using UnityEngine;
using System.Collections;

namespace TestJob
{
    public class CannonProjectile : ProjectileBehavior, IProjectileInit
    {
		private Vector3 m_direction;

		private void Start()
		{
			m_direction = Vector3.forward * m_speed;
			Destroy(gameObject, m_lifeTime);
		}

        public void Init(float speed, float damage, float lifeTime, GameObject target)
        {
            m_speed = speed;
            m_damage = damage;
			m_lifeTime = lifeTime;
		}

        protected override void Move()
        {
            transform.Translate(m_direction * Time.deltaTime);
        }
	}
}
