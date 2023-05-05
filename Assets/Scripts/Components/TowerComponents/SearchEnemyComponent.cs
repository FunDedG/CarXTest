using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class SearchEnemyComponent : MonoBehaviour
    {
        private List<GameObject> m_enemiesInRange = new List<GameObject>();
		private float m_radius;

		public void Init(TowerData towerData)
		{
			this.m_radius = towerData.range;
		}

		private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
				m_enemiesInRange.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                m_enemiesInRange.Remove(other.gameObject);
            }
        }
        public GameObject GetTarget()
		{
			float minDistance = Mathf.Infinity;
			GameObject closestEnemy = null;

			foreach (GameObject enemy in m_enemiesInRange)
			{
				if (enemy != null)
				{
					float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
					if (distanceToEnemy <= m_radius && distanceToEnemy < minDistance)
					{
						minDistance = distanceToEnemy;
						closestEnemy = enemy;
					}
				}
			}
			return closestEnemy;
		}
    }
}
