using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class CannonTowerController : TowerBehaviour
    {
		[SerializeField] private GameObject cannon;
        private RotationComponent m_rotationComponent;
        private LeadCalculationComponent m_leadCalculationComponent;
		

        protected override void Start()
        {
            base.Start();
            m_rotationComponent = GetComponentInChildren<RotationComponent>();
            m_leadCalculationComponent = GetComponent<LeadCalculationComponent>();
            m_rotationComponent.Init(towerData, cannon);
        }
		protected override void Update()
        {
			base.Update();
			RotateTower();
        }
        public void RotateTower()
        {
            if (m_searchEnemyComponent.GetTarget())
            {
                Vector3 predictedPosition = m_leadCalculationComponent.PredictQuadratic(
                    projectilePosition.transform.position,
                    m_searchEnemyComponent.GetTarget().transform.position,
                    m_searchEnemyComponent.GetTarget().GetComponent<Rigidbody>().velocity,
                    towerData.projectileSpeed
                );
                m_rotationComponent.Rotate(predictedPosition);
            }
        }
    }
}
