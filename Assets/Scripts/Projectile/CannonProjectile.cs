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

        public override void Update()
        {
            base.Update();
        }

        public override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }

        public override void Move()
        {
            transform.Translate(m_direction * Time.deltaTime);
        }
    }
}
