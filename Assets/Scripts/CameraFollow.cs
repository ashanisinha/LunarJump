using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    
    void Start()
    {
        transform.position = new Vector3(0f, 3.5f, -10f);
    }

    private void LateUpdate() { //transform is cameras position
        if (target.position.y > transform.position.y) {
           Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
           transform.position = newPosition;
        } 
    }
}
