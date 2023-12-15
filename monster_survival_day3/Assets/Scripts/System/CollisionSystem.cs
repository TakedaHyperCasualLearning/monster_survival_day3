using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem
{
    private List<ColliderComponent> colliderComponentList = new List<ColliderComponent>();
    private GameEvent gameEvent;
    private Vector3 baseScreenPosition = Vector3.zero;

    public CollisionSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;

        baseScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10.0f));

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public bool HitSphereToSphere(Vector3 position1, Vector3 position2, float radius1, float radius2)
    {
        Vector3 distance = position1 - position2;
        float distanceLength = distance.magnitude;
        float hitLength = radius1 + radius2;

        if (distanceLength <= hitLength) return true;
        return false;
    }

    public Vector3 HitSphereToEdge(Vector3 position, float radius)
    {
        Vector3 result = new Vector2(0.0f, 0.0f);
        float left = position.x - radius;
        float right = position.x + radius;
        float front = position.z + radius;
        float back = position.z - radius;
        Vector3 cameraPosition = Camera.main.transform.position;

        if (left < cameraPosition.x - baseScreenPosition.x) result += Vector3.right;
        if (right > cameraPosition.x + baseScreenPosition.x) result += Vector3.left;
        if (front > cameraPosition.z + baseScreenPosition.z) result += Vector3.back;
        if (back < cameraPosition.z - baseScreenPosition.z) result += Vector3.forward;

        return result.normalized;
    }

    private void AddComponentList(GameObject gameObject)
    {
        ColliderComponent colliderComponent = gameObject.GetComponent<ColliderComponent>();

        if (colliderComponent == null) return;

        colliderComponentList.Add(colliderComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        ColliderComponent colliderComponent = gameObject.GetComponent<ColliderComponent>();

        if (colliderComponent == null) return;

        colliderComponentList.Remove(colliderComponent);
    }
}
