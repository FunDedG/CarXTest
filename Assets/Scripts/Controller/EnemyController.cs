using UnityEngine;
namespace TestJob
{
	public class EnemyController : MonoBehaviour
	{
		private Rigidbody m_rb;
		public Transform moveTarget;
		public float speed = 5f;
		public float maxHP = 30f;
		public float hp;

		const float m_reachDistance = 0.3f;

		void Start()
		{
			hp = maxHP;
			m_rb = GetComponent<Rigidbody>();
		}

		void FixedUpdate()
		{
			if (moveTarget == null)
				return;

			if (Vector3.Distance(transform.position, moveTarget.position) < m_reachDistance)
			{
				Destroy(gameObject);
				return;
			}

			Vector3 direction = moveTarget.position - transform.position;
			m_rb.velocity = direction.normalized * speed;
		}
	}
}
