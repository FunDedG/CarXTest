using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestJob
{
	public class CannonTower : TowerBehaviour, IRotation
	{
		private RotationComponent m_rotationComponent;
		public override void Start()
		{
			base.Start();
			m_rotationComponent = GetComponent<RotationComponent>();
			m_rotationComponent.Init(towerData);
		}
		public override void Attack()
		{

		}
		public void Rotate()
		{
			m_rotationComponent.Rotate(searchEnemyComponent.GetTarget());
		}

		public void Update()
		{
			Rotate();
		}
	}
}
