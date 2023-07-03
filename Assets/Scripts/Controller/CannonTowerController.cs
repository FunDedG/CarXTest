using System;
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
		private InputComponent m_inputComponent;
		private bool m_isBallistic = false;
		

        protected override void Start()
        {
			m_inputComponent = GetComponent<InputComponent>();
			m_rotationComponent = GetComponentInChildren<RotationComponent>();
            m_leadCalculationComponent = GetComponent<LeadCalculationComponent>();
            base.Start();
            m_rotationComponent.Init(towerData, cannon);
			m_inputComponent.onChangeMode += ChangeMode;
		}
		protected override void Update()
        {
			base.Update();
			RotateTower();
        }

		private void ChangeMode()
		{
			m_isBallistic = !m_isBallistic;
			if(m_isBallistic)
			{
				m_attackComponent.ChangeProjectile(1);
			}
			else
			{
				m_attackComponent.ChangeProjectile(0);
			}
		}
        private void RotateTower()
        {
			float angleRotation;
			if (m_searchEnemyComponent.GetTarget())
            {
                Vector3 predictedPosition = m_leadCalculationComponent.PredictQuadratic(
                    projectilePosition.transform.position,
                    m_searchEnemyComponent.GetTarget().transform.position,
                    m_searchEnemyComponent.GetTarget().GetComponent<Rigidbody>().velocity,
                    towerData.projectileSpeed
                );
				if (m_isBallistic)
				{
					angleRotation = m_leadCalculationComponent.AngleBallisticCalculate(predictedPosition, towerData.projectileSpeed);
				}
				else
					angleRotation = m_leadCalculationComponent.AngleCalculate(predictedPosition);
				
				m_rotationComponent.RotateVertical(angleRotation);
				m_rotationComponent.RotateHorizontal(predictedPosition);
            }
			else
			{
				m_rotationComponent.ResetRotation();
			}
        }
		private void OnDisable()
		{
			m_inputComponent.onChangeMode -= ChangeMode;
		}
    }
}
