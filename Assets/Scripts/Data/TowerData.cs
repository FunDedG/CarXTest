using UnityEngine;

namespace TestJob
{
    [CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
    public class TowerData : ScriptableObject
	{
		public float range;
		public float damage;
		public float shootInterval;
		public float rotationSpeed;
		public float projectileSpeed;
		public float lifeTime;
	}
}
