using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class RotationComponent : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void Update()
        {
            if (target != null)
            {
                Vector3 targetDirection = target.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
