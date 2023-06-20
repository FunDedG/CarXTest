using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class DestroyEnemy : MonoBehaviour
    {
		private void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.TryGetComponent<HealthComponent>(out HealthComponent health))
			{
				health.InvokeAction();
			}
		}
    }
}
