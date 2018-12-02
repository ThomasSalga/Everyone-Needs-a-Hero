using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{
    public GenericActivity m_activity;
    public ActivityManager m_activityManager;
    public GameObject m_player;


    public void ResolveActivity()
    {
        m_player.GetComponent<StatHandler>().SetCrime(m_activity.O1SuccessCrimesChange);
        m_player.GetComponent<StatHandler>().SetGrade(m_activity.O1SuccessGradesChange);
        m_player.GetComponent<StatHandler>().SetMoney(m_activity.O1SuccessCashChange);
        m_player.GetComponent<StatHandler>().SetStamina(m_activity.O1SuccessStaminaChange);
        m_player.GetComponent<StatHandler>().SetStress(m_activity.O1SuccessStressChange);

        Debug.Log(m_activity.Category + " Done");
        //determine outcome
        //call for player stats update pass stats
        //
    }

    public void AskSwapToManager()
    {
        m_activityManager.SwapActivity(m_activity);
        //title.text = m_activity.Title;
        //description.text = m_activity.Text;
    }

}
