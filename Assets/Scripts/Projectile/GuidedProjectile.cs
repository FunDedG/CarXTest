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

		protected override void Update()
		{
			base.Update();
			Movement();
			
			if (m_target != null && !m_target.activeSelf)
			{
				InvokeProjectileAction();
			}
		}
		protected override void Movement()
		{
			if (m_target == null)
			{
				InvokeProjectileAction();
				return;
			}

			var translation = (m_target.transform.position - transform.position).normalized * m_speed * Time.deltaTime;
			transform.Translate(translation);
		}
	}
}
