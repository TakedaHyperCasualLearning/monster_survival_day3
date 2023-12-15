using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelComponent : MonoBehaviour
{
    private int experiencePoint;
    private int experienceBorder;
    private int attackLevel;
    private int hitPointLevel;
    private int shotSpeedLevel;
    private bool isLevelUp;

    public int ExperiencePoint { set => experiencePoint = value; get => experiencePoint; }
    public int ExperienceBorder { set => experienceBorder = value; get => experienceBorder; }
    public int AttackLevel { set => attackLevel = value; get => attackLevel; }
    public int HitPointLevel { set => HitPointLevel = value; get => hitPointLevel; }
    public int ShotSpeedLevel { set => shotSpeedLevel = value; get => shotSpeedLevel; }
    public bool IsLevelUp { set => isLevelUp = value; get => isLevelUp; }
}
