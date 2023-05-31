using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class HealthComponent : MonoBehaviour
    {
		public event Action<GameObject> onDeath;
		private float m_health;
		
		public void Init(EnemyData enemyData)
		{
			m_health = enemyData.health;
		}

		public void TakeDamage(float damage)
		{
			m_health -= damage;
        	if(m_health <= 0)
        	{
				onDeath?.Invoke(gameObject);
				Destroy(gameObject);
			}
		}
    }
}
