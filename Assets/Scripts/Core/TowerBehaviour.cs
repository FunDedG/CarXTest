using UnityEngine;

namespace TestJob
{
	public abstract class TowerBehaviour : MonoBehaviour
	{
		[SerializeField] protected TowerData towerData;
		[SerializeField] protected GameObject projectilePosition;
		[SerializeField] protected GameObject projectilePrefab;
		protected AttackComponent attackComponent;
		protected SearchEnemyComponent searchEnemyComponent;
		protected SphereCollider sphereCollider;
		

		protected virtual void Start()
		{
			attackComponent = GetComponent<AttackComponent>();
			searchEnemyComponent = GetComponent<SearchEnemyComponent>();
			sphereCollider = GetComponent<SphereCollider>();
			sphereCollider.radius = towerData.range;
			attackComponent.Init(towerData, projectilePosition, projectilePrefab);
			searchEnemyComponent.Init(towerData);
		}
		protected virtual void Attack()
		{
			if (searchEnemyComponent.GetTarget())
			{
				attackComponent.Attack(searchEnemyComponent.GetTarget());
			}
		}
		protected virtual void Update()
		{
			Attack();
		}
	}
}
