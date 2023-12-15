using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotSystem
{
    private GameEvent gameEvent = null;
    private ObjectPool objectPool = null;
    private Transform playerTransform = null;
    private List<PlayerShotComponent> playerShotComponentList = new List<PlayerShotComponent>();
    private List<PlayerInputComponent> playerInputComponents = new List<PlayerInputComponent>();

    public PlayerShotSystem(GameEvent gameEvent, ObjectPool objectPool, Transform playerTransform)
    {
        this.gameEvent = gameEvent;
        this.objectPool = objectPool;
        this.playerTransform = playerTransform;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < playerShotComponentList.Count; i++)
        {
            PlayerShotComponent playerShotComponent = playerShotComponentList[i];
            if (playerShotComponent.gameObject.activeSelf == false) continue;

            playerShotComponent.ShotTimer += Time.deltaTime;

            if (playerShotComponent.ShotTimer < playerShotComponent.ShotInterval) continue;

            if (!playerInputComponents[i].IsKeyDown) continue;
            playerShotComponent.ShotTimer = 0.0f;

            GameObject shot = objectPool.GenerateObject(playerShotComponent.ShotPrefab);
            int shotCount = objectPool.GetObjectList(playerShotComponent.ShotPrefab).Count;
            if (objectPool.IsNewGenerate)
            {
                gameEvent.AddComponentList?.Invoke(shot);
                objectPool.IsNewGenerate = false;
            }
            shot.transform.position = playerTransform.position;
        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        PlayerShotComponent playerShotComponent = gameObject.GetComponent<PlayerShotComponent>();
        PlayerInputComponent playerInputComponent = gameObject.GetComponent<PlayerInputComponent>();

        if (playerShotComponent == null || playerInputComponent == null) return;

        playerShotComponentList.Add(playerShotComponent);
        playerInputComponents.Add(playerInputComponent);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        PlayerShotComponent playerShotComponent = gameObject.GetComponent<PlayerShotComponent>();
        PlayerInputComponent playerInputComponent = gameObject.GetComponent<PlayerInputComponent>();

        if (playerShotComponent == null || playerInputComponent == null) return;

        playerShotComponentList.Remove(playerShotComponent);
        playerInputComponents.Remove(playerInputComponent);
    }
}
