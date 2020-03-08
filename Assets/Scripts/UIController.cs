using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public static class UIController
{
    private static Text m_HighScore;
    private static Image[] m_Hearts;

    private static int m_Score = 0;


    // Start is called before the first frame update
    static UIController()
    {
        m_HighScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
        m_Hearts = GameObject.FindGameObjectWithTag("HeartContainer").GetComponentsInChildren<Image>();
    }

    public static void AddScore(int score)
    {
        m_Score += score;
        m_HighScore.text = m_Score.ToString("D8");
    }

    public static void UpdateHealth(int health)
    {
        switch (health)
        {
            case 3:
                m_Hearts[0].enabled = true;
                m_Hearts[1].enabled = true;
                m_Hearts[2].enabled = true;
                break;
            case 2:
                m_Hearts[0].enabled = true;
                m_Hearts[1].enabled = true;
                m_Hearts[2].enabled = false;
                break;
            case 1:
                m_Hearts[0].enabled = true;
                m_Hearts[1].enabled = false;
                m_Hearts[2].enabled = false;
                break;
            case 0:
                m_Hearts[0].enabled = false;
                m_Hearts[1].enabled = false;
                m_Hearts[2].enabled = false;
                break;
                

        }
    }


}
