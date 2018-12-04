using UnityEngine;

public class Activity : MonoBehaviour
{
    public GenericActivity m_activity;
    public ActivityManager m_activityManager;
    public GameObject m_player;

    public int m_daysLeft;
    public int m_hoursLeft;
    public int m_minsLeft;

    public bool m_expired;

    public bool wellbeing;


    public void ResolveActivity()
    {
        if (!m_expired)
        {
            int rand;
            //check if success or fail
            if (m_player.GetComponent<StatHandler>().GetStress() < 50)
                rand = (int)Random.Range(1f, m_player.GetComponent<StatHandler>().GetStress());
            else rand = (int)Random.Range(1f, 50f);
            //if success
            if (rand > 50)
            {
                m_player.GetComponent<StatHandler>().SetCrime(m_activity.O1SuccessCrimesChange);
                m_player.GetComponent<StatHandler>().SetGrade(m_activity.O1SuccessGradesChange);
                m_player.GetComponent<StatHandler>().SetMoney(m_activity.O1SuccessCashChange);
                m_player.GetComponent<StatHandler>().SetStamina(m_activity.O1SuccessStaminaChange);
                m_player.GetComponent<StatHandler>().SetStress(m_activity.O1SuccessStressChange);

                m_activityManager.GetComponent<ActivityManager>().UpdateGlobalTimer(m_activity.O1SuccessTimeCost);
                m_expired = UpdateTimer(m_activity.O1SuccessTimeCost);
            }
            else
            {
                m_player.GetComponent<StatHandler>().SetCrime(m_activity.O1FailCrimesChange);
                m_player.GetComponent<StatHandler>().SetGrade(m_activity.O1FailGradesChange);
                m_player.GetComponent<StatHandler>().SetMoney(m_activity.O1FailCashChange);
                m_player.GetComponent<StatHandler>().SetStamina(m_activity.O1FailStaminaChange);
                if(!wellbeing)
                    m_player.GetComponent<StatHandler>().SetStress(m_activity.O1FailStressChange);
                
                m_activityManager.GetComponent<ActivityManager>().UpdateGlobalTimer(m_activity.O1FailTimeCost);
                m_expired = UpdateTimer(m_activity.O1FailTimeCost);
            }
            if (wellbeing)
            {
                //m_player.GetComponent<StatHandler>().SetCrime(m_activity.O1SuccessCrimesChange);
                //m_player.GetComponent<StatHandler>().SetGrade(m_activity.O1SuccessGradesChange);
                //m_player.GetComponent<StatHandler>().SetMoney(m_activity.O1SuccessCashChange);
                //m_player.GetComponent<StatHandler>().SetStamina(m_activity.O1SuccessStaminaChange);
                //m_player.GetComponent<StatHandler>().SetStress(m_activity.O1SuccessStressChange);
                //
                //m_activityManager.GetComponent<ActivityManager>().UpdateGlobalTimer(m_activity.ski)
            }
            //Debug.Log(m_activity.Category + " Done");
        }
        else
        {
            //activity has expired
            m_player.GetComponent<StatHandler>().SetCrime(m_activity.SkipCrimesChange);
            m_player.GetComponent<StatHandler>().SetGrade(m_activity.SkipGradesChange);
            m_player.GetComponent<StatHandler>().SetMoney(m_activity.SkipCashChange);
            m_player.GetComponent<StatHandler>().SetStamina(m_activity.SkipStaminaChange);
            m_player.GetComponent<StatHandler>().SetStress(m_activity.SkipStressChange);

            m_activityManager.GetComponent<ActivityManager>().UpdateGlobalTimer(m_activity.SkipTimeCost);
            m_expired = UpdateTimer(m_activity.SkipTimeCost);
        }
        
    }

    public void AskSwapToManager()
    {
        m_activityManager.SwapActivity(m_activity);
        //title.text = m_activity.Title;
        //description.text = m_activity.Text;
    }

    public int GetTimerDayAsInt()
    {
        string dayString = m_activity.Timer.Substring(0, 2);
        
        int day = 0;

        if (int.TryParse(dayString, out day))
        {
            // you know that the parsing attempt
            // was successful
        }
        return day;
    }

    public int GetTimerHourAsInt()
    {
        string hourString = m_activity.Timer.Substring(3, 2);

        int hour = 0;

        if (int.TryParse(hourString, out hour))
        {
            // you know that the parsing attempt
            // was successful
        }
        return hour;
    }

    public int GetTimerMinAsInt()
    {
        string minString = m_activity.Timer.Substring(6, 2);

        int min = 0;

        if (int.TryParse(minString, out min))
        {
            // you know that the parsing attempt
            // was successful
        }
        return min;
    }
    

    public bool UpdateTimer(int timeExpired)
    {
        int newTimer = InGameTime.TimeStringToInt(m_activity.Timer) - timeExpired;
        if (newTimer > 0)
        {
            m_activity.Timer = InGameTime.TimeIntToString(newTimer);
            m_expired = false;
            return false;
        }
        else return true;

       // string d = timeExpired.Substring(0, 2); //days past
       // string h = timeExpired.Substring(3, 2); //hours past
       // string m = timeExpired.Substring(6, 2); //mins past
       //
       // int days;
       // int hours;
       // int mins;
       //
       // if(int.TryParse(d, out days))
       // {
       //     int newDay = GetTimerDayAsInt() - days;
       //     if (newDay < 0)
       //         return false;
       //     else
       //     {
       //         m_activity.Timer.Replace(m_activity.Timer.Substring(0, 2), newDay.ToString());
       //         return true;
       //     }
       // }
       //
       // if (int.TryParse(h, out hours))
       // {
       //     int newHour = GetTimerHourAsInt() - hours;
       //     if (newHour < 0)
       //         return false;
       //     else
       //     {
       //         m_activity.Timer.Replace(m_activity.Timer.Substring(3, 2), newHour.ToString());
       //         return true;
       //     }
       // }
       //
       // if (int.TryParse(m, out mins))
       // {
       //     int newMin = GetTimerMinAsInt() - mins;
       //     if (newMin < 0)
       //         return false;
       //     else
       //     {
       //         m_activity.Timer.Replace(m_activity.Timer.Substring(6, 2), newMin.ToString());
       //         return true;
       //     }
       // }
       //
       // return false;
    }

}
