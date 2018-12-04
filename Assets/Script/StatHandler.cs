using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour {

    private int stress = 0; // scale: 0-infinity, less is better
    private int money = 150; // scale: -infinity-infinty, more is better
    private int grade = 100; // scale: 0-100%, more is better
    private int crime = 50; // scale 0-infinty, less is better
    private int stamina = 100; // 0-100, more is better

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Stress

    public int GetStress() {
        return stress;
    }

    public void SetStress(int stressChange) {
        if (stress + stressChange >= 0)
        {
            stress += stressChange;
        }
        else
        {
            stress = 0;
        }
    }

    //Money

    public int GetMoney() {
        return money;
    }

    public void SetMoney(int moneyChange) {
        money += moneyChange;
        //You can go into debt indefinitely - needs a later fix maybe someday eventually
    }

    //Grade

    public int GetGrade() {
        return grade;
    }

    public void SetGrade(int gradeChange) {
        if ((grade + gradeChange) >=0)
        {
            if (grade + gradeChange<=100)
            {
                grade += gradeChange;
            }
            else
            {
                grade = 100;
            }
        }
        else
        {
            grade = 0;
        }
    }

    //crime

    public int GetCrime() {
        return crime;
    }

    public void SetCrime(int crimeChange) {
        if (crime+crimeChange >=0)
        {
            crime += crimeChange;
        }
        else
        {
            crime = 0;
        }
    }

    //stamina

    public int GetStamina() {
        return stamina;
    }

    public void SetStamina(int staminaChange) {
        if (stamina + staminaChange >=0)
        {
            if (stamina + staminaChange <=100)
            {
                stamina += staminaChange;
            }
            else
            {
                stamina = 100;
            }
        }
        else
        {
            SetStress(-(stamina + staminaChange));
            stamina = 0;
        }
    }
}
