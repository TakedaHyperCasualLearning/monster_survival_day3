using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderComponent : MonoBehaviour
{
    private Vector3 position = Vector3.zero;
    private float radius = 0.0f;

    public Vector3 Position { set => position = value; get => position; }
    public float Radius { set => radius = value; get => radius; }
}
