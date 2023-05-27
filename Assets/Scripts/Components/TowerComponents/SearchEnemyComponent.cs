using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
	public class SearchEnemyComponent : MonoBehaviour
	{
		private List<GameObject> m_enemiesInRange = new List<GameObject>();
		private GameObject m_lastTarget;
		private float m_radius;

		public void Init(TowerData towerData)
		{
			m_radius = towerData.range;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Enemy"))
			{
				Debug.Log("Add " + other.gameObject.name + " in list");
				m_enemiesInRange.Add(other.gameObject);
				HealthComponent death = other.gameObject.GetComponent<HealthComponent>();
                death.onDeath += RemoveFromList;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Enemy"))
			{
				m_enemiesInRange.Remove(other.gameObject);
				if (m_enemiesInRange.Count == 0)
				{
					m_lastTarget = null;
				}
			}
		}

		public void RemoveFromList(GameObject enemy)
		{
			HealthComponent death = enemy.GetComponent<HealthComponent>();
            death.onDeath -= RemoveFromList;
			m_enemiesInRange.Remove(enemy);
			if (m_enemiesInRange.Count == 0)
			{
				m_lastTarget = null;
			}
		}

		public GameObject GetTarget()
		{
			float minDistance = Mathf.Infinity;
			Vector3 positionTower = transform.position;

			if (m_enemiesInRange.Count == 0)
			{
				m_lastTarget = null;
				return null;
			}

			if (m_lastTarget != null)
			{
				float sqrDistanceToLastTarget = (m_lastTarget.transform.position - positionTower).sqrMagnitude;
				if (sqrDistanceToLastTarget <= m_radius * m_radius)
				{
					return m_lastTarget;
				}
			}

			foreach (GameObject enemy in m_enemiesInRange)
			{
				if (enemy && enemy.TryGetComponent(out Transform enemyTransform))
				{
					Vector3 direction = enemyTransform.position - positionTower;
					float sqrDistanceToEnemy = direction.sqrMagnitude;

					if (sqrDistanceToEnemy <= m_radius * m_radius && sqrDistanceToEnemy < minDistance)
					{
						minDistance = sqrDistanceToEnemy;
						m_lastTarget = enemy;
					}
				}
			}
			return m_lastTarget;
		}
	}
}
