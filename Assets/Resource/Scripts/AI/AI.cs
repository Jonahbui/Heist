using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Heist.Enums;

public class AI : MonoBehaviour
{
    // AI parameters
    public Character ai;                    // Provides information about the AI and movement
    public Hostility hostility;             // Determines whether or not the AI is aggressive towards the player

    // AI Sprite vars
    public GameObject spriteObject;         // A reference to the gameobject that has the SpriteRenderer of the AI
    public SpriteRenderer spriteRenderer;

    // Add some way to reference player(s) so that AI can target them

    protected virtual void Awake()
    {
        if(spriteRenderer == null)
            spriteRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        else
            throw new NullReferenceException($"SpriteRenderer not foudn for {this.name}.");
        // Set the sprite of the AI so that it is visible on startup
        if (ai != null)
            spriteRenderer.sprite = ai.sprite;
        else
            throw new NullReferenceException($"Character has not been assigned to {this.name}.");

    }

    protected virtual void Start()
    { 
    
    }

    protected virtual void Update()
    {
        ai.Move(this.transform);
    }

    /// <summary>
    /// Used to update the target of the AI.
    /// </summary>
    protected void UpdateTarget()// Maybe pass in a list of players
    { 
    
    }
}
