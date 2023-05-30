using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class LeadCalculationComponent : MonoBehaviour
    {
        public Vector3 PredictQuadratic(Vector3 shooterPosition, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
        {
            Vector3 relativePosition = targetPosition - shooterPosition;
            Vector3 relativeVelocity = targetVelocity;

            float a = Vector3.Dot(relativeVelocity, relativeVelocity) - projectileSpeed * projectileSpeed;
            float b = 2f * Vector3.Dot(relativePosition, relativeVelocity);
            float c = Vector3.Dot(relativePosition, relativePosition);

            float discriminant = b * b - 4f * a * c;

			if (discriminant < 0)
			{
				return Vector3.zero;
			}

			float sqrtDiscriminant = Mathf.Sqrt(discriminant);

			float timeFirst = (-b + sqrtDiscriminant) / (2f * a);
            float timeSecond = (-b - sqrtDiscriminant) / (2f * a);

            if (timeFirst < 0 && timeSecond < 0)
            {
                return Vector3.zero;
			}
            else if (timeFirst < 0)
            {
                return targetPosition + targetVelocity * timeSecond - shooterPosition;
            }
            else if (timeSecond < 0)
            {
                return targetPosition + targetVelocity * timeFirst - shooterPosition;
            }
			else
			{
				float projectileTimeToTarget = Mathf.Min(timeFirst, timeSecond);
				return targetPosition + targetVelocity * projectileTimeToTarget - shooterPosition;
			}
		}
    }
}
