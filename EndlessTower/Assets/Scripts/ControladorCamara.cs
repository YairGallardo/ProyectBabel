using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour {
    public Transform objetivo;
    public float limiteX;
    public float limiteZ;
    public float zOffset;

    float origenX;
    float origenZ;

    private void Start()
    {
        transform.position = new Vector3(objetivo.position.x,transform.position.y,objetivo.position.z-zOffset);
        origenX = transform.position.x;
        origenZ = transform.position.z;
    }

    void Update () {
        float newX = objetivo.position.x;
        float newZ = objetivo.position.z - zOffset;

        if (newX >= origenX+limiteX || newX <= origenX - limiteX) {
            newX = transform.position.x;
        }

        if (newZ >= origenZ + limiteZ || newZ <= origenZ - limiteZ)
        {
            newZ = transform.position.z;
        }


        

        transform.position = new Vector3(newX,transform.position.y,newZ);

    }
}
