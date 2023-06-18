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
		private float m_currentHealth;

		public void Init(EnemyData enemyData)
		{
			m_health = enemyData.health;
			m_currentHealth = m_health;
		}

		public void TakeDamage(float damage)
		{
			m_currentHealth -= damage;
        	if(m_currentHealth <= 0)
        	{
				InvokeAction();
			}
		}

		public void InvokeAction()
		{
			onDeath?.Invoke(gameObject);
		}

		private void OnEnable()
		{
			m_currentHealth = m_health;
		}
    }
}
