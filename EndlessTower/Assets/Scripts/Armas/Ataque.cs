using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        int ataque = FindObjectOfType<Arma>().ataque;
        if (col.gameObject.tag == "Enemy")
        {
            IEnemy tmp = col.gameObject.GetComponent<IEnemy>();
            Debug.Log("Daño " + ataque);
            tmp.recibirDaño(ataque);
        }
    }
}
