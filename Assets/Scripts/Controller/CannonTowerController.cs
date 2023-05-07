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

        // если переменная isBallistic false башня стреляет прямой наводкой, если true, то по баллистической траектории
        public bool isBallistic = false;

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
            if (searchEnemyComponent.GetTarget() && isBallistic == false)
            {
                Vector3 predictedPosition = m_leadCalculationComponent.PredictQuadratic(
                    projectilePosition.transform.position,
                    searchEnemyComponent.GetTarget().transform.position,
                    searchEnemyComponent.GetTarget().GetComponent<Rigidbody>().velocity,
                    towerData.projectileSpeed
                );
                m_rotationComponent.Rotate(predictedPosition);
            }

            if (searchEnemyComponent.GetTarget() && isBallistic == true)
            {
                Vector3 predictedPositionBallistic = m_leadCalculationComponent.PredictQuadratic(
                    projectilePosition.transform.position,
                    searchEnemyComponent.GetTarget().transform.position,
                    searchEnemyComponent.GetTarget().GetComponent<Rigidbody>().velocity,
                    towerData.projectileSpeed
                );
                float time = m_leadCalculationComponent.PredictQuadraticTime(
                    projectilePosition.transform.position,
                    searchEnemyComponent.GetTarget().transform.position,
                    searchEnemyComponent.GetTarget().GetComponent<Rigidbody>().velocity,
                    towerData.projectileSpeed
                );
                float angle = m_leadCalculationComponent.CalculateAngle(
                    predictedPositionBallistic.magnitude,
                    time,
                    9.8f,
                    towerData.projectileSpeed
                );
                m_rotationComponent.RotateBallistic(predictedPositionBallistic, angle);
            }
        }
    }
}
