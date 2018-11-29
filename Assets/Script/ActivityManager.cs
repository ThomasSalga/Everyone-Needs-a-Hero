using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour {

    //[SerializeField]
    //GameObject m_activityGO;
    public GenericActivity m_activity;

    List<GenericActivity> m_activityList = new List<GenericActivity>();
    bool isLoaded = false;

    [SerializeField]
    GameObject inGameTime;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<GenericActivity> GetActivityList()
    {
        return m_activityList;
    }

    // Use this for initialization
    void Start()
    {
        Load(Resources.Load<TextAsset>("activityData"));
        WriteInActivityFile(0); //just to get rid of it
        WriteInActivityFile(1); //just to get rid of it
        WriteInActivityFile(2);
        //m_activity.Category = "asd";
        //spawn 
    }

    public void Load(TextAsset csv)
    {
        m_activityList.Clear();
        string[][] dataGrid = CsvParser.Parse(csv.text);
        for (int i = 0; i < dataGrid.Length; i++)
        {
            if (dataGrid[0][i] != "")
            {
                GenericActivity activity = ScriptableObject.CreateInstance<GenericActivity>();
                //Activity activity = new Activity();
                //Instantiate<GameObject>(m_activityGO);

                activity.ID = i;

                activity.Category = dataGrid[i][0];
                activity.Title = dataGrid[i][1];
                activity.Timer = dataGrid[i][2];
                activity.Text = dataGrid[i][3];
                activity.Option1 = dataGrid[i][4];
                activity.Option1Success = dataGrid[i][5];
                activity.Option1Fail = dataGrid[i][6];
                activity.Option2 = dataGrid[i][7];
                activity.Option2Success = dataGrid[i][8];
                activity.Option2Fail = dataGrid[i][9];

                int.TryParse(dataGrid[i][10], out activity.O1SuccessStaminaChange);
                int.TryParse(dataGrid[i][11], out activity.O1SuccessStressChange);
                int.TryParse(dataGrid[i][12], out activity.O1SuccessCashChange);
                int.TryParse(dataGrid[i][13], out activity.O1SuccessGradesChange);
                int.TryParse(dataGrid[i][14], out activity.O1SuccessCrimesChange);
                int.TryParse(dataGrid[i][15], out activity.O1SuccessTimeCost);
                int.TryParse(dataGrid[i][16], out activity.O1FailStaminaChange);
                int.TryParse(dataGrid[i][17], out activity.O1FailStressChange);
                int.TryParse(dataGrid[i][18], out activity.O1FailCashChange);
                int.TryParse(dataGrid[i][19], out activity.O1FailGradesChange);
                int.TryParse(dataGrid[i][20], out activity.O1FailCrimesChange);
                int.TryParse(dataGrid[i][21], out activity.O1FailTimeCost);
                int.TryParse(dataGrid[i][22], out activity.O2SuccessStaminaChange);
                int.TryParse(dataGrid[i][23], out activity.O2SuccessStressChange);
                int.TryParse(dataGrid[i][24], out activity.O2SuccessCashChange);
                int.TryParse(dataGrid[i][25], out activity.O2SuccessGradesChange);
                int.TryParse(dataGrid[i][26], out activity.O2SuccessCrimesChange);
                int.TryParse(dataGrid[i][27], out activity.O2SuccessTimeCost);
                int.TryParse(dataGrid[i][28], out activity.O2FailStaminaChange);
                int.TryParse(dataGrid[i][29], out activity.O2FailStressChange);
                int.TryParse(dataGrid[i][30], out activity.O2FailCashChange);
                int.TryParse(dataGrid[i][31], out activity.O2FailGradesChange);
                int.TryParse(dataGrid[i][32], out activity.O2FailCrimesChange);
                int.TryParse(dataGrid[i][33], out activity.O2FailTimeCost);
                int.TryParse(dataGrid[i][34], out activity.SkipStaminaChange);
                int.TryParse(dataGrid[i][35], out activity.SkipStressChange);
                int.TryParse(dataGrid[i][36], out activity.SkipCashChange);
                int.TryParse(dataGrid[i][37], out activity.SkipGradesChange);
                int.TryParse(dataGrid[i][38], out activity.SkipCrimesChange);
                int.TryParse(dataGrid[i][39], out activity.SkipTimeCost);

                m_activityList.Add(activity);
            }
        }
        isLoaded = true;
    }

    public void SwapActivity()//add category as a parameter to implement search algorithm
    {
        Debug.Log(m_activityList[2].Title);
        WriteInActivityFile(2);//substitute 2 with search algorithm output
    }

    public void WriteInActivityFile(int index)
    {
        m_activity.Category = m_activityList[index].Category;
        m_activity.Title = m_activityList[index].Title;
        m_activity.Timer = m_activityList[index].Timer;
        m_activity.Text = m_activityList[index].Text;
        m_activity.Option1 = m_activityList[index].Option1;
        m_activity.Option1Success = m_activityList[index].Option1Success;
        m_activity.Option1Fail = m_activityList[index].Option1Fail;
        m_activity.Option2 = m_activityList[index].Option2;
        m_activity.Option2Success = m_activityList[index].Option2Success;
        m_activity.Option2Fail = m_activityList[index].Option2Fail;

        m_activity.O1SuccessStaminaChange = m_activityList[index].O1SuccessStaminaChange;
        m_activity.O1SuccessStressChange = m_activityList[index].O1SuccessStressChange;
        m_activity.O1SuccessCashChange = m_activityList[index].O1SuccessCashChange;
        m_activity.O1SuccessGradesChange = m_activityList[index].O1SuccessGradesChange;
        m_activity.O1SuccessCrimesChange = m_activityList[index].O1SuccessCrimesChange;
        m_activity.O1SuccessTimeCost = m_activityList[index].O1SuccessTimeCost;
        m_activity.O1FailStaminaChange = m_activityList[index].O1FailStaminaChange;
        m_activity.O1FailStressChange = m_activityList[index].O1FailStressChange;
        m_activity.O1FailCashChange = m_activityList[index].O1FailCashChange;
        m_activity.O1FailGradesChange = m_activityList[index].O1FailGradesChange;
        m_activity.O1FailCrimesChange = m_activityList[index].O1FailCrimesChange;
        m_activity.O1FailTimeCost = m_activityList[index].O1FailTimeCost;
        m_activity.O2SuccessStaminaChange = m_activityList[index].O2SuccessStaminaChange;
        m_activity.O2SuccessStressChange = m_activityList[index].O2SuccessStressChange;
        m_activity.O2SuccessCashChange = m_activityList[index].O2SuccessCashChange;
        m_activity.O2SuccessGradesChange = m_activityList[index].O2SuccessGradesChange;
        m_activity.O2SuccessCrimesChange = m_activityList[index].O2SuccessCrimesChange;
        m_activity.O2SuccessTimeCost = m_activityList[index].O2SuccessTimeCost;
        m_activity.O2FailStaminaChange = m_activityList[index].O2FailStaminaChange;
        m_activity.O2FailStressChange = m_activityList[index].O2FailStressChange;
        m_activity.O2FailCashChange = m_activityList[index].O2FailCashChange;
        m_activity.O2FailGradesChange = m_activityList[index].O2FailGradesChange;
        m_activity.O2FailCrimesChange = m_activityList[index].O2FailCrimesChange;
        m_activity.O2FailTimeCost = m_activityList[index].O2FailTimeCost;
        m_activity.SkipStaminaChange = m_activityList[index].SkipStaminaChange;
        m_activity.SkipStressChange = m_activityList[index].SkipStressChange;
        m_activity.SkipCashChange = m_activityList[index].SkipCashChange;
        m_activity.SkipGradesChange = m_activityList[index].SkipGradesChange;
        m_activity.SkipCrimesChange = m_activityList[index].SkipCrimesChange;
        m_activity.SkipTimeCost = m_activityList[index].SkipTimeCost;

        //when done remove from list
        m_activityList.Remove(m_activityList[index]);
    }

    public int NumActivities()
    {
        return m_activityList.Count;
    }

    public GenericActivity GetAt(int i)
    {
        if (m_activityList.Count <= i)
            return null;
        return m_activityList[i];
    }

    public GenericActivity Find_Category(string find)
    {
        return m_activityList.Find(x => x.Category == find);
    }
    public List<GenericActivity> FindAll_Category(string find)
    {
        return m_activityList.FindAll(x => x.Category == find);
    }
    public GenericActivity Find_Title(string find)
    {
        return m_activityList.Find(x => x.Title == find);
    }
    public List<GenericActivity> FindAll_Title(string find)
    {
        return m_activityList.FindAll(x => x.Title == find);
    }
    public GenericActivity Find_Timer(string find)
    {
        return m_activityList.Find(x => x.Timer == find);
    }
    public List<GenericActivity> FindAll_Timer(string find)
    {
        return m_activityList.FindAll(x => x.Timer == find);
    }
    public GenericActivity Find_Text(string find)
    {
        return m_activityList.Find(x => x.Text == find);
    }
    public List<GenericActivity> FindAll_Text(string find)
    {
        return m_activityList.FindAll(x => x.Text == find);
    }
    public GenericActivity Find_Option1(string find)
    {
        return m_activityList.Find(x => x.Option1 == find);
    }
    public List<GenericActivity> FindAll_Option1(string find)
    {
        return m_activityList.FindAll(x => x.Option1 == find);
    }
    public GenericActivity Find_Option1success(string find)
    {
        return m_activityList.Find(x => x.Option1Success == find);
    }
    public List<GenericActivity> FindAll_Option1success(string find)
    {
        return m_activityList.FindAll(x => x.Option1Success == find);
    }
    public GenericActivity Find_Option1Fail(string find)
    {
        return m_activityList.Find(x => x.Option1Fail == find);
    }
    public List<GenericActivity> FindAll_Option1Fail(string find)
    {
        return m_activityList.FindAll(x => x.Option1Fail == find);
    }
    public GenericActivity Find_Option2(string find)
    {
        return m_activityList.Find(x => x.Option2 == find);
    }
    public List<GenericActivity> FindAll_Option2(string find)
    {
        return m_activityList.FindAll(x => x.Option2 == find);
    }
    public GenericActivity Find_Option2Success(string find)
    {
        return m_activityList.Find(x => x.Option2Success == find);
    }
    public List<GenericActivity> FindAll_Option2Success(string find)
    {
        return m_activityList.FindAll(x => x.Option2Success == find);
    }
    public GenericActivity Find_Option2Fail(string find)
    {
        return m_activityList.Find(x => x.Option2Fail == find);
    }
    public List<GenericActivity> FindAll_Option2Fail(string find)
    {
        return m_activityList.FindAll(x => x.Option2Fail == find);
    }
    public GenericActivity Find_O1SuccessStaminaChange(string find)
    {
        return m_activityList.Find(x => x.O1SuccessStaminaChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1SuccessStaminaChange(string find)
    {
        return m_activityList.FindAll(x => x.O1SuccessStaminaChange.ToString() == find);
    }
    public GenericActivity Find_O1SuccessStressChange(string find)
    {
        return m_activityList.Find(x => x.O1SuccessStressChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1SuccessStressChange(string find)
    {
        return m_activityList.FindAll(x => x.O1SuccessStressChange.ToString() == find);
    }
    public GenericActivity Find_O1SuccessCashChange(string find)
    {
        return m_activityList.Find(x => x.O1SuccessCashChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1SuccessCashChange(string find)
    {
        return m_activityList.FindAll(x => x.O1SuccessCashChange.ToString() == find);
    }
    public GenericActivity Find_O1SuccessGradesChange(string find)
    {
        return m_activityList.Find(x => x.O1SuccessGradesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1SuccessGradesChange(string find)
    {
        return m_activityList.FindAll(x => x.O1SuccessGradesChange.ToString() == find);
    }
    public GenericActivity Find_O1SuccessCrimesChange(string find)
    {
        return m_activityList.Find(x => x.O1SuccessCrimesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1SuccessCrimesChange(string find)
    {
        return m_activityList.FindAll(x => x.O1SuccessCrimesChange.ToString() == find);
    }
    public GenericActivity Find_O1SuccessTimeCost(string find)
    {
        return m_activityList.Find(x => x.O1SuccessTimeCost.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1SuccessTimeCost(string find)
    {
        return m_activityList.FindAll(x => x.O1SuccessTimeCost.ToString() == find);
    }
    public GenericActivity Find_O1FailStaminaChange(string find)
    {
        return m_activityList.Find(x => x.O1FailStaminaChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1FailStaminaChange(string find)
    {
        return m_activityList.FindAll(x => x.O1FailStaminaChange.ToString() == find);
    }
    public GenericActivity Find_O1FailStressChange(string find)
    {
        return m_activityList.Find(x => x.O1FailStressChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1FailStressChange(string find)
    {
        return m_activityList.FindAll(x => x.O1FailStressChange.ToString() == find);
    }
    public GenericActivity Find_O1FailCashChange(string find)
    {
        return m_activityList.Find(x => x.O1FailCashChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1FailCashChange(string find)
    {
        return m_activityList.FindAll(x => x.O1FailCashChange.ToString() == find);
    }
    public GenericActivity Find_O1FailGradesChange(string find)
    {
        return m_activityList.Find(x => x.O1FailGradesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1FailGradesChange(string find)
    {
        return m_activityList.FindAll(x => x.O1FailGradesChange.ToString() == find);
    }
    public GenericActivity Find_O1FailCrimesChange(string find)
    {
        return m_activityList.Find(x => x.O1FailCrimesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1FailCrimesChange(string find)
    {
        return m_activityList.FindAll(x => x.O1FailCrimesChange.ToString() == find);
    }
    public GenericActivity Find_O1FailTimeCost(string find)
    {
        return m_activityList.Find(x => x.O1FailTimeCost.ToString() == find);
    }
    public List<GenericActivity> FindAll_O1FaiTimeCost(string find)
    {
        return m_activityList.FindAll(x => x.O1FailTimeCost.ToString() == find);
    }
    public GenericActivity Find_O2SuccessStaminaChange(string find)
    {
        return m_activityList.Find(x => x.O2SuccessStaminaChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2SuccessStaminaChange(string find)
    {
        return m_activityList.FindAll(x => x.O2SuccessStaminaChange.ToString() == find);
    }
    public GenericActivity Find_O2SuccessStressChange(string find)
    {
        return m_activityList.Find(x => x.O2SuccessStressChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2SuccessStressChange(string find)
    {
        return m_activityList.FindAll(x => x.O2SuccessStressChange.ToString() == find);
    }
    public GenericActivity Find_O2SuccessCashChange(string find)
    {
        return m_activityList.Find(x => x.O2SuccessCashChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2SuccessCashChange(string find)
    {
        return m_activityList.FindAll(x => x.O2SuccessCashChange.ToString() == find);
    }
    public GenericActivity Find_O2SuccessGradesChange(string find)
    {
        return m_activityList.Find(x => x.O2SuccessGradesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2SuccessGradesChange(string find)
    {
        return m_activityList.FindAll(x => x.O2SuccessGradesChange.ToString() == find);
    }
    public GenericActivity Find_O2SuccessCrimesChange(string find)
    {
        return m_activityList.Find(x => x.O2SuccessCrimesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2SuccessCrimesChange(string find)
    {
        return m_activityList.FindAll(x => x.O2SuccessCrimesChange.ToString() == find);
    }
    public GenericActivity Find_O2SuccessTimeCost(string find)
    {
        return m_activityList.Find(x => x.O2SuccessTimeCost.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2SuccessTimeCost(string find)
    {
        return m_activityList.FindAll(x => x.O2SuccessTimeCost.ToString() == find);
    }
    public GenericActivity Find_O2FailStaminaChange(string find)
    {
        return m_activityList.Find(x => x.O2FailStaminaChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2FailStaminaChange(string find)
    {
        return m_activityList.FindAll(x => x.O2FailStaminaChange.ToString() == find);
    }
    public GenericActivity Find_O2FailStressChange(string find)
    {
        return m_activityList.Find(x => x.O2FailStressChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2FailStressChange(string find)
    {
        return m_activityList.FindAll(x => x.O2FailStressChange.ToString() == find);
    }
    public GenericActivity Find_O2FailCashChange(string find)
    {
        return m_activityList.Find(x => x.O2FailCashChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2FailCashChange(string find)
    {
        return m_activityList.FindAll(x => x.O2FailCashChange.ToString() == find);
    }
    public GenericActivity Find_O2FailGradesChange(string find)
    {
        return m_activityList.Find(x => x.O2FailGradesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2FailGradesChange(string find)
    {
        return m_activityList.FindAll(x => x.O2FailGradesChange.ToString() == find);
    }
    public GenericActivity Find_O2FailCrimesChange(string find)
    {
        return m_activityList.Find(x => x.O2FailCrimesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2FailCrimesChange(string find)
    {
        return m_activityList.FindAll(x => x.O2FailCrimesChange.ToString() == find);
    }
    public GenericActivity Find_O2FailTimeCost(string find)
    {
        return m_activityList.Find(x => x.O2FailTimeCost.ToString() == find);
    }
    public List<GenericActivity> FindAll_O2FailTimeCost(string find)
    {
        return m_activityList.FindAll(x => x.O2FailTimeCost.ToString() == find);
    }
    public GenericActivity Find_SkipStaminaChange(string find)
    {
        return m_activityList.Find(x => x.SkipStaminaChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_SkipStaminaChange(string find)
    {
        return m_activityList.FindAll(x => x.SkipStaminaChange.ToString() == find);
    }
    public GenericActivity Find_SkipStressChange(string find)
    {
        return m_activityList.Find(x => x.SkipStressChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_SkipStressChange(string find)
    {
        return m_activityList.FindAll(x => x.SkipStressChange.ToString() == find);
    }
    public GenericActivity Find_SkipCashChange(string find)
    {
        return m_activityList.Find(x => x.SkipCashChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_SkipCashChange(string find)
    {
        return m_activityList.FindAll(x => x.SkipCashChange.ToString() == find);
    }
    public GenericActivity Find_SkipGradesChange(string find)
    {
        return m_activityList.Find(x => x.SkipGradesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_SkipGradesChange(string find)
    {
        return m_activityList.FindAll(x => x.SkipGradesChange.ToString() == find);
    }
    public GenericActivity Find_SkipCrimesChange(string find)
    {
        return m_activityList.Find(x => x.SkipCrimesChange.ToString() == find);
    }
    public List<GenericActivity> FindAll_SkipCrimesChange(string find)
    {
        return m_activityList.FindAll(x => x.SkipCrimesChange.ToString() == find);
    }
    public GenericActivity Find_SkipTimeCost(string find)
    {
        return m_activityList.Find(x => x.SkipTimeCost.ToString() == find);
    }
    public List<GenericActivity> FindAll_SkipTimeCost(string find)
    {
        return m_activityList.FindAll(x => x.SkipTimeCost.ToString() == find);
    }

}

