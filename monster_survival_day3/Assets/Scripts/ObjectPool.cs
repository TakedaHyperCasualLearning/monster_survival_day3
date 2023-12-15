using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    Dictionary<int, List<GameObject>> objectPoolList = new Dictionary<int, List<GameObject>>();

    private bool isNewGenerate = false;

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
                IsNewGenerate = false;
                return tempPool[i];
            }

            GameObject tempObject = GameObject.Instantiate(gameObject);
            tempObject.SetActive(true);
            tempPool.Add(tempObject);
            IsNewGenerate = true;
            return tempObject;
        }

        GameObject object1 = GameObject.Instantiate(gameObject);
        List<GameObject> tempList = new List<GameObject>();
        tempList.Add(object1);
        objectPoolList.Add(hashCode, tempList);
        object1.SetActive(true);
        IsNewGenerate = true;
        return object1;
    }

    private void RemoveObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public List<GameObject> GetObjectList(GameObject gameObject)
    {
        int hashCode = gameObject.GetHashCode();

        if (objectPoolList.ContainsKey(hashCode))
        {
            return objectPoolList[hashCode];
        }

        return null;
    }

    public bool IsNewGenerate { set => isNewGenerate = value; get => isNewGenerate; }
}
