using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestJob
{
    public class ObjectPoolManager<T> where T : MonoBehaviour
	{
		[SerializeField] private int m_initialPoolSize = 0;
		private Queue<T> m_objectPool = new();
		private T m_prefab;
		private int m_expandAmount = 5;
		private Transform m_container;

		public ObjectPoolManager(T prefab, int initialPoolSize, Transform container)
		{
			m_prefab = prefab;
			m_initialPoolSize = initialPoolSize;
			m_container = container;
			CreateInitialPool();
		}

		private void CreateInitialPool()
		{
			for (int i = 0; i < m_initialPoolSize; i++)
			{
				CreateObject();
			}
		}

		private void CreateObject()
		{
			T newObject = GameObject.Instantiate(m_prefab);
			newObject.gameObject.SetActive(false);

			if (m_container != null)
			{
				newObject.transform.SetParent(m_container);
			}
			
			m_objectPool.Enqueue(newObject);
		}

		public T GetObject()
		{
			if (m_objectPool.Count == 0)
			{
				ExpandPool();
			}

			T obj = m_objectPool.Dequeue();
			obj.gameObject.SetActive(true);
			return obj;
		}

		public void ReturnObject(T obj)
		{
			obj.gameObject.SetActive(false);
			m_objectPool.Enqueue(obj);
		}

		private void ExpandPool()
		{
			for (int i = 0; i < m_expandAmount; i++)
			{
				CreateObject();
			}
		}
	}
}
