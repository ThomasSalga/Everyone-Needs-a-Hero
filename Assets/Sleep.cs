using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour {

    [SerializeField]
    StatHandler player;

    public void SleepActivity()
    {
        player.SetStamina(100);
    }
}
