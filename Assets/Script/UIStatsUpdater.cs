using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatsUpdater : MonoBehaviour {

    [SerializeField] Image m_stressFiller;
    [SerializeField] Image m_crimeFiller;
    [SerializeField] Image m_staminaFiller;
    [SerializeField] Text m_moneyText;
    [SerializeField] Text m_gradeText;

    [SerializeField] StatHandler m_player;

    // Update is called once per frame
    void FixedUpdate ()
    {
        m_stressFiller.fillAmount = m_player.GetStress() / 300.00f;
        m_crimeFiller.fillAmount = m_player.GetCrime() / 300.00f;
        m_staminaFiller.fillAmount = m_player.GetStamina() / 100.00f;

        m_moneyText.text = m_player.GetMoney().ToString() + " £";
        m_gradeText.text = m_player.GetGrade().ToString() + " %";
    }
}
