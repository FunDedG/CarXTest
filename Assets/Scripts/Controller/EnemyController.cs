using UnityEngine;
namespace TestJob
{
	public class EnemyController : EnemyBehavior
	{
		public float maxHP = 30f;
		public float hp;

		protected override void Start()
		{
			base.Start();
			hp = maxHP;
		}

		private void FixedUpdate()
		{
			moveComponent.MoveToTarget();
		}
	}
}
