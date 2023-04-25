using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestJob
{
	public class CannonTower : TowerBehaviour
	{
		private AttackComponent m_attackComponent;
		private SearchEnemyComponent m_searchEnemyComponent;
		private SphereCollider m_sphereCollider;

		public void Awake()
		{
			m_attackComponent = GetComponent<AttackComponent>();
			m_searchEnemyComponent = GetComponent<SearchEnemyComponent>();
			m_sphereCollider = GetComponent<SphereCollider>();
			m_sphereCollider.radius = towerData.range;
			m_attackComponent.Init(towerData);
			m_searchEnemyComponent.Init(towerData);
		}
		public override void Attack()
		{

		}
	}
}
