using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletShotSystem
{
    private GameEvent gameEvent = null;
    private Transform playerTransform = null;
    private List<MoveComponent> moveComponentList = new List<MoveComponent>();
    private List<BulletShotComponent> bulletShotComponentList = new List<BulletShotComponent>();

    public BulletShotSystem(GameEvent gameEvent, Transform transform)
    {
        this.gameEvent = gameEvent;
        this.playerTransform = transform;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < moveComponentList.Count; i++)
        {
            MoveComponent moveComponent = moveComponentList[i];
            BulletShotComponent bulletShotComponent = bulletShotComponentList[i];

            if (!bulletShotComponent.IsFirst)
            {
                bulletShotComponent.IsFirst = true;
                bulletShotComponent.Direction = playerTransform.forward;
            }

            moveComponent.Direction = bulletShotComponent.Direction;
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        MoveComponent moveComponent = gameObject.GetComponent<MoveComponent>();
        BulletShotComponent bulletShotComponent = gameObject.GetComponent<BulletShotComponent>();

        if (moveComponent == null || bulletShotComponent == null) return;

        moveComponentList.Add(moveComponent);
        bulletShotComponentList.Add(bulletShotComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        MoveComponent moveComponent = gameObject.GetComponent<MoveComponent>();
        BulletShotComponent bulletShotComponent = gameObject.GetComponent<BulletShotComponent>();

        if (moveComponent == null || bulletShotComponent == null) return;

        moveComponentList.Remove(moveComponent);
        bulletShotComponentList.Remove(bulletShotComponent);
    }
}
