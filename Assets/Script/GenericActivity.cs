using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Activity", menuName = "Activity")]
public class GenericActivity : ScriptableObject
{
    public int ID;
    public Sprite icon;
    
    public string Category;
    public string Title;
    public string Timer;
    public string Text;
    public string Option1;
    public string Option1Success;
    public string Option1Fail;
    public string Option2;
    public string Option2Success;
    public string Option2Fail;
    public int O1SuccessStaminaChange;
    public int O1SuccessStressChange;
    public int O1SuccessCashChange;
    public int O1SuccessGradesChange;
    public int O1SuccessCrimesChange;
    public int O1SuccessTimeCost;
    public int O1FailStaminaChange;
    public int O1FailStressChange;
    public int O1FailCashChange;
    public int O1FailGradesChange;
    public int O1FailCrimesChange;
    public int O1FailTimeCost;
    public int O2SuccessStaminaChange;
    public int O2SuccessStressChange;
    public int O2SuccessCashChange;
    public int O2SuccessGradesChange;
    public int O2SuccessCrimesChange;
    public int O2SuccessTimeCost;
    public int O2FailStaminaChange;
    public int O2FailStressChange;
    public int O2FailCashChange;
    public int O2FailGradesChange;
    public int O2FailCrimesChange;
    public int O2FailTimeCost;
    public int SkipStaminaChange;
    public int SkipStressChange;
    public int SkipCashChange;
    public int SkipGradesChange;
    public int SkipCrimesChange;
    public int SkipTimeCost;
}

