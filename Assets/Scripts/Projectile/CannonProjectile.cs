using UnityEngine;
using System.Collections;

namespace TestJob
{
    public class CannonProjectile : ProjectileBehavior, IProjectileInit
    {
		private Vector3 m_direction;

		private void Start()
		{
			m_direction = Vector3.forward * speed;
		}

        public void Init(float speed, float damage, GameObject target)
        {
            this.speed = speed;
            this.damage = damage;
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }

        protected override void Move()
        {
            transform.Translate(m_direction * Time.deltaTime);
        }
    }
}
