using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

    [SerializeField]
    InGameTime inGameTime;

    [SerializeField]
    Text m_text;
	
	// Update is called once per frame
	void Update ()
    {
        m_text.text = inGameTime.Day.ToString() + " days " + inGameTime.Hour.ToString() + " hours " + inGameTime.Min.ToString() + " min ";

    }
}
