using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Melee,
    Ranged,
    Flying
}

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyInfo : ScriptableObject
{
    public EnemyType enemyType;
    public int health;
    public float speed;
    public GameObject enemyPrefab; 
}
