using UnityEngine;
namespace TestJob
{
	public class GuidedProjectile : ProjectileBehavior
	{
		private GameObject m_target;

		public override void Init(float speed, float damage, float lifeTime, GameObject target)
        {
			base.Init(speed, damage, lifeTime, target);
			m_target = target;
		}

		protected override void Start()
		{
			Destroy(gameObject, m_lifeTime);
		}

		protected override void Update()
		{
			Movement();
		}
		protected override void Movement()
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
