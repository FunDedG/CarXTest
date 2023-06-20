using UnityEngine;
using System.Collections.Generic;
namespace TestJob
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private List<EnemyBehavior> m_enemyPrefabs;
		[SerializeField] private List<Transform> m_enemyContainers;
		[SerializeField] private float m_interval = 3;
		[SerializeField] private Transform m_moveTarget;
		[SerializeField] private int m_rangePool;
		private float m_lastSpawn = -1;
		private int m_enemyIndex;

		private List<ObjectPoolManager<EnemyBehavior>> m_enemyPools;

		private void Start()
		{
			m_enemyPools = new List<ObjectPoolManager<EnemyBehavior>>();

			for (int i = 0; i < m_enemyPrefabs.Count; i++)
			{
				ObjectPoolManager<EnemyBehavior> enemyPool = new (m_enemyPrefabs[i], m_rangePool, m_enemyContainers[i]);
				m_enemyPools.Add(enemyPool);
			}
		}

		private void Update()
		{
			if (Time.time > m_lastSpawn + m_interval)
			{
				Spawn();
				m_lastSpawn = Time.time;
			}
		}

		private void Spawn()
		{
			int randomEnemyIndex = Random.Range(0, m_enemyPrefabs.Count);
			m_enemyIndex = randomEnemyIndex;
			EnemyBehavior enemy = m_enemyPools[randomEnemyIndex].GetObject();
			enemy.transform.position = transform.position;
			var enemyBehavior = enemy.GetComponent<EnemyBehavior>();
			enemyBehavior.Init(m_moveTarget);

			HealthComponent death = enemy.gameObject.GetComponent<HealthComponent>();
			death.onDeath += Remove;
		}

		private void Remove(GameObject gameObject)
		{
			HealthComponent death = gameObject.GetComponent<HealthComponent>();
			death.onDeath -= Remove;

			var enemyBehavior = gameObject.GetComponent<EnemyBehavior>();
			m_enemyPools[m_enemyIndex].ReturnObject(enemyBehavior);
		}
	}
}
