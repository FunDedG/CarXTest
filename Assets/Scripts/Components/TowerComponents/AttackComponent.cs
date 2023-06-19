using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class AttackComponent : MonoBehaviour
	{
		[SerializeField] private int m_sizePool;
		[SerializeField] private List<Transform> m_projectileContainers;
		private List<ProjectileBehavior> m_projectilePrefabs;
		private float m_lastAttackTime;
		private TowerData m_towerData;
		private GameObject m_projectileStartPosition;
		private int indexProjectile = 0;

		private List<ObjectPoolManager<ProjectileBehavior>> m_projectilePools;

		public void Init(TowerData towerData, GameObject projectileStartPosition, List<ProjectileBehavior> projectilePrefabs)
		{
			m_towerData = towerData;
			m_lastAttackTime = m_towerData.shootInterval;
			m_projectileStartPosition = projectileStartPosition;
			m_projectilePrefabs = projectilePrefabs;

			m_projectilePools = new List<ObjectPoolManager<ProjectileBehavior>>();

			for (int i = 0; i < m_projectilePrefabs.Count; i++)
			{
				ObjectPoolManager<ProjectileBehavior> projectilePool = new (m_projectilePrefabs[i], m_sizePool, m_projectileContainers[i]);
				m_projectilePools.Add(projectilePool);
			}
		}

		public void ChangeProjectile(int index)
		{
			indexProjectile = index;
		}

		public void Attack(GameObject target)
		{
			if (target == null) return;

			if (Time.time - m_lastAttackTime < m_towerData.shootInterval) return;

			ProjectileBehavior projectile = m_projectilePools[indexProjectile].GetObject();
			projectile.transform.position = m_projectileStartPosition.transform.position;
			projectile.transform.rotation = m_projectileStartPosition.transform.rotation;

			//var projectileInit = projectile.GetComponent<ProjectileBehavior>();
			projectile.Init(m_towerData.projectileSpeed, m_towerData.damage, m_towerData.lifeTime, target);

			m_lastAttackTime = Time.time;
		}
	}
}
