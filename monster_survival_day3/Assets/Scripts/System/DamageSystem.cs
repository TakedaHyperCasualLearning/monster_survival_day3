using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem
{
    private GameEvent gameEvent = null;
    private GameObject player = null;
    private List<DamageComponent> damageComponentList = new List<DamageComponent>();
    private List<ActorBaseComponent> actorBaseComponentList = new List<ActorBaseComponent>();

    public DamageSystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        this.player = player;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < damageComponentList.Count; i++)
        {
            DamageComponent damageComponent = damageComponentList[i];

            if (damageComponent.IsDamageInterval) damageComponent.DamageTime += Time.deltaTime;

            if (damageComponent.IsDamageInterval && damageComponent.DamageTime < damageComponent.DamageInterval) continue;

            if (!damageComponent.IsDamage) return;

            ActorBaseComponent actorBaseComponent = actorBaseComponentList[i];

            actorBaseComponent.HitPoint -= damageComponent.Damage;

            if (actorBaseComponent.HitPoint <= 0)
            {
                damageComponent.IsDead = true;
                gameEvent.RemoveObject?.Invoke(actorBaseComponent.gameObject);
                player.GetComponent<PlayerLevelComponent>().ExperiencePoint += 1;

            }

            damageComponent.DamageTime = 0;
            damageComponent.IsDamage = false;
            damageComponent.Damage = 0;

        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();
        ActorBaseComponent actorBaseComponent = gameObject.GetComponent<ActorBaseComponent>();

        if (damageComponent == null || actorBaseComponent == null) return;

        damageComponentList.Add(damageComponent);
        actorBaseComponentList.Add(actorBaseComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        DamageComponent damageComponent = gameObject.GetComponent<DamageComponent>();
        ActorBaseComponent actorBaseComponent = gameObject.GetComponent<ActorBaseComponent>();

        if (damageComponent == null || actorBaseComponent == null) return;

        damageComponentList.Remove(damageComponent);
        actorBaseComponentList.Add(actorBaseComponent);
    }
}
