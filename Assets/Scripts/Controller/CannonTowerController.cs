using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class CannonTowerController : TowerBehaviour, IRotation
    {
        private RotationComponent m_rotationComponent;

        public override void Start()
        {
            base.Start();
            m_rotationComponent = GetComponent<RotationComponent>();
            m_rotationComponent.Init(towerData);
        }

		public override void Attack()
		{
			if (searchEnemyComponent.GetTarget())
			{
				attackComponent.Attack(searchEnemyComponent.GetTarget());
			}
		}

		public void RotateTower()
        {
            if (searchEnemyComponent.GetTarget())
			{
				Vector3 predictedPosition = LeadCalculationComponent.Predict(
					projectilePosition.transform.position,
					searchEnemyComponent.GetTarget().transform.position,
					searchEnemyComponent.GetTarget().GetComponent<Rigidbody>().velocity,
					towerData.projectileSpeed
				);
				//Debug.Log(predictedPosition);
				m_rotationComponent.Rotate(predictedPosition);
			}
        }

        public void Update()
        {
			RotateTower();
			Attack();
		}
    }
}
