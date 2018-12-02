using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ActivityUI : MonoBehaviour {

    public GenericActivity m_activity;

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
    public TextMeshProUGUI timer;

    //These are used to check conditions and influence UI display
    public bool m_mouseIsOver;
    public bool m_mouseIsDown;

	// Use this for initialization
	void Start ()
    {
        m_mouseIsOver = false;
        m_mouseIsDown = false;
        title.text = m_activity.Title;
        description.text = m_activity.Text;
        timer.text = "This will take " + m_activity.Timer[0].ToString() + m_activity.Timer[1].ToString() + "Days " +
                     m_activity.Timer[3].ToString() + m_activity.Timer[4].ToString() + "hours " +
                     m_activity.Timer[6].ToString() + m_activity.Timer[7].ToString() + "minutes";
        //timer.text = m_activity.Timer;
    }

    private void FixedUpdate()
    {
        if (!m_mouseIsOver && m_mouseIsDown)
        {
            gameObject.SetActive(false);
        }
        if (title.text != m_activity.Title)
        {
            Debug.Log("Swapping");
            title.text = m_activity.Title;
            description.text = m_activity.Text;
            timer.text = m_activity.Timer;
        }
    }
    
    private void OnMouseEnter()
    {
        Debug.Log("in");
        //Highlight the activity icon
        //condition to select 1
        //DisplayInfo(true);
        m_mouseIsOver = true; //condition to select 1
    }

    private void OnMouseExit()
    {
        //take away highlight from activity icon
        Debug.Log("exit");
        //GetComponentInParent<ActivityUI>().DisplayInfo(false);
        GetComponentInParent<ActivityUI>().m_mouseIsOver = false; //condition to select 1
    }

}
