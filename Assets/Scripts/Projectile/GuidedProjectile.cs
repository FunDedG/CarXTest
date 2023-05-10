using UnityEngine;
namespace TestJob
{
	public class GuidedProjectile : ProjectileBehavior, IProjectileInit
	{
		private GameObject m_target;

		private void Start()
		{
			Destroy(gameObject, m_lifeTime);
		}

		public void Init(float speed, float damage, float lifeTime, GameObject target)
        {
            m_speed = speed;
            m_damage = damage;
			m_lifeTime = lifeTime;
			m_target = target;
		}

		protected override void Move()
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
