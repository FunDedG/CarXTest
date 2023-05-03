using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class RotationComponent : MonoBehaviour
    {
        private Vector3 m_target;
        private float m_rotationSpeed;
        private GameObject m_gun;

        public void Init(TowerData towerData, GameObject gun)
        {
            m_rotationSpeed = towerData.rotationSpeed;
			m_gun = gun;
		}

        public void RotateVertical(Vector3 target)
        {
            Vector3 targetVertical = new Vector3(target.x, 0, target.z).normalized;
            float verticalAngle = Vector3.Angle(targetVertical, target);
            Quaternion verticalRotation = Quaternion.Euler(verticalAngle, 0f, 0f);
            m_gun.transform.localRotation = Quaternion.RotateTowards(
                m_gun.transform.localRotation,
                verticalRotation,
                m_rotationSpeed * Time.deltaTime
            );
        }

        public void RotateHorizontal(Vector3 target)
        {
            Vector3 targetHorizontal = new Vector3(target.x, 0, target.z);
            Quaternion targetRotation = Quaternion.LookRotation(targetHorizontal);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                m_rotationSpeed * Time.deltaTime
            );
        }

        public void Rotate(Vector3 target)
        {
            m_target = target;
            if (m_target.magnitude > 0)
            {

				RotateVertical(target);
				RotateHorizontal(target);
				// Vector3 targetDirection = m_target - transform.position;
				// Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
				// transform.rotation = Quaternion.RotateTowards(
				//     transform.rotation,
				//     targetRotation,
				//     Time.deltaTime * m_rotationSpeed
				// );
			}
        }
    }
}
