using UnityEngine;
namespace TestJob
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private GameObject m_prefabEnemy;
		[SerializeField] private float m_interval = 3;
		[SerializeField] private Transform m_moveTarget;
		private float m_lastSpawn = -1;

		private void Start()
		{
			var monsterBeh = m_prefabEnemy.GetComponent<EnemyController>();
			monsterBeh.target = m_moveTarget;
		}

		private void Update()
		{
			if (Time.time > m_lastSpawn + m_interval)
			{
				Instantiate(m_prefabEnemy, transform.position, Quaternion.identity);
				m_lastSpawn = Time.time;
			}
		}
	}
}
