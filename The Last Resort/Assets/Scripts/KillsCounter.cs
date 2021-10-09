using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillsCounter : MonoBehaviour
{
    public GameObject counter;
    private int zombieCount = 0;
    
    public void addZombieKill()
    {
        zombieCount++;
        counter.GetComponent<TextMeshProUGUI>().text = "Killed Zombie: " + zombieCount;
    }

    public int getZombieKill()
    {
        return zombieCount;
    }
}
