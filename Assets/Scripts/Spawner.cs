using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject m_enemy;
	private float m_lastSpawn = -1;
	public float interval = 3;
    public GameObject moveTarget;

    void Update()
    {
        if (Time.time > m_lastSpawn + interval)
        {
			Instantiate(m_enemy, transform.position, Quaternion.identity);
			var monsterBeh = m_enemy.GetComponent<Monster>();
			monsterBeh.m_moveTarget = moveTarget;
			m_lastSpawn = Time.time;
        }
    }
}
