using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter instance;
    [SerializeField]
    TextMeshProUGUI enemyCounterTMP;
    [HideInInspector]
    public int counterEnemy;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyCounterCanvas()
    {
        enemyCounterTMP.text = counterEnemy.ToString();
    }
}
