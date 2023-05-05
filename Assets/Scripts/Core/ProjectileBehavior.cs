using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public abstract class ProjectileBehavior : MonoBehaviour
    {
		public float speed;
		public float damage;
		public virtual void Update()
        {
            Move();
        }

        public virtual void OnTriggerEnter(Collider other)
        {
            var monster = other.gameObject.GetComponent<EnemyController>();
            if (monster == null)
                return;

            monster.hp -= damage;
            if (monster.hp <= 0)
            {
                Destroy(monster.gameObject);
            }
            Destroy(gameObject);
        }

		public abstract void Move();
	}
}
