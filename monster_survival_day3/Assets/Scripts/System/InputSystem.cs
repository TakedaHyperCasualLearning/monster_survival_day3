using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem
{
    GameEvent gameEvent;
    private List<PlayerInputComponent> inputComponentList = new List<PlayerInputComponent>();
    private List<MoveComponent> moveComponentList = new List<MoveComponent>();

    public PlayerInputSystem(GameEvent gameEvent)
    {
        this.gameEvent = gameEvent;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < inputComponentList.Count; i++)
        {
            PlayerInputComponent inputComponent = inputComponentList[i];
            MoveComponent moveComponent = moveComponentList[i];

            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.A)) direction = Vector3.left;
            if (Input.GetKey(KeyCode.D)) direction = Vector3.right;
            if (Input.GetKey(KeyCode.W)) direction = Vector3.forward;
            if (Input.GetKey(KeyCode.S)) direction = Vector3.back;

            moveComponent.Direction = direction;

            Vector3 playerPoint = Camera.main.WorldToScreenPoint(moveComponent.ObjectTransform.position);
            Vector3 rotationDirection = Input.mousePosition - playerPoint;
            rotationDirection = rotationDirection.normalized;
            rotationDirection.z = 0.0f;
            moveComponent.TargetPosition = Camera.main.ScreenToWorldPoint(playerPoint + rotationDirection);

            if (Input.GetMouseButton(0))
            {
                inputComponent.IsKeyDown = true;
            }
            else
            {
                inputComponent.IsKeyDown = false;
            }
        }

    }

    private void AddComponentList(GameObject gameObject)
    {
        PlayerInputComponent inputComponent = gameObject.GetComponent<PlayerInputComponent>();
        MoveComponent moveComponent = gameObject.GetComponent<MoveComponent>();

        if (inputComponent == null || moveComponent == null) return;

        inputComponentList.Add(inputComponent);
        moveComponentList.Add(moveComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        PlayerInputComponent inputComponent = gameObject.GetComponent<PlayerInputComponent>();
        MoveComponent moveComponent = gameObject.GetComponent<MoveComponent>();

        if (inputComponent == null || moveComponent == null) return;

        inputComponentList.Remove(inputComponent);
        moveComponentList.Remove(moveComponent);
    }
}
