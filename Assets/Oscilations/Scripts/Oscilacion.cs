using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilacion : MonoBehaviour
{
    [SerializeField] private float amplitude = 1;
    [SerializeField] private float periodo = 1;
    Vector3 initialPosition;
    private void Update() { 
        float x = Mathf.Sin(5f * Time.time) + Mathf.Cos(Time.time / 3f) + Mathf.Sin(Time.time / 13f);
        transform.position = initialPosition + new Vector3(x, x, 0);
    }
    private void Start()
    {
        initialPosition = transform.position;
    }

}
