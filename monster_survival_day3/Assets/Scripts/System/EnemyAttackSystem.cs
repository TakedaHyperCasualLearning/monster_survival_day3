using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem
{
    private GameEvent gameEvent = null;
    private ObjectPool objectPool = null;
    private CollisionSystem collisionSystem = null;
    private GameObject player = null;
    private List<ActorBaseComponent> actorBaseComponentList = new List<ActorBaseComponent>();
    private List<DamageComponent> damageComponentList = new List<DamageComponent>();

    public EnemyAttackSystem(GameEvent gameEvent, ObjectPool objectPool, CollisionSystem collisionSystem, GameObject playerTransform)
    {
        this.gameEvent = gameEvent;
        this.objectPool = objectPool;
        this.collisionSystem = collisionSystem;
        this.player = playerTransform;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        if (player.GetComponent<DamageComponent>().IsDead) return;
        for (int i = 0; i < actorBaseComponentList.Count; i++)
        {
            ActorBaseComponent actorBaseComponent = actorBaseComponentList[i];
            if (actorBaseComponent.GetComponent<PlayerShotComponent>() != null) continue;

            if (collisionSystem.HitSphereToSphere(player.transform.position, actorBaseComponent.transform.position, player.transform.localScale.x * 0.5f, actorBaseComponent.transform.localScale.x * 0.5f))
            {
                player.GetComponent<DamageComponent>().IsDamage = true;
                player.GetComponent<DamageComponent>().Damage = actorBaseComponent.AttackPoint;
            }
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        ActorBaseComponent enemy = gameObject.GetComponent<ActorBaseComponent>();

        if (enemy == null) return;

        actorBaseComponentList.Add(enemy);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        ActorBaseComponent enemy = gameObject.GetComponent<ActorBaseComponent>();

        if (enemy == null) return;

        actorBaseComponentList.Remove(enemy);
    }


}
