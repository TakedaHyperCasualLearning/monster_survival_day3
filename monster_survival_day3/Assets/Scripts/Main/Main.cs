using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab = null;
    private GameEvent gameEvent = new GameEvent();

    private MoveSystem moveSystem = null;
    private PlayerInputSystem inputSystem = null;

    void Start()
    {
        GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        moveSystem = new MoveSystem(gameEvent);
        inputSystem = new PlayerInputSystem(gameEvent);

        gameEvent.AddComponentList(player);
    }

    void Update()
    {
        moveSystem.OnUpdate();
        inputSystem.OnUpdate();
    }
}
