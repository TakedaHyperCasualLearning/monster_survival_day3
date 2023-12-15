using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private GameObject mainCamera = null;
    [SerializeField] private GameObject enemySpawner = null;
    private GameEvent gameEvent = new GameEvent();

    private ObjectPool objectPool = null;
    private CollisionSystem collisionSystem = null;

    private MoveSystem moveSystem = null;
    private PlayerInputSystem inputSystem = null;
    private PlayerShotSystem shotSystem = null;
    private LevelUpUISystem levelUpUISystem = null;

    private EnemyChaseSystem enemyChaseSystem = null;
    private EnemySpawnSystem enemySpawnSystem = null;
    private EnemyAttackSystem enemyAttackSystem = null;

    private BulletShotSystem bulletShotSystem = null;
    private BulletHitSystem bulletHitSystem = null;

    private DamageSystem damageSystem = null;

    private CameraMoveSystem cameraMoveSystem = null;

    void Start()
    {
        objectPool = new ObjectPool(gameEvent);
        collisionSystem = new CollisionSystem(gameEvent);

        GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        moveSystem = new MoveSystem(gameEvent);
        inputSystem = new PlayerInputSystem(gameEvent);
        shotSystem = new PlayerShotSystem(gameEvent, objectPool, player.transform);
        levelUpUISystem = new LevelUpUISystem(gameEvent, player);


        enemyChaseSystem = new EnemyChaseSystem(gameEvent, player);
        enemySpawnSystem = new EnemySpawnSystem(gameEvent, objectPool, player.transform);
        enemyAttackSystem = new EnemyAttackSystem(gameEvent, objectPool, collisionSystem, player);

        bulletShotSystem = new BulletShotSystem(gameEvent, player.transform);
        bulletHitSystem = new BulletHitSystem(gameEvent, objectPool, collisionSystem, enemyPrefab);

        damageSystem = new DamageSystem(gameEvent, player);

        cameraMoveSystem = new CameraMoveSystem(gameEvent, player.transform);

        gameEvent.AddComponentList?.Invoke(player);
        gameEvent.AddComponentList?.Invoke(enemySpawner);
        gameEvent.AddComponentList?.Invoke(mainCamera);
    }

    void Update()
    {
        enemyChaseSystem.OnUpdate();
        inputSystem.OnUpdate();
        moveSystem.OnUpdate();

        shotSystem.OnUpdate();
        bulletShotSystem.OnUpdate();
        bulletHitSystem.OnUpdate();

        damageSystem.OnUpdate();

        enemySpawnSystem.OnUpdate();
        enemyAttackSystem.OnUpdate();

        cameraMoveSystem.Update();
    }
}
