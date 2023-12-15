using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject enemySpawner = null;
    private GameEvent gameEvent = new GameEvent();

    private ObjectPool objectPool = null;

    private MoveSystem moveSystem = null;
    private PlayerInputSystem inputSystem = null;

    private EnemyChaseSystem enemyChaseSystem = null;
    private EnemySpawnSystem enemySpawnSystem = null;

    void Start()
    {
        objectPool = new ObjectPool(gameEvent);

        GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        moveSystem = new MoveSystem(gameEvent);
        inputSystem = new PlayerInputSystem(gameEvent);

        enemyChaseSystem = new EnemyChaseSystem(gameEvent, player);
        enemySpawnSystem = new EnemySpawnSystem(gameEvent, objectPool, player.transform);

        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemySpawner);
    }

    void Update()
    {
        enemyChaseSystem.OnUpdate();
        inputSystem.OnUpdate();
        moveSystem.OnUpdate();

        enemySpawnSystem.OnUpdate();
    }
}
