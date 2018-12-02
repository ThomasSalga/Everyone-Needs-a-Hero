using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour {

    //[SerializeField]
    //GameObject m_activityGO;
    public GenericActivity m_activity;
    public GenericActivity m_universityActivity;
    public GenericActivity m_crimeActivity;
    public GenericActivity m_workActivity;
    public GenericActivity m_relaxActivity;
    public GenericActivity m_sleepActivity;
    
    List<GenericActivity> m_activityList = new List<GenericActivity>();
    List<GenericActivity> m_universityList = new List<GenericActivity>();
    List<GenericActivity> m_heroicList = new List<GenericActivity>();
    List<GenericActivity> m_workList = new List<GenericActivity>();
    List<GenericActivity> m_relaxList = new List<GenericActivity>();
    List<GenericActivity> m_sleepList = new List<GenericActivity>();

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
        WriteInActivityFile(m_activity, m_activityList, 0); //just to get rid of it
        WriteInActivityFile(m_activity, m_activityList, 1); //just to get rid of it
        //WriteInActivityFile(2);
        //m_activity.Category = "asd";
        //spawn 
    }

    public void Load(TextAsset csv)
    {
        m_activityList.Clear();
        string[][] dataGrid = CsvParser.Parse(csv.text);
        for (int i = 0; i < dataGrid.Length; i++)
        {
            Debug.Log("ID = " + i.ToString());

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

        m_universityList.Clear();
        m_heroicList.Clear();
        m_workList.Clear();
        m_relaxList.Clear();
        m_sleepList.Clear();

        m_universityList = FindAll_Category("Uni");
        m_heroicList = FindAll_Category("Crime");
        m_workList = FindAll_Category("Work");
        m_relaxList = FindAll_Category("Relax");
        m_sleepList = FindAll_Category("Sleep");

        isLoaded = true;
    }

    public void SwapActivity(GenericActivity dataToUpdate)//add category as a parameter to implement search algorithm
    {
        switch(dataToUpdate.Category)
        {
            case "Uni":
                if (m_universityList.Count >= 1)
                    WriteInActivityFile(dataToUpdate, m_universityList, 0);
                else
                {
                    WriteInActivityFile(dataToUpdate);
                    Debug.Log("Uni list is empty");
                }break;
            case "Crime":
                if (m_heroicList.Count >= 1)
                    WriteInActivityFile(dataToUpdate, m_heroicList, 0);
                else
                {
                    WriteInActivityFile(dataToUpdate);
                    Debug.Log("Crime list is empty");
                }break;
            case "Work":
                if (m_workList.Count >= 1)
                    WriteInActivityFile(dataToUpdate, m_workList, 0);
                else
                {
                    WriteInActivityFile(dataToUpdate);
                    Debug.Log("Work list is empty");
                }
                break;
            case "Relax":
                if (m_relaxList.Count >= 1)
                    WriteInActivityFile(dataToUpdate, m_relaxList, 0);
                else
                {
                    WriteInActivityFile(dataToUpdate);
                    Debug.Log("Relax list is empty");
                }
                break;
            case "Sleep":
                if (m_sleepList.Count >= 1)
                    WriteInActivityFile(dataToUpdate, m_sleepList, 0);
                else
                {
                    WriteInActivityFile(dataToUpdate);
                    Debug.Log("Sleep list is empty");
                }
                break;
        }
        //WriteInActivityFile(dataToUpdate, fromThisList, 2);//substitute 2 with search algorithm output
    }

    public void WriteInActivityFile(GenericActivity activity, List<GenericActivity> list, int index)
    {
        activity.Category = list[index].Category;
        activity.Title = list[index].Title;
        activity.Timer = list[index].Timer;
        activity.Text = list[index].Text;
        activity.Option1 = list[index].Option1;
        activity.Option1Success = list[index].Option1Success;
        activity.Option1Fail = list[index].Option1Fail;
        activity.Option2 = list[index].Option2;
        activity.Option2Success = list[index].Option2Success;
        activity.Option2Fail = list[index].Option2Fail;

        activity.O1SuccessStaminaChange = list[index].O1SuccessStaminaChange;
        activity.O1SuccessStressChange = list[index].O1SuccessStressChange;
        activity.O1SuccessCashChange = list[index].O1SuccessCashChange;
        activity.O1SuccessGradesChange = list[index].O1SuccessGradesChange;
        activity.O1SuccessCrimesChange = list[index].O1SuccessCrimesChange;
        activity.O1SuccessTimeCost = list[index].O1SuccessTimeCost;
        activity.O1FailStaminaChange = list[index].O1FailStaminaChange;
        activity.O1FailStressChange = list[index].O1FailStressChange;
        activity.O1FailCashChange = list[index].O1FailCashChange;
        activity.O1FailGradesChange = list[index].O1FailGradesChange;
        activity.O1FailCrimesChange = list[index].O1FailCrimesChange;
        activity.O1FailTimeCost = list[index].O1FailTimeCost;
        activity.O2SuccessStaminaChange = list[index].O2SuccessStaminaChange;
        activity.O2SuccessStressChange = list[index].O2SuccessStressChange;
        activity.O2SuccessCashChange = list[index].O2SuccessCashChange;
        activity.O2SuccessGradesChange = list[index].O2SuccessGradesChange;
        activity.O2SuccessCrimesChange = list[index].O2SuccessCrimesChange;
        activity.O2SuccessTimeCost = list[index].O2SuccessTimeCost;
        activity.O2FailStaminaChange = list[index].O2FailStaminaChange;
        activity.O2FailStressChange = list[index].O2FailStressChange;
        activity.O2FailCashChange = list[index].O2FailCashChange;
        activity.O2FailGradesChange = list[index].O2FailGradesChange;
        activity.O2FailCrimesChange = list[index].O2FailCrimesChange;
        activity.O2FailTimeCost = list[index].O2FailTimeCost;
        activity.SkipStaminaChange = list[index].SkipStaminaChange;
        activity.SkipStressChange = list[index].SkipStressChange;
        activity.SkipCashChange = list[index].SkipCashChange;
        activity.SkipGradesChange = list[index].SkipGradesChange;
        activity.SkipCrimesChange = list[index].SkipCrimesChange;
        activity.SkipTimeCost = list[index].SkipTimeCost;

        //when done remove from list
        list.Remove(list[index]);
    }

    public void WriteInActivityFile(GenericActivity activity)
    {
        //activity.Category = null;
        activity.Title = "Nothing to do";
        activity.Timer = null;
        activity.Text = null;
        activity.Option1 = null;
        activity.Option1Success = null;
        activity.Option1Fail = null;
        activity.Option2 = null;
        activity.Option2Success = null;
        activity.Option2Fail = null;

        activity.O1SuccessStaminaChange = 0;
        activity.O1SuccessStressChange = 0;
        activity.O1SuccessCashChange = 0;
        activity.O1SuccessGradesChange = 0;
        activity.O1SuccessCrimesChange = 0;
        activity.O1SuccessTimeCost = 0;
        activity.O1FailStaminaChange = 0;
        activity.O1FailStressChange = 0;
        activity.O1FailCashChange = 0;
        activity.O1FailGradesChange = 0;
        activity.O1FailCrimesChange = 0;
        activity.O1FailTimeCost = 0;
        activity.O2SuccessStaminaChange = 0;
        activity.O2SuccessStressChange = 0;
        activity.O2SuccessCashChange = 0;
        activity.O2SuccessGradesChange = 0;
        activity.O2SuccessCrimesChange = 0;
        activity.O2SuccessTimeCost = 0;
        activity.O2FailStaminaChange = 0;
        activity.O2FailStressChange = 0;
        activity.O2FailCashChange = 0;
        activity.O2FailGradesChange = 0;
        activity.O2FailCrimesChange = 0;
        activity.O2FailTimeCost = 0;
        activity.SkipStaminaChange = 0;
        activity.SkipStressChange = 0;
        activity.SkipCashChange = 0;
        activity.SkipGradesChange = 0; 
        activity.SkipCrimesChange = 0;
        activity.SkipTimeCost = 0;
    }

    #region Search Functions
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
    #endregion
}

