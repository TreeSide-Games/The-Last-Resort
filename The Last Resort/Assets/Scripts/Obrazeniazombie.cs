using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obrazeniazombie : MonoBehaviour
{
    public bool Leczy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Gracz>())
        {
            //Debug.Log("Działa");
            if (Leczy)
            {
                other.GetComponent<Gracz>().DodajZycie();
                Destroy(gameObject);
            }
            else
            {
                other.GetComponent<Gracz>().OdejmijZycie();
                

            }

        }
    }
}