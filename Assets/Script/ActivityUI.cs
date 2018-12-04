using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ActivityUI : MonoBehaviour {

    public GenericActivity m_activity;

    public int m_day;
    public int m_hour;   //do I need this?
    public int m_min;

    public enum Category{
        University,
        Heroic,
        Work,
        Relax,
        Sleep,
            ///add more?
    };

    public Category m_category;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI expiryTimer;
    public TextMeshProUGUI timeCost;

    //These are used to check conditions and influence UI display
    public bool m_mouseIsOver;
    public bool m_mouseIsDown;

	// Use this for initialization
	void Start ()
    {
        m_mouseIsOver = false;
        m_mouseIsDown = false;
        UpdateText();
    }

    private void FixedUpdate()
    {
        if (title.text != m_activity.Title)
        {
            UpdateText();
        }
    }

    void UpdateText()
    {
        title.text = m_activity.Title;
        description.text = m_activity.Text;
        expiryTimer.text = "Activity expires in " + m_day + "days " + m_hour + "hours " + m_min + "minutes";
        timeCost.text = "It takes " + m_activity.O1SuccessTimeCost.ToString() + " minutes to complete";
    }
}
