using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public abstract class EnemyBehavior : MonoBehaviour
    {
		[SerializeField] protected EnemyData enemyData;
		protected Transform m_target;
		protected MoveComponent m_moveComponent;
		protected HealthComponent m_healthComponent;

		public virtual void Init(Transform target)
		{
			m_target = target;
		}

		protected virtual void Start()
		{
			m_moveComponent = GetComponent<MoveComponent>();
			m_healthComponent = GetComponent<HealthComponent>();
			m_moveComponent.Init(enemyData, m_target);
			m_healthComponent.Init(enemyData);
		}
		private void FixedUpdate()
		{
			m_moveComponent.MoveToTarget();
		}
	}
}
