using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotComponent : MonoBehaviour
{
    private Vector3 direction = Vector3.zero;
    private bool isFirst = false;

    public Vector3 Direction { set => direction = value; get => direction; }
    public bool IsFirst { set => isFirst = value; get => isFirst; }
}
