using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public int speed;

    private void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
