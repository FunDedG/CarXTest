using UnityEngine;
using System.Collections;

namespace TestJob
{
    public class CannonProjectile : ProjectileBehavior
    {
		private Vector3 m_direction;

		private void Start()
		{
			m_direction = Vector3.forward * m_speed;
			Destroy(gameObject, m_lifeTime);
		}
        protected override void Move()
        {
            transform.Translate(m_direction * Time.deltaTime);
        }
	}
}
