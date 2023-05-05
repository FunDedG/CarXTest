using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class RotationComponent : MonoBehaviour
    {
        private Vector3 m_target;
        private float m_rotationSpeed;
        private GameObject m_gunTransform;

        public void Init(TowerData towerData, GameObject gunTransform)
        {
            m_rotationSpeed = towerData.rotationSpeed;
            m_gunTransform = gunTransform;
        }

        public void RotateVertical(Vector3 target)
        {
            Vector3 targetVertical = new Vector3(target.x, 0, target.z).normalized;
            float angleRotation = Mathf.Acos(Vector3.Dot(targetVertical, target.normalized)) * Mathf.Rad2Deg;
            Quaternion verticalRotation = Quaternion.Euler(angleRotation, 0f, 0f);
            m_gunTransform.transform.localRotation = Quaternion.RotateTowards(
                m_gunTransform.transform.localRotation,
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
            }
        }
    }
}
