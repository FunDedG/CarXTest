using UnityEngine;
namespace TestJob
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private EnemyController m_prefabEnemy;
		[SerializeField] private float m_interval = 3;
		[SerializeField] private Transform m_moveTarget;
		private float m_lastSpawn = -1;

		private void Update()
		{
			if (Time.time > m_lastSpawn + m_interval)
			{
				var monsterBeh = Instantiate(m_prefabEnemy, transform.position, Quaternion.identity);
				var monsterBehInit = monsterBeh.GetComponent<IEnemyInit>();
				monsterBehInit.Init(m_moveTarget);
				m_lastSpawn = Time.time;
			}
		}
	}
}
