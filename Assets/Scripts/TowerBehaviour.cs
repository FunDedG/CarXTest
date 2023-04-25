using UnityEngine;

namespace TestJob
{
	public abstract class TowerBehaviour : MonoBehaviour
	{
		public TowerData TowerData;

		public abstract void Attack();
	}
}
