using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoArmaBasico : MonoBehaviour {
    public int daño;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<IEnemy>().recibirDaño(daño);
        }
    }
}
