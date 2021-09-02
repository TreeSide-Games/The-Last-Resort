using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obrazeniazombie : MonoBehaviour
{
    public bool Leczy;
    private Gracz player;
    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Gracz>();
        if (player)
        {
            //Debug.Log("Działa");
            if (Leczy)
            {
                player.DodajZycie();
                Destroy(gameObject);
            }
            else
            {
                player.OdejmijZycie();

                if(gameObject.tag == "Brutal")
                {
                    player.OdejmijZycie();
                }

            }

        }
    }
}