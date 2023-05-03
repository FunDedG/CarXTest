using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class CannonTowerController : TowerBehaviour, IRotation
    {
        private RotationComponent m_rotationComponent;
        private LeadCalculationComponent m_leadCalculationComponent;
		public GameObject cannon;

        public override void Start()
        {
            base.Start();
            m_rotationComponent = GetComponentInChildren<RotationComponent>();
            m_leadCalculationComponent = GetComponent<LeadCalculationComponent>();
            m_rotationComponent.Init(towerData, cannon);
        }

        public override void Attack() 
		{ 
			base.Attack();
		}
		public override void Update()
        {
			base.Update();
			RotateTower();
        }
        public void RotateTower()
        {
            if (searchEnemyComponent.GetTarget())
            {
                Vector3 predictedPosition = m_leadCalculationComponent.PredictQuadratic(
                    projectilePosition.transform.position,
                    searchEnemyComponent.GetTarget().transform.position,
                    searchEnemyComponent.GetTarget().GetComponent<Rigidbody>().velocity,
                    towerData.projectileSpeed
                );
                m_rotationComponent.Rotate(predictedPosition);
            }
        }
    }
}
