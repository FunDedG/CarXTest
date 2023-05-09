using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class AttackComponent : MonoBehaviour
    {
		private float m_lastAttackTime;
		private TowerData m_towerData;
		private GameObject m_projectilePrefab;
		private GameObject m_projectileStartPosition;
		
		public void Init(TowerData towerData, GameObject projectileStartPosition, GameObject projectilePrefab)
		{
			m_towerData = towerData;
			m_lastAttackTime = m_towerData.shootInterval;
			m_projectileStartPosition = projectileStartPosition;
			m_projectilePrefab = projectilePrefab;
		}

		public void Attack(GameObject target)
		{
			if (target == null) return;

			if (Time.time - m_lastAttackTime < m_towerData.shootInterval) return;

			GameObject newProjectile = Instantiate(m_projectilePrefab, m_projectileStartPosition.transform.position, Quaternion.identity);
			newProjectile.transform.rotation = m_projectileStartPosition.transform.rotation;
			var projectileInit = newProjectile.GetComponent<IProjectileInit>();
			projectileInit.Init(m_towerData.projectileSpeed, m_towerData.damage, m_towerData.lifeTime, target);

			m_lastAttackTime = Time.time;
		}
    }
}
