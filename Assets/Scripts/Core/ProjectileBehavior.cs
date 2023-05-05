using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public abstract class ProjectileBehavior : MonoBehaviour
    {
		protected float speed;
		protected float damage;
		protected virtual void Update()
        {
            Move();
        }

        protected virtual void OnTriggerEnter(Collider other)
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

		protected abstract void Move();
	}
}
