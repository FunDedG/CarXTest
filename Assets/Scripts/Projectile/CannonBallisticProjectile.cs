using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class CannonBallisticProjectile : ProjectileBehavior
    {

		private Rigidbody m_rb;
		private void Start()
		{
			m_rb = GetComponent<Rigidbody>();
			m_rb.velocity = transform.forward * m_speed;
		}
        protected override void Move()
        {
        }
    }
}
