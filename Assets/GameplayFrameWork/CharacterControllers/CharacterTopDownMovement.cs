using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTopDownMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 1f;
    public bool keepInsideCameraFrustrum = true;
    public float cameraBoundsOffset = 1f;
    Vector3 screenPoint;
    Camera cameraReference;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        cameraReference = Camera.main;
    }
    public Vector2 GetNextPosition(Vector2 axisMovementDirection,float offSet=0)
    {
        return rb.position + axisMovementDirection*(1+offSet) * moveSpeed * Time.fixedDeltaTime;
    }
    
    public void AddMovementInput(Vector2 axisMovementDirection)
    {
 
        if (keepInsideCameraFrustrum)
        {
            screenPoint = cameraReference.WorldToViewportPoint(GetNextPosition(axisMovementDirection,cameraBoundsOffset));
            if (screenPoint.x < 0) return;
            if (screenPoint.y < 0) return;
            if (screenPoint.x > 1) return;
            if (screenPoint.y > 1) return;


        }
        rb.position = GetNextPosition(axisMovementDirection);

    }

}
