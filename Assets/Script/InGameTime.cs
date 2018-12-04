using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InGameTime : MonoBehaviour { //is mnmaking this static a possibility


    int m_day;
    int m_hour;
    int m_min;

    public int Day
    {
        get { return m_day; }
        set
        {
            if (value > m_day)
                m_day = value;

        }
    }
    public int Hour
    {
        get { return m_hour; }
        set
        {
            if (value > m_hour)
            {
                if (value < 24)
                    m_hour = value;
                else
                {
                    Day += value / 24;
                    m_hour = 0;
                    Hour = value % 24;
                }
            }
            //else Debug.LogWarning("received value smaller than precedent hour value");
        }
    }
    public int Min
    {
        get { return m_min; }
        set
        {
            if (value > m_min)
            {
                if (value < 60)
                    m_min = value;
                else
                {
                    Hour += value / 60;
                    m_min = 0;
                    Min = value % 60;
                }
            }
            //else Debug.LogWarning("received value smaller than precedent min value");
        }
    }

    // Use this for initialization
    void Start()
    {
        m_day = 0;
        m_hour = 0;
        m_min = 0;
    }

    public void UpdateTime(int day, int hour, int min)
    {
        Day += day;
        Hour += hour;
        Min += min;
    }

    
    //transform string "DD:HH:MM in an integer array
    public static int[] TimeStringToInt3(string sTime)
    {
        int[] dateArray = new int[3];
        int day;
        int.TryParse(sTime.Substring(0, 2), out day);
        int hour;
        int.TryParse(sTime.Substring(3, 2), out hour);
        int min;
        int.TryParse(sTime.Substring(6, 2), out min);

        //store in array
        dateArray[0] = day;
        dateArray[1] = hour;
        dateArray[2] = min;
        return dateArray;
    }

    //transform string "DD:HH:MM in one integer representing minutes
    public static int TimeStringToInt(string sTime)
    {
        Debug.Log(sTime.Length);
        int[] dateArray = new int[3];
        int day;
        if(!int.TryParse(sTime.Substring(0, 1), out day))
        {
            Debug.Log("Broke");
        }
        int hour;
        if(int.TryParse(sTime.Substring(2, 2), out hour))
        {
            Debug.Log("Broke");
        }
        int min;
        if(int.TryParse(sTime.Substring(5, 2), out min))
        {
            Debug.Log("Broke");
        }

        int time = (day * 1440) + (hour * 60) + (min);//1440 minutes in a day, 60 minutes in an hour
        Debug.Log(time.ToString());
        return time;
    }
    //transform day hour min in one integer
    public static int TimeInt3ToInt(int day, int hour, int min)
    {
        int time;
        time = (day * 1440) + (hour * 60) + (min); //1440 minutes in a day, 60 minutes in an hour
        return time;
    }

    //from an integer determine day hour min
    public static int[] TimeIntToDHM(int time)
    {
        int[] dateArray = new int[3];
        
        int day = time / 1440;
        int hour = (time % 1440) / 60;
        int min = (time % 1440) % 60;

        //store in array
        dateArray[0] = day;
        dateArray[1] = hour;
        dateArray[2] = min;
        return dateArray;
    }

    public static string TimeIntToString(int time)
    {
        string sday;
        int temp = time / 1440;
        if (temp < 10)
            sday = temp.ToString();
        else sday = temp.ToString();
        
        string shour;
        temp = (time % 1440) / 60;
        if (temp < 10)
            shour = "0" + temp.ToString();
        else shour = temp.ToString();
        
        string smin;
        temp = (time % 1440) % 60;
        if (temp < 10)
            smin = "0" + temp.ToString();
        else smin = temp.ToString();
        
        string sTime = sday + ":" + shour + ":" + smin; //1440 minutes in a day, 60 minutes in an hour
        return sTime;
    }
    //
    //- compare two
    //- int Sum(int first, int second)

}
