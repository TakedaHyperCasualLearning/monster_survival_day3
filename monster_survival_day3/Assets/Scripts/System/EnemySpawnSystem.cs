using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    private GameEvent gameEvent = null;
    private List<EnemySpawnComponent> enemySpawnComponentList = new List<EnemySpawnComponent>();
    private ObjectPool objectPool = null;

    private Transform playerTransform = null;


    public EnemySpawnSystem(GameEvent gameEvent, ObjectPool objectPool, Transform playerTransform)
    {
        this.gameEvent = gameEvent;
        this.objectPool = objectPool;
        this.playerTransform = playerTransform;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < enemySpawnComponentList.Count; i++)
        {
            EnemySpawnComponent enemySpawnComponent = enemySpawnComponentList[i];

            enemySpawnComponent.SpawnTimer += Time.deltaTime;

            if (enemySpawnComponent.SpawnTimer >= enemySpawnComponent.SpawnInterval)
            {
                enemySpawnComponent.SpawnTimer = 0.0f;

                GameObject enemy = objectPool.GenerateObject(enemySpawnComponent.EnemyPrefab);

                Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10.0f));
                Vector3 randomPos = new Vector3(Random.Range(screenPos.x, screenPos.x + enemySpawnComponent.SpawnPositionOffset.x), 0.0f, Random.Range(screenPos.z, screenPos.z + enemySpawnComponent.SpawnPositionOffset.z));
                randomPos *= Random.Range(0, 2) == 0 ? -1 : 1;
                enemy.transform.position = playerTransform.position + randomPos;

                gameEvent.AddComponentList?.Invoke(enemy);
            }
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        EnemySpawnComponent enemySpawnComponent = gameObject.GetComponent<EnemySpawnComponent>();

        if (enemySpawnComponent == null) return;

        enemySpawnComponentList.Add(enemySpawnComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        EnemySpawnComponent enemySpawnComponent = gameObject.GetComponent<EnemySpawnComponent>();

        if (enemySpawnComponent == null) return;

        enemySpawnComponentList.Remove(enemySpawnComponent);
    }
}
