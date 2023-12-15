using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitSystem : MonoBehaviour
{
    private GameEvent gameEvent = null;
    private ObjectPool objectPool = null;
    private CollisionSystem collisionSystem = null;
    private GameObject enemyPrefab = null;
    private List<BulletBaseComponent> bulletBaseComponentList = new List<BulletBaseComponent>();

    public BulletHitSystem(GameEvent gameEvent, ObjectPool objectPool, CollisionSystem collision, GameObject enemyPrefab)
    {
        this.gameEvent = gameEvent;
        this.objectPool = objectPool;
        this.collisionSystem = collision;
        this.enemyPrefab = enemyPrefab;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        List<GameObject> enemyList = objectPool.GetObjectList(enemyPrefab);
        if (enemyList == null) return;

        for (int j = 0; j < bulletBaseComponentList.Count; j++)
        {
            BulletBaseComponent bulletBaseComponent = bulletBaseComponentList[j];

            if (bulletBaseComponent.gameObject.activeSelf == false) continue;

            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i].activeSelf == false) continue;

                if (collisionSystem.HitSphereToSphere(enemyList[i].transform.position, bulletBaseComponent.transform.position, enemyList[i].transform.localScale.x * 0.5f, bulletBaseComponent.transform.localScale.x * 0.5f))
                {
                    ActorBaseComponent baseComponent = enemyList[i].GetComponent<ActorBaseComponent>();

                    enemyList[i].GetComponent<DamageComponent>().IsDamage = true;
                    enemyList[i].GetComponent<DamageComponent>().Damage = bulletBaseComponent.AttackPoint;

                    gameEvent.RemoveObject?.Invoke(bulletBaseComponent.gameObject);
                    bulletBaseComponent.GetComponent<BulletShotComponent>().IsFirst = false;
                }
            }
        }
    }

    public void AddComponentList(GameObject gameObject)
    {
        BulletBaseComponent baseComponent = gameObject.GetComponent<BulletBaseComponent>();

        if (baseComponent == null) return;

        bulletBaseComponentList.Add(baseComponent);
    }

    public void RemoveComponentList(GameObject gameObject)
    {
        BulletBaseComponent baseComponent = gameObject.GetComponent<BulletBaseComponent>();

        if (baseComponent == null) return;

        bulletBaseComponentList.Remove(baseComponent);
    }
}
