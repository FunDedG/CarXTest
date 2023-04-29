using UnityEngine;

namespace TestJob
{
	public abstract class TowerBehaviour : MonoBehaviour
	{
		public TowerData towerData;
		public AttackComponent attackComponent;
		public SearchEnemyComponent searchEnemyComponent;
		public SphereCollider sphereCollider;
		public GameObject projectilePosition;

		public virtual void Start()
		{
			attackComponent = GetComponent<AttackComponent>();
			searchEnemyComponent = GetComponent<SearchEnemyComponent>();
			sphereCollider = GetComponent<SphereCollider>();
			sphereCollider.radius = towerData.range;
			attackComponent.Init(towerData);
			searchEnemyComponent.Init(towerData);
		}

		public abstract void Attack();
	}
}
