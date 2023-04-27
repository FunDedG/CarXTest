using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class LeadCalculationComponent : MonoBehaviour
    {
        public static Vector3 Predict(Vector3 projectilePosition, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
		{
			float targetSpeed = targetVelocity.magnitude;
			Vector3 targetDirection = targetVelocity.normalized;
			Vector3 relativePosition = targetPosition - projectilePosition;
			float distance = relativePosition.magnitude;
			float time = distance / (projectileSpeed - targetSpeed);

			Vector3 predictedTargetPosition = targetPosition + targetDirection * targetSpeed * time;
			return predictedTargetPosition;
		}
    }
}
