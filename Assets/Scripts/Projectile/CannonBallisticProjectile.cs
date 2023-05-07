using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class CannonBallisticProjectile : ProjectileBehavior, IProjectileInit
    {
		private Vector3 m_gravity = Physics.gravity;
		private Vector3 m_initialVelocity = Vector3.forward;
		private Vector3 m_velocity;

		private void Start()
		{
			m_velocity = Vector3.forward * speed;
		}
		public void Init(float speed, float damage, GameObject target)
        {
            this.speed = speed;
            this.damage = damage;
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Move()
        {
            Vector3 newPosition = transform.position + m_velocity * Time.deltaTime;
            m_velocity += m_gravity * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}
