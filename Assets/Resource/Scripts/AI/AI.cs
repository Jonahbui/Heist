using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Heist.Enums;

public class AI : MonoBehaviour
{
    [Header("AI Parameters")]
    public Character ai;                    // Provides information about the AI and movement
    public Hostility hostility;             // Determines whether or not the AI is aggressive towards the player
    public bool idleOnCollision;
    protected GameObject target;

    [Header("AI Sprite")]
    public GameObject spriteObject;         // A reference to the gameobject that has the SpriteRenderer of the AI
    public SpriteRenderer spriteRenderer;

    [Header("AI Physics")]
    public LayerMask castLayer;
    public Rigidbody2D rigidbody2d;
    public Collider2D topCollider;
    public Collider2D bottomCollider;
    public Collider2D leftCollider;
    public Collider2D rightCollider;

    [Header("AI Animation")]
    public Animator animator;

    [Header("AI Movement")]
    public Movement movement;
    public Direction direction;
    public bool isIdle;

    // Add some way to reference player(s) so that AI can target them

    //---------------------------------------------------------------------------------------------
    // Unity Functions
    //---------------------------------------------------------------------------------------------
    protected virtual void Awake()
    {
        if(spriteRenderer == null)
            spriteRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            throw new NullReferenceException($"SpriteRenderer not found for {this.name}.");

        if(rigidbody2d == null)
            rigidbody2d = this.transform.GetChild(0).GetComponent<Rigidbody2D>();
        if (rigidbody2d == null)
            throw new NullReferenceException($"RigidBody2D not found for {this.name}.");

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
        if (GameManager.Instance.isPlaying)
        {
            if (!isIdle)
            {
                Move(this.transform);
            }
            else
            {
                StartCoroutine(Idle(1f, true));
            }
        }
    }

    /// <summary>
    /// Used to update the target of the AI.
    /// </summary>
    protected void UpdateTarget()// Maybe pass in a list of players
    { 
    
    }

    //---------------------------------------------------------------------------------------------
    // AI Attack
    //---------------------------------------------------------------------------------------------
    protected virtual void Attack()
    {

    }

    //---------------------------------------------------------------------------------------------
    // AI Movement
    //---------------------------------------------------------------------------------------------
    /// <summary>
    /// Used to move the object with their transform passed in.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="target"></param>
    protected void Move(Transform t)
    {
        switch (movement)
        {
            case Movement.Basic:
                MoveBasic(t);
                break;
            default:
                break;
        }
    }

    protected void MoveBasic(Transform t)
    {
        // Do animation work here
        if (target == null)
        {
            switch (direction)
            {
                case Direction.Up:
                    t.Translate(Vector3.up * ai.speed, Space.Self);
                    break;
                case Direction.Down:
                    t.Translate(Vector3.down * ai.speed, Space.Self);
                    break;
                case Direction.Left:
                    t.Translate(Vector3.left * ai.speed, Space.Self);
                    break;
                case Direction.Right:
                    t.Translate(Vector3.right * ai.speed, Space.Self);
                    break;
            }
            if (idleOnCollision)
            { 
                isIdle = UpdateDirection();
            }
        }
        else
        {

        }
    }

    protected virtual IEnumerator Idle(float time, bool moveOnTimeout = false)
    {
        yield return new WaitForSeconds(time);
        if (moveOnTimeout)
        {
            isIdle = false;
        }
    }

    protected virtual void Chase()
    { 
    
    }

    protected bool UpdateDirection()
    {
        RaycastHit2D topHit = Physics2D.Raycast(topCollider.transform.position, Vector2.up, 0.1f, castLayer);
        RaycastHit2D bottomHit = Physics2D.Raycast(bottomCollider.transform.position, Vector2.down, 0.1f, castLayer);
        RaycastHit2D leftHit = Physics2D.Raycast(leftCollider.transform.position, Vector2.left, 0.1f, castLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightCollider.transform.position, Vector2.right, 0.1f, castLayer);

        if (topHit.collider != null && topHit.collider.gameObject != null)
        {
            direction = Direction.Left;
            return true;
        }
        if (bottomHit.collider != null && bottomHit.collider.gameObject != null)
        {
            direction = Direction.Right;
            return true;
        }
        if (leftHit.collider != null && leftHit.collider.gameObject != null)
        {
            direction = Direction.Down;
            return true;
        }
        if (rightHit.collider != null && rightHit.collider.gameObject != null)
        {
            direction = Direction.Up;
            return true;
        }
        return false;
    }
}
