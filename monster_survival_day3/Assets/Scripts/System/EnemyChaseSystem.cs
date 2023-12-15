using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseSystem
{
    private List<MoveComponent> moveComponentList = new List<MoveComponent>();

    GameObject target = null;

    public EnemyChaseSystem(GameEvent gameEvent, GameObject player)
    {
        target = player;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < moveComponentList.Count; i++)
        {
            MoveComponent moveComponent = moveComponentList[i];

            moveComponent.TargetPosition = target.transform.position;
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        MoveComponent moveComponent = gameObject.GetComponent<MoveComponent>();

        if (moveComponent == null) return;

        moveComponentList.Add(moveComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        MoveComponent moveComponent = gameObject.GetComponent<MoveComponent>();

        if (moveComponent == null) return;

        moveComponentList.Remove(moveComponent);
    }
}
