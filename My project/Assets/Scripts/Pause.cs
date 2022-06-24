using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class Pause : MonoBehaviour
{

    public GameObject statisticsGroup, guideGroup;
    public PlayFabLeaderboard fabLeader;
    public Text playersList, playersRead, playersComp, correctList, correctRead, correctComp;

    private void Awake()
    {
        fabLeader.GetLeaderBoardListening();
        GetAnswers();
        playersList.text = fabLeader.percList.ToString() + "%";
        correctList.text = fabLeader.correctList.ToString();

        fabLeader.GetLeaderBoardReading();
        playersRead.text = fabLeader.percRead.ToString() + "%";
        correctRead.text = fabLeader.correctRead.ToString();

        fabLeader.GetLeaderBoardComplete();
        playersComp.text = fabLeader.percComp.ToString() + "%";
        correctComp.text = fabLeader.correctComp.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Guide()
    {
        guideGroup.SetActive(true);

    }

    public void Statistics()
    {

        statisticsGroup.SetActive(true);


        playersList.text = fabLeader.percList.ToString() + "%";
        //correctList.text = fabLeader.correctList.ToString();

        playersRead.text = fabLeader.percRead.ToString() + "%";
        //correctRead.text = fabLeader.correctRead.ToString();

        playersComp.text = fabLeader.percComp.ToString() + "%";
        //correctComp.text = fabLeader.correctComp.ToString();

    }

    public void Return()
    {
        gameObject.SetActive(false);
    }

    public void ReturnStatistics()
    {
        statisticsGroup.SetActive(false);
    }

    public void ReturnGuide()
    {
        guideGroup.SetActive(false);
    }

    public void GetAnswers()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);

    }

    void OnDataRecieved(GetUserDataResult result)
    {
        Debug.Log("Recieved user data.");
        if (result.Data != null && (result.Data.ContainsKey("CorrectAnswersListening") || result.Data.ContainsKey("CorrectAnswersReading") || result.Data.ContainsKey("CorrectAnswersComplete")))
        {
            correctList.text = result.Data["CorrectAnswersListening"].Value;
            correctRead.text = result.Data["CorrectAnswersReading"].Value;
            correctComp.text = result.Data["CorrectAnswersComplete"].Value;
        }

        else
        {
            Debug.Log("Player data not complete.");
        }

    }

    public void OnError(PlayFabError error)
    {
        Debug.Log("OnERROR");
    }
}
