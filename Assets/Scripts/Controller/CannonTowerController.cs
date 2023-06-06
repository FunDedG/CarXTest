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
		private bool isBallistic = false;
		

        protected override void Start()
        {
            base.Start();
			InputComponent inputComponent = GetComponent<InputComponent>();
			m_rotationComponent = GetComponentInChildren<RotationComponent>();
            m_leadCalculationComponent = GetComponent<LeadCalculationComponent>();
            m_rotationComponent.Init(towerData, cannon);
			inputComponent.onChangeMode += ChangeMode;
		}
		protected override void Update()
        {
			base.Update();
			RotateTower();
        }

		private void ChangeMode()
		{
			isBallistic = !isBallistic;
			if(isBallistic)
			{
				m_attackComponent.GetProjectilePrefab(projectilePrefab[0]);
			}
			else
			{
				m_attackComponent.GetProjectilePrefab(projectilePrefab[1]);
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
				if (isBallistic)
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
			InputComponent inputComponent = GetComponent<InputComponent>();
			inputComponent.onChangeMode -= ChangeMode;
		}
    }
}
