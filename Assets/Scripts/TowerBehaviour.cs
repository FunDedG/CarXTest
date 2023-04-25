using UnityEngine;

namespace TestJob
{
	public abstract class TowerBehaviour : MonoBehaviour
	{
		public TowerData towerData;

		public abstract void Attack();
	}
}
