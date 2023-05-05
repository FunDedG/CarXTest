using UnityEngine;
namespace TestJob
{
	public class GuidedProjectile : ProjectileBehavior, IProjectileInit
	{
		private GameObject m_target;

		public void Init(float speed, float damage, GameObject target)
		{
			this.speed = speed;
			this.damage = damage;
			m_target = target;
		}
		protected override void Update()
		{
			base.Update();
		}
		
		protected override void OnTriggerEnter(Collider other)
		{
			base.OnTriggerEnter(other);
		}

		protected override void Move()
		{
			if (m_target == null)
			{
				Destroy(gameObject);
				return;
			}

			var translation = (m_target.transform.position - transform.position).normalized * speed * Time.deltaTime;
			transform.Translate(translation);
		}
	}
}
