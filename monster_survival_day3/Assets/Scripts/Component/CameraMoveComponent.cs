using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveComponent : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject = null;
    [SerializeField] private Vector3 positionOffset = Vector3.zero;

    public GameObject CameraObject { set => cameraObject = value; get => cameraObject; }
    public Vector3 PositionOffset { set => positionOffset = value; get => positionOffset; }
}
