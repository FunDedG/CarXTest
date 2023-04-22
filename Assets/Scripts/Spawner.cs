using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject m_enemy;
	public float interval = 3;
    public GameObject moveTarget;
	

    private float m_lastSpawn = -1;

    void Update()
    {
        if (Time.time > m_lastSpawn + interval)
        {
			//var newMonster = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			//var r = newMonster.AddComponent<Rigidbody>();
			//r.useGravity = false;
			Instantiate(m_enemy, transform.position, Quaternion.identity);
			var monsterBeh = m_enemy.GetComponent<Monster>();
			monsterBeh.m_moveTarget = moveTarget;
			m_lastSpawn = Time.time;
        }
    }
}
