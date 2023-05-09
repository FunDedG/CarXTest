using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class AttackComponent : MonoBehaviour
    {
		private float m_lastAttackTime;
		private float m_attackInterval;
		private float m_damage;
		private float m_speed;
		private GameObject m_projectilePrefab;
		private GameObject m_projectileStartPosition;
		
		private void Start()
    	{
        	m_lastAttackTime = -m_attackInterval;
    	}
		public void Init(TowerData towerData, GameObject projectileStartPosition, GameObject projectilePrefab)
		{
			m_damage = towerData.damage;
			m_speed = towerData.projectileSpeed;
			m_attackInterval = towerData.shootInterval;
			m_projectileStartPosition = projectileStartPosition;
			m_projectilePrefab = projectilePrefab;
		}

		public void Attack(GameObject target)
		{
			if (target == null) return;

			if (Time.time - m_lastAttackTime < m_attackInterval) return;

			GameObject newProjectile = Instantiate(m_projectilePrefab, m_projectileStartPosition.transform.position, Quaternion.identity);
			newProjectile.transform.rotation = m_projectileStartPosition.transform.rotation;
			var projectileInit = newProjectile.GetComponent<IProjectileInit>();
			projectileInit.Init(m_speed, m_damage, target);

			m_lastAttackTime = Time.time;
		}
    }
}
