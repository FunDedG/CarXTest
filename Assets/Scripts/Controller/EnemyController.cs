using UnityEngine;
namespace TestJob
{
	public class EnemyController : EnemyBehavior, IEnemyInit
	{
		public void Init(Transform target)
		{
			m_target = target;
		}
	}
}
