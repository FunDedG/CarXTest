using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class MoveComponent : MonoBehaviour
    {
		private float m_speed;
		private Rigidbody m_rb;
		private Transform m_target;

		private void Start()
		{
			m_rb = GetComponent<Rigidbody>();
		}

		public void Init(EnemyData enemyData, Transform target)
		{
			m_speed = enemyData.speed;
			m_target = target;

		}

		public void MoveToTarget()
		{
			if (m_target == null)
				return;
			Vector3 direction = m_target.position - transform.position;
			m_rb.velocity = direction.normalized * m_speed;
		}
	}
}
