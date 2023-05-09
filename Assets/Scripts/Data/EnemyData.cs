using UnityEngine;

namespace TestJob
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
    public class EnemyData : ScriptableObject
	{
		public float speed;
		public float health;
	}
}