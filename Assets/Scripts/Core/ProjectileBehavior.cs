using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public abstract class ProjectileBehavior : MonoBehaviour
    {
        protected Rigidbody m_rb;
        protected float m_speed;
        protected float m_damage;
        protected float m_lifeTime;
		private float m_spawnTime;
		public event Action<GameObject> onProjectileDeath;

		public virtual void Init(float speed, float damage, float lifeTime, GameObject target)
        {
            m_speed = speed;
            m_damage = damage;
            m_lifeTime = lifeTime;
			m_spawnTime = Time.time;
		}

        protected virtual void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthComponent health))
            {
                health.TakeDamage(m_damage);
            }
			InvokeProjectileAction();
		}

		protected virtual void Movement()
        {
            m_rb.velocity = transform.forward * m_speed;
        }

		public void InvokeProjectileAction()
		{
			onProjectileDeath?.Invoke(gameObject);
		}

        protected virtual void Update()
		{
			if (Time.time - m_spawnTime >= m_lifeTime)
			{
				InvokeProjectileAction();
			}
		}
		protected virtual void Start() { }
    }
}
