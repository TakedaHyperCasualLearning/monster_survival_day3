using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpUISystem : MonoBehaviour
{
    private GameEvent gameEvent;
    private GameObject player;
    private List<LevelUpUIComponent> levelUpUIComponents = new List<LevelUpUIComponent>();

    public LevelUpUISystem(GameEvent gameEvent, GameObject player)
    {
        this.gameEvent = gameEvent;
        this.player = player;

        gameEvent.AddComponentList += AddComponentList;
        gameEvent.RemoveComponentList += RemoveComponentList;
    }

    public void OnUpdate()
    {
        for (int i = 0; i < levelUpUIComponents.Count; i++)
        {
            LevelUpUIComponent levelUpUIComponent = levelUpUIComponents[i];
            if (!levelUpUIComponent.gameObject.activeSelf) continue;

            PlayerLevelComponent playerLevelComponent = player.GetComponent<PlayerLevelComponent>();
            if (playerLevelComponent.ExperiencePoint > playerLevelComponent.ExperienceBorder)
            {
                playerLevelComponent.ExperiencePoint -= playerLevelComponent.ExperienceBorder;
                levelUpUIComponent.gameObject.SetActive(true);
            }

        }
    }

    private void AddComponentList(GameObject gameObject)
    {
        LevelUpUIComponent enemy = gameObject.GetComponent<LevelUpUIComponent>();

        if (enemy == null) return;

        levelUpUIComponents.Add(enemy);
    }

    private void RemoveComponentList(GameObject gameObject)
    {
        LevelUpUIComponent enemy = gameObject.GetComponent<LevelUpUIComponent>();

        if (enemy == null) return;

        levelUpUIComponents.Remove(enemy);
    }
}
