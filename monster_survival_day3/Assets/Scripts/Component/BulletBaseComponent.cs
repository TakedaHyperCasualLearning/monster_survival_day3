using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBaseComponent : MonoBehaviour
{
    [SerializeField] private int attackPoint = 0;

    public int AttackPoint { set => attackPoint = value; get => attackPoint; }
}
