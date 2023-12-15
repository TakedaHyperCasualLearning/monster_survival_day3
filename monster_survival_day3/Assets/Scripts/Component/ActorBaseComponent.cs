using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBaseComponent : MonoBehaviour
{
    private int hitPoint = 0;
    private int hitPointMax = 0;
    private int attackPoint = 0;

    public int HitPoint { set => hitPoint = value; get => hitPoint; }
    public int HitPointMax { set => hitPointMax = value; get => hitPointMax; }
    public int AttackPoint { set => attackPoint = value; get => attackPoint; }
}
