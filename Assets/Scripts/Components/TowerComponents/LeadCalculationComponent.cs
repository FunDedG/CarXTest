using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class LeadCalculationComponent : MonoBehaviour
    {
        public Vector3 PredictQuadratic(Vector3 shooterPosition, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
        {
			float time = PredictQuadraticTime(shooterPosition, targetPosition, targetVelocity, projectileSpeed);
			Vector3 futureTargetPosition = targetPosition + targetVelocity * time;
			Vector3 futureTargetDirection = futureTargetPosition - shooterPosition;
			return futureTargetDirection;
		}

		public float PredictQuadraticTime(Vector3 shooterPosition, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed)
		{
			Vector3 relativePosition = targetPosition - shooterPosition;
			Vector3 relativeVelocity = targetVelocity;

			float a = Vector3.Dot(relativeVelocity, relativeVelocity) - projectileSpeed * projectileSpeed;
			float b = 2f * Vector3.Dot(relativePosition, relativeVelocity);
			float c = Vector3.Dot(relativePosition, relativePosition);

			float discriminant = b * b - 4f * a * c;

			if (discriminant < 0)
			{
				return 0;
			}

			float sqrtDiscriminant = Mathf.Sqrt(discriminant);

			float xFirst = (-b + sqrtDiscriminant) / (2f * a);
			float xSecond = (-b - sqrtDiscriminant) / (2f * a);

			if (xFirst < 0 && xSecond < 0)
			{
				return 0;
			}
			else if (xFirst < 0)
			{
				return xSecond;
			}
			else if (xSecond < 0)
			{
				return xFirst;
			}
			else
			{
				return Mathf.Min(xFirst, xSecond);
			}
			
		}
		public float CalculateAngle(float distance, float time, float gravity, float projectileSpeed)
		{
			float angle = Mathf.Atan((4 * gravity * distance) / (time * time * projectileSpeed * projectileSpeed));
			return angle * Mathf.Rad2Deg;
		}
	}
}
