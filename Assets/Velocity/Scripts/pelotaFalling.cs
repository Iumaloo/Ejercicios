using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelotaFalling : MonoBehaviour
{
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector acceleration;
    [SerializeField] private MyVector velocity;

    [Header("World")]
    [SerializeField] Camera camera;
    [SerializeField] Transform blackHole;

    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        transform.position = new Vector3(position.x, position.y, 0);

    }
    private void Update()
    {
        position.Draw(Color.green);
        velocity.Draw(position, Color.cyan);
        acceleration.Draw(position, Color.blue);


        MyVector thePosition = new MyVector(transform.position.x, transform.position.y);
        MyVector gargantuaPosition = new MyVector(blackHole.position.x,blackHole.position.y);
        acceleration = gargantuaPosition - thePosition;
    }

  
}
