using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TestJob
{
    public class AttackComponent : MonoBehaviour
	{
		[SerializeField] private int m_sizePool;
		[SerializeField] private List<Transform> m_projectileContainers;
		private float m_lastAttackTime;
		private TowerData m_towerData;
		private GameObject m_projectileStartPosition;
		private int indexProjectile = 0;

		private List<ObjectPoolManager<ProjectileBehavior>> m_projectilePools;

		public async void Init(TowerData towerData, GameObject projectileStartPosition, List<AssetReferenceGameObject> projectilePrefabs)
		{
			m_towerData = towerData;
			m_lastAttackTime = m_towerData.shootInterval;
			m_projectileStartPosition = projectileStartPosition;

			m_projectilePools = new List<ObjectPoolManager<ProjectileBehavior>>();

			for (int i = 0; i < projectilePrefabs.Count; i++)
			{
				GameObject prefab = await LoadProjectileAsync(projectilePrefabs[i]);
				if (prefab != null)
				{
					ProjectileBehavior projectile = prefab.GetComponent<ProjectileBehavior>();
					ObjectPoolManager<ProjectileBehavior> projectilePool = new (projectile, m_sizePool, m_projectileContainers[i]);
					m_projectilePools.Add(projectilePool);
				}
			}
		}

		public void ChangeProjectile(int index)
		{
			indexProjectile = index;
		}

		public void Attack(GameObject target)
		{
			if (target == null) return;

			if (Time.time - m_lastAttackTime < m_towerData.shootInterval) return;

			ProjectileBehavior projectile = m_projectilePools[indexProjectile].GetObject();
			projectile.transform.position = m_projectileStartPosition.transform.position;
			projectile.transform.rotation = m_projectileStartPosition.transform.rotation;

			projectile.Init(m_towerData.projectileSpeed, m_towerData.damage, m_towerData.lifeTime, indexProjectile, target);
			projectile.onProjectileDeath += RemoveProjectile;

			m_lastAttackTime = Time.time;
		}

		private void RemoveProjectile(GameObject gameObject, int id)
		{
			ProjectileBehavior projectile = gameObject.GetComponent<ProjectileBehavior>();
			projectile.onProjectileDeath -= RemoveProjectile;

			m_projectilePools[id].ReturnObject(projectile);
		}

		private async Task<GameObject> LoadProjectileAsync(AssetReferenceGameObject projectilePrefab)
		{
			var prefabHandle = projectilePrefab.LoadAssetAsync<GameObject>();
			await prefabHandle.Task;
			
			if (prefabHandle.Status == AsyncOperationStatus.Succeeded)
			{
				return prefabHandle.Result;
			}
			else
			{
				return null;
			}
		}
	}
}
