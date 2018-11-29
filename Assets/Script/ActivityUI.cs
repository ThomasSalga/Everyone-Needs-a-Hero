using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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

    public Text title;
    public Text description;
    public Text timer;

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
        //timer.text = m_activity.Timer;
    }

    private void FixedUpdate()
    {
        if (title.text != m_activity.Title)
        {
            Debug.Log("Swapping");
            title.text = m_activity.Title;
            description.text = m_activity.Text;
        }
    }

    //public void DisplayInfo(bool trueORfalse)
    //{
    //    //Do we want to display any information?
    //    transform.GetChild(0).gameObject.SetActive(trueORfalse);
    //}

    private void OnMouseEnter()
    {
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
