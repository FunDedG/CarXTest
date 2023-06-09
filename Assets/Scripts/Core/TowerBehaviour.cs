using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
	public abstract class TowerBehaviour : MonoBehaviour
	{
		[SerializeField] protected TowerData towerData;
		[SerializeField] protected GameObject projectilePosition;
		[SerializeField] protected List<ProjectileBehavior> projectilePrefabs;
		protected AttackComponent m_attackComponent;
		protected SearchEnemyComponent m_searchEnemyComponent;
		protected SphereCollider m_sphereCollider;
		
		protected virtual void Start()
		{
			m_attackComponent = GetComponent<AttackComponent>();
			m_searchEnemyComponent = GetComponent<SearchEnemyComponent>();
			m_sphereCollider = GetComponent<SphereCollider>();
			m_sphereCollider.radius = towerData.range;
			m_attackComponent.Init(towerData, projectilePosition, projectilePrefabs);
			//m_attackComponent.GetProjectilePrefab(projectilePrefab);
			m_searchEnemyComponent.Init(towerData);
		}
		protected virtual void Attack()
		{
			if (m_searchEnemyComponent.GetTarget())
			{
				m_attackComponent.Attack(m_searchEnemyComponent.GetTarget());
			}
		}
		protected virtual void Update()
		{
			Attack();
		}
	}
}
