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
		private int m_idProjectile;
		public event Action<GameObject, int> onProjectileDeath;

		public virtual void Init(float speed, float damage, float lifeTime, int idProjectile, GameObject target)
        {
            m_speed = speed;
            m_damage = damage;
            m_lifeTime = lifeTime;
			m_spawnTime = Time.time;
			m_idProjectile = idProjectile;

			m_rb = GetComponent<Rigidbody>();
        
			if (m_rb != null)
			{
				Movement();
			}
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

        protected virtual void Update()
		{
			if (Time.time - m_spawnTime >= m_lifeTime)
			{
				InvokeProjectileAction();
			}
		}

		public void InvokeProjectileAction()
		{
			onProjectileDeath?.Invoke(gameObject, m_idProjectile);
		}
		protected virtual void Start() { }
    }
}
