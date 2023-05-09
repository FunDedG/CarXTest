using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public abstract class EnemyBehavior : MonoBehaviour
    {
		[SerializeField] protected EnemyData enemyData;
		public Transform target;
		protected MoveComponent moveComponent;
		protected HealthComponent healthComponent;

		protected virtual void Start()
		{
			moveComponent = GetComponent<MoveComponent>();
			healthComponent = GetComponent<HealthComponent>();
			moveComponent.Init(enemyData, target);
		}

	}
}
