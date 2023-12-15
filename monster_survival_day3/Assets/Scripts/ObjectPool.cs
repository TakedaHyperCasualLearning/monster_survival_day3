using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    Dictionary<int, List<GameObject>> objectPoolList = new Dictionary<int, List<GameObject>>();

    public ObjectPool(GameEvent gameEvent)
    {
        gameEvent.RemoveObject += RemoveObject;
    }

    public GameObject GenerateObject(GameObject gameObject)
    {
        int hashCode = gameObject.GetHashCode();

        if (objectPoolList.ContainsKey(hashCode))
        {
            List<GameObject> tempPool = objectPoolList[hashCode];
            for (int i = 0; i < tempPool.Count; i++)
            {
                if (tempPool[i].activeSelf) continue;

                tempPool[i].SetActive(true);
                return tempPool[i];
            }

            GameObject tempObject = GameObject.Instantiate(gameObject);
            tempObject.SetActive(true);
            tempPool.Add(tempObject);
            return tempObject;
        }

        GameObject object1 = GameObject.Instantiate(gameObject);
        List<GameObject> tempList = new List<GameObject>();
        tempList.Add(object1);
        objectPoolList.Add(hashCode, tempList);
        object1.SetActive(true);
        return object1;
    }

    public void RemoveObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
