using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private Transform objectTransform = null;
    private Vector3 direction = Vector3.zero;
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private bool isLookAtTarget = false;
    private Vector3 targetPosition = Vector3.zero;

    public Transform ObjectTransform { set => objectTransform = value; get => objectTransform; }
    public Vector3 Direction { set => direction = value; get => direction; }
    public float Speed { set => speed = value; get => speed; }
    public bool IsLookAtTarget { set => isLookAtTarget = value; get => isLookAtTarget; }
    public Vector3 TargetPosition { set => targetPosition = value; get => targetPosition; }
}
