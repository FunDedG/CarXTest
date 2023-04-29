using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class AttackComponent : MonoBehaviour
    {
		private float m_damage;

		public void Init(TowerData towerData)
		{
			this.m_damage = towerData.damage;
		}

		public void AttackEnemy(GameObject target)
		{

		}
    }
}
