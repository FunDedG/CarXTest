using UnityEngine;
namespace TestJob
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private EnemyBehavior m_prefabEnemy;
		[SerializeField] private float m_interval = 3;
		[SerializeField] private Transform m_moveTarget;
		[SerializeField] private Transform m_container;
		private float m_lastSpawn = -1;

		private ObjectPoolManager<EnemyBehavior> m_enemyPool;

		private void Start()
		{
			m_enemyPool = new ObjectPoolManager<EnemyBehavior>(m_prefabEnemy, 10, m_container);
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
			EnemyBehavior enemy = m_enemyPool.GetObject();
			enemy.transform.position = transform.position;
			HealthComponent death = enemy.gameObject.GetComponent<HealthComponent>();
			death.onDeath += Remove;

			var enemyBehavior = enemy.GetComponent<EnemyBehavior>();
			enemyBehavior.Init(m_moveTarget);
		}

		private void Remove(GameObject gameObject)
		{
			HealthComponent death = gameObject.gameObject.GetComponent<HealthComponent>();
			death.onDeath -= Remove;

			var enemyBehavior = death.GetComponent<EnemyBehavior>();
			m_enemyPool.ReturnObject(enemyBehavior);
		}
	}
}
