using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
  
    void Update()
    {
        Vector3 mousePosition = GetWorldMousePosition();
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x)- Mathf.PI/2;
        RotateZ(angle);
    }
    private void RotateZ(float radianes)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radianes * Mathf.Rad2Deg);
    }
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        Vector4 worldPos = camera.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    
}
