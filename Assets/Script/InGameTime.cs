using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InGameTime : MonoBehaviour {


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
            else Debug.LogWarning("received value smaller than precedent hour value");
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
            else Debug.LogWarning("received value smaller than precedent min value");
        }
    }

    // Use this for initialization
    void Start ()
    {
        m_day = 0;
        m_hour = 0;
        m_min = 0;
    }

    public void UpdateTime()
    { }
}
