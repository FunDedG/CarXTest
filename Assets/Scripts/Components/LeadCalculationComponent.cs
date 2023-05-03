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

			float xFirst = (-b + sqrtDiscriminant) / (2f * a);
            float xSecond = (-b - sqrtDiscriminant) / (2f * a);

            if (xFirst < 0 && xSecond < 0)
            {
                return Vector3.zero;
			}
            else if (xFirst < 0)
            {
                return targetPosition + targetVelocity * xSecond - shooterPosition;
            }
            else if (xSecond < 0)
            {
                return targetPosition + targetVelocity * xFirst - shooterPosition;
            }
			else
			{
				float projectileTimeToTarget = Mathf.Min(xFirst, xSecond);
				Vector3 futureTargetPosition = targetPosition + targetVelocity * projectileTimeToTarget;
				Vector3 futureTargetDirection = futureTargetPosition - shooterPosition;
				return futureTargetDirection;
			}
		}
    }
}
