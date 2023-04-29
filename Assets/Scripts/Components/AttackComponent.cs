using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class AttackComponent : MonoBehaviour
    {
		private float m_lastAttackTime;
		private float m_attackInterval;
		private GameObject m_projectilePrefab;
		private GameObject m_projectileStartPosition;
		private float damage;
		private float speed;
	
		private void Start()
    	{
        	m_lastAttackTime = -m_attackInterval;
    	}
		public void Init(TowerData towerData, GameObject projectileStartPosition, GameObject projectilePrefab)
		{
			damage = towerData.damage;
			speed = towerData.projectileSpeed;
			m_attackInterval = towerData.shootInterval;
			m_projectileStartPosition = projectileStartPosition;
			m_projectilePrefab = projectilePrefab;
		}

		public void Attack(GameObject target)
		{
			if (target == null) return;

			// Проверяем, прошло ли достаточно времени с последней атаки
			if (Time.time - m_lastAttackTime < m_attackInterval) return;

			// Создаем новый экземпляр снаряда и передаем ему данные
			GameObject newProjectile = Instantiate(m_projectilePrefab, m_projectileStartPosition.transform.position, Quaternion.identity);
			CannonProjectile projectileBehaviour = newProjectile.GetComponent<CannonProjectile>();
			projectileBehaviour.Init(speed, damage);

			m_lastAttackTime = Time.time;
		}
    }
}
