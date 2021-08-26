using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
<<<<<<< Updated upstream
    #region

    public static PlayerManager instance;

    public void Awake()
=======
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
>>>>>>> Stashed changes
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
