using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public abstract class ProjectileBehavior : MonoBehaviour
    {
		protected float m_speed;
		protected float m_damage;
		protected virtual void Update()
        {
            Move();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
			if(other.gameObject.TryGetComponent<HealthComponent>(out HealthComponent health))
			{
				health.TakeDamage(m_damage);
			}
			Destroy(gameObject);
		}

		protected abstract void Move();
	}
}
