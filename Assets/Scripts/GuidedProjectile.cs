using UnityEngine;
namespace TestJob
{
	public class GuidedProjectile : MonoBehaviour, IProjectileInit
	{
		public GameObject m_target;
		private float m_speed;
		private float m_damage;

		public void Init(float speed, float damage, GameObject target)
		{
			m_speed = speed;
			m_damage = damage;
			m_target = target;
		}
		private void Update()
		{
			Move();
		}
		
		public void OnTriggerEnter(Collider other)
		{
			var monster = other.gameObject.GetComponent<Enemy>();
			if (monster == null)
				return;

			monster.hp -= m_damage;
			if (monster.hp <= 0)
			{
				Destroy(monster.gameObject);
			}
			Destroy(gameObject);
		}

		public void Move()
		{
			if (m_target == null)
			{
				Destroy(gameObject);
				return;
			}

			var translation = (m_target.transform.position - transform.position).normalized * m_speed * Time.deltaTime;
			transform.Translate(translation);
		}
	}
}
