using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class RotationComponent : MonoBehaviour
    {
        private GameObject m_target;
		private float m_rotationSpeed;

		public void Init(TowerData towerData)
		{
			m_rotationSpeed = towerData.rotationSpeed;
		}

		public void Rotate(GameObject target)
		{
			m_target = target;
			if (m_target != null)
            {
                Vector3 targetDirection = m_target.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * m_rotationSpeed);
            }
		}
    }
}
