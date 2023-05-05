using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
	public interface IRotation
	{
		public void RotateTower();
	}

	public interface IProjectileInit
	{
		public void Init(float speed, float damage, GameObject target);
	}
}