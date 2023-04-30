using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class LeadCalculationComponent : MonoBehaviour
    {
		public float CalculateTimeToHit(GameObject target, float projectileSpeed)
        {
            Vector3 targetVelocity = target.GetComponent<Rigidbody>().velocity;
            Vector3 targetPosition = target.transform.position;
            Vector3 projectilePosition = transform.position;
            float distance = Vector3.Distance(targetPosition, projectilePosition);

            // Расстояние, которое пройдет цель за время, необходимое снаряду для достижения ее
            float targetDistance = targetVelocity.magnitude * distance / (projectileSpeed - targetVelocity.magnitude);

            // Время, необходимое снаряду для достижения цели
            float timeToHit = targetDistance / projectileSpeed;

            return timeToHit;
        }

        public Vector3 AimAtMovingTarget(GameObject target, float timeToHit)
        {
            Vector3 targetVelocity = target.GetComponent<Rigidbody>().velocity;
			Debug.Log(targetVelocity);
			Vector3 targetFuturePosition = target.transform.position + targetVelocity * timeToHit;

			return targetFuturePosition;
		}
		public static Vector3 PredictLinear(Vector3 shooterPosition, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
		{
			Vector3 targetDirection = targetPosition - shooterPosition;
			float distanceToTarget = targetDirection.magnitude;

			float projectileTimeToTarget = distanceToTarget / projectileSpeed;

			Vector3 futureTargetPosition = targetPosition + targetVelocity * projectileTimeToTarget;

			return futureTargetPosition;
		}

		public static Vector3 PredictQuadratic(Vector3 shooterPosition, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
		{
			Vector3 relativePosition = targetPosition - shooterPosition;
			Vector3 relativeVelocity = targetVelocity;

			float a = Vector3.Dot(relativeVelocity, relativeVelocity) - projectileSpeed * projectileSpeed;
			float b = 2f * Vector3.Dot(relativePosition, relativeVelocity);
			float c = Vector3.Dot(relativePosition, relativePosition);

			float discriminant = b * b - 4f * a * c;

			float projectileTimeToTarget = (-b + Mathf.Sqrt(discriminant)) / (2f * a);

			Vector3 futureTargetPosition = targetPosition + targetVelocity * projectileTimeToTarget;

			return futureTargetPosition;
		}

		public static Vector3 Predict(Vector3 shooterPosition, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
		{
			Vector3 linearPrediction = PredictLinear(shooterPosition, targetPosition, targetVelocity, projectileSpeed);
			Vector3 quadraticPrediction = PredictQuadratic(shooterPosition, targetPosition, targetVelocity, projectileSpeed);

			float linearPredictionError = Vector3.Distance(linearPrediction, targetPosition);
			float quadraticPredictionError = Vector3.Distance(quadraticPrediction, targetPosition);

			if (linearPredictionError < quadraticPredictionError)
			{
				return linearPrediction;
			}
			else
			{
				return quadraticPrediction;
			}
    	}
    }
}
