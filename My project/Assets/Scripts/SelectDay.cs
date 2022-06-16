using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectDay : MonoBehaviour
{
    public int days;

    public PlayFabSelect fabSelect;

    public Button Button2, Button3, Button4;

    private void Start()
    {
        Debug.Log(days);

        /*if (days < 2 && days != 0)
        {
            Button2.image.color = new Color(0.6f, 0.27f, 0.15f);
        }

        if (days < 3 && days != 0)
        {
            Button3.image.color = new Color(0.6f, 0.27f, 0.15f);
        }

        if (days < 4 && days != 0)
        {
            Button4.image.color = new Color(0.6f, 0.27f, 0.15f);
        }*/
    }

    private void Update()
    {
        
    }

    public void Day1()
    {
        SceneManager.LoadScene("Day 1 - Bus");
    }

    public void Day2()
    {
        if(days>1)
            SceneManager.LoadScene("Day 2 - Cafe");
    }
    
    public void Day3()
    {
        if(days>2)
            SceneManager.LoadScene("Day 3 - Library");
    }

    public void Day4()
    {
        if(days>3)
            SceneManager.LoadScene("Day 4 - Hospital");
    }

    public void GetIntDays(int savedDays)
    {
        days = savedDays;

        
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("days", days);
    }

    void OnEnable()
    {
        days = PlayerPrefs.GetInt("days");
    }
}
