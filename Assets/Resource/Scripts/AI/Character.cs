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

    [Header("Character Movement")]
    public Movement movement;

    /// <summary>
    /// Used to move the object with their transform passed in.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="target"></param>
    public void Move(Transform t, GameObject target = null)
    {
        switch (movement)
        {
            case Movement.Basic:
                MoveBasic(t, target);
                break;
            default:
                break;
        }
    }

    public void MoveBasic(Transform t, GameObject target = null)
    {
        if (target == null)
        {
            t.Translate(Vector3.up*.01f, Space.Self);
        }
        else
        { 
        
        }
    }
}
