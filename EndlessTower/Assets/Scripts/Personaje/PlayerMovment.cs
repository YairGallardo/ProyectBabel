using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    public float moveSpeed = 8f;
    public Joystick joystick;
    Animator anim;


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveVector);
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
            anim.SetFloat("vel",1f);
        }
        else {
            anim.SetFloat("vel",0f);
        }

        
        
    }
}
