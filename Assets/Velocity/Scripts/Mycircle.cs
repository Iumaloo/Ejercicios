using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Mycircle : MonoBehaviour
{
    [SerializeField]
    private MyVector position;
    //private MyVector displacement;
    [SerializeField] private MyVector acceleration;
    [SerializeField] private MyVector velocity;
    [Range(0f, 1f)] [SerializeField] private float dampingFactor = 0.9f;

    [Header("World")]
    [SerializeField] Camera camera;

    private int currentAcceleration = 0;
    private readonly MyVector[] directions = new MyVector[4]
    {
        new MyVector (x:0, y:-9.8f),
        new MyVector (x:9.8f, y:0f),
        new MyVector (x:0, y:9.8f),
        new MyVector (x:-9.8f, y:0f)
    };
    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);
    }

    
    void Update()
    {
        position.Draw(Color.green);
        acceleration.Draw(position, Color.blue);
        velocity.Draw(position, Color.red);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Con esta wea se cambia la dirección

            acceleration = directions[(++currentAcceleration) % directions.Length];
            velocity *= 0;
        }

    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        Debug.Log("it moves");
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        //checando si la pelota sale de la pantalla horizontal/
        if (position.x > camera.orthographicSize)
        {
            velocity.x *= -1;
            position.x = camera.orthographicSize;
            velocity *= dampingFactor; 

        }
        else if (position.x < -camera.orthographicSize)
        {
            velocity.x *= -1;
            position.x = -camera.orthographicSize;
            velocity *= dampingFactor; 

        }
        //checando si la pelota sale de la pantalla vertical/
        if (position.y > camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = camera.orthographicSize;
            velocity *= dampingFactor;
        }
        else if (position.y < -camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = -camera.orthographicSize;
            velocity *= dampingFactor; 
        }
        
        transform.position = new Vector3(position.x, position.y);
    }


   /* private void CheckBounds(ref float x, ref float displacementX, float halfWidth)
    {
        if (Mathf.Abs(x) > halfWidth)
        {
            displacementX = displacementX * -1;
            x = Mathf.Sign(x) * camera.orthographicSize;
        }

    }*/
}
