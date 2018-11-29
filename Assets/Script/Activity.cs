using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{
    public GenericActivity m_activity;
    public ActivityManager m_activityManager;


    public void ResolveActivity()
    {
        Debug.Log(m_activity.Category + " Done");
        //determine outcome
        //call for player stats update pass stats
        //
    }

    public void AskSwapToManager()
    {
        m_activityManager.SwapActivity();
        //title.text = m_activity.Title;
        //description.text = m_activity.Text;
    }

}
