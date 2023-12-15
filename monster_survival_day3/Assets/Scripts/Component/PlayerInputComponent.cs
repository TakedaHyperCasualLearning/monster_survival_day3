using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent : MonoBehaviour
{
    private KeyCode keyCode = KeyCode.None;
    private bool isKeyDown = false;

    public KeyCode KeyCode { set => keyCode = value; get => keyCode; }
    public bool IsKeyDown { set => isKeyDown = value; get => isKeyDown; }
}
