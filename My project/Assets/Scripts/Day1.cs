using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Day1 : MonoBehaviour
{
   


    public void NextDay()
    {
        SceneManager.LoadScene("Day 2 - Cafe");
    }


}
