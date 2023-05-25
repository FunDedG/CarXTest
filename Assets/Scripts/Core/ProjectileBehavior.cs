using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public abstract class ProjectileBehavior : MonoBehaviour
    {
		protected float m_speed;
		protected float m_damage;
		protected float m_lifeTime;
		protected virtual void Update()
        {
            Move();
        }
		
        protected virtual void OnCollisionEnter(Collision other)
        {
			if(other.gameObject.TryGetComponent<HealthComponent>(out HealthComponent health))
			{
				health.TakeDamage(m_damage);
			}
			Destroy(gameObject);
		}

		public virtual void Init(float speed, float damage, float lifeTime, GameObject target)
		{
			m_speed = speed;
			m_damage = damage;
			m_lifeTime = lifeTime;
		}

		protected abstract void Move();
	}
}
