using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heist.Enums;

[CreateAssetMenu(menuName = "Heist/Character")]
public class Character : ScriptableObject
{
    [Header("Character Identification")]
    public string characterName;

    [Header("Character Parameters")]
    public float speed;
    public int health;

    [Header("Character Appearance")]
    public Sprite sprite;
    public Vector3 scale = Vector3.one;
}
