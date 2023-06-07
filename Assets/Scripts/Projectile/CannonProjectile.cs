using UnityEngine;
using System.Collections;

namespace TestJob
{
	public class CannonProjectile : ProjectileBehavior
	{
		protected override void Start()
		{
			m_rb = GetComponent<Rigidbody>();
			Movement();
		}
	}
}
