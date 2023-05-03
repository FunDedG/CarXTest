using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class LeadCalculationComponent : MonoBehaviour
    {
		public static Vector3 PredictQuadratic(Vector3 shooterPosition, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
		{
			Vector3 relativePosition = targetPosition - shooterPosition;
			Vector3 relativeVelocity = targetVelocity;

			float a = Vector3.Dot(relativeVelocity, relativeVelocity) - projectileSpeed * projectileSpeed;
			float b = 2f * Vector3.Dot(relativePosition, relativeVelocity);
			float c = Vector3.Dot(relativePosition, relativePosition);

			float discriminant = b * b - 4f * a * c;

			float projectileTimeToTarget = (-b - Mathf.Sqrt(discriminant)) / (2f * a);

			Vector3 futureTargetPosition = targetPosition + targetVelocity * projectileTimeToTarget;

			return futureTargetPosition;
		}
    }
}
