using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveSystem
{
    private GameEvent gameEvent = null;
    private List<CameraMoveComponent> cameraMoveComponentList = new List<CameraMoveComponent>();
    private Transform playerTransform = null;

    public CameraMoveSystem(GameEvent gameEvent, Transform playerTransform)
    {
        this.gameEvent = gameEvent;
        this.playerTransform = playerTransform;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void Update()
    {
        for (int i = 0; i < cameraMoveComponentList.Count; i++)
        {
            CameraMoveComponent cameraMoveComponent = cameraMoveComponentList[i];
            Vector3 playerPosition = playerTransform.position;
            Vector3 cameraPosition = cameraMoveComponent.CameraObject.transform.position;
            cameraPosition = playerPosition + cameraMoveComponent.PositionOffset;
            cameraMoveComponent.CameraObject.transform.position = cameraPosition;
        }
    }

    public void AddComponentList(GameObject gameObject)
    {
        CameraMoveComponent cameraMoveComponent = gameObject.GetComponent<CameraMoveComponent>();

        if (cameraMoveComponent == null) return;

        cameraMoveComponentList.Add(cameraMoveComponent);
    }

    public void RemoveComponentList(GameObject gameObject)
    {
        CameraMoveComponent cameraMoveComponent = gameObject.GetComponent<CameraMoveComponent>();

        if (cameraMoveComponent == null) return;

        cameraMoveComponentList.Remove(cameraMoveComponent);
    }
}
