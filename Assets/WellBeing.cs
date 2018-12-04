using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellBeing : MonoBehaviour {

    //public Activity m_activityUni;
    //public Activity m_activityCrime;
    //public Activity m_activityWork;
    //public Activity m_activityRelax;
    //public Activity m_activitySleep;

    [SerializeField]
    StatHandler player;

    public void WellBeingActivity()
    {
        //player.
        player.SetStress(-100);
    }
}
