using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTopDownMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   

    public void AddMovementInput(Vector2 axisMovementDirection)
    {
  

       rb.position =rb.position + axisMovementDirection * moveSpeed * Time.fixedDeltaTime;

    }

}
