using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
	public interface IProjectileInit
	{
		public void Init(float speed, float damage, float lifeTime, Transform target);
	}
	public interface IEnemyInit
	{
		public void Init(Transform target);
	}
}
