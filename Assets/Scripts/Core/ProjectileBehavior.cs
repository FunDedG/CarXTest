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

        public virtual void Init(float speed, float damage, float lifeTime, GameObject target)
        {
            m_speed = speed;
            m_damage = damage;
            m_lifeTime = lifeTime;
        }

        protected virtual void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthComponent health))
            {
                health.TakeDamage(m_damage);
            }
            Destroy(gameObject);
        }

		protected virtual void Movement()
        {
            m_rb.velocity = transform.forward * m_speed;
        }

        protected virtual void Update() { }
		protected virtual void Start() { }
    }
}
