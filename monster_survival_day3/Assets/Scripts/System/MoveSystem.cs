using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem
{
    private GameEvent gameEvent = null;
    private List<MoveComponent> moveComponentList = new List<MoveComponent>();

    public MoveSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < moveComponentList.Count; i++)
        {
            MoveComponent moveComponent = moveComponentList[i];

            if (moveComponent.IsLookAtTarget)
            {
                moveComponent.ObjectTransform.LookAt(moveComponent.TargetPosition);
            }

            moveComponent.ObjectTransform.Translate(moveComponent.Direction * moveComponent.Speed * Time.deltaTime, Space.Self);
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
