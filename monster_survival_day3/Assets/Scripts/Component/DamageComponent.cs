using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    private bool isDamage = false;
    private int damage = 0;
    [SerializeField] private bool isDamageInterval = false;
    [SerializeField] private float damageInterval = 0.0f;
    private float damageTime = 0.0f;
    private bool isDead = false;

    public bool IsDamage { set => isDamage = value; get => isDamage; }
    public int Damage { set => damage = value; get => damage; }
    public bool IsDamageInterval { set => isDamageInterval = value; get => isDamageInterval; }
    public float DamageInterval { set => damageInterval = value; get => damageInterval; }
    public float DamageTime { set => damageTime = value; get => damageTime; }
    public bool IsDead { set => isDead = value; get => isDead; }
}
