using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class CannonBallisticProjectile : ProjectileBehavior
	{
		protected override void Start()
		{
			m_rb = GetComponent<Rigidbody>();
			Movement();
		}
	}
}
