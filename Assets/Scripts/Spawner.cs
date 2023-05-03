using UnityEngine;
namespace TestJob
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private GameObject m_enemy;
		private float m_lastSpawn = -1;
		public float interval = 3;
		public Transform moveTarget;

		void Update()
		{
			if (Time.time > m_lastSpawn + interval)
			{
				var monsterBeh = m_enemy.GetComponent<Enemy>();
				monsterBeh.moveTarget = moveTarget;
				Instantiate(m_enemy, transform.position, Quaternion.identity);
				m_lastSpawn = Time.time;
			}
		}
	}
}
