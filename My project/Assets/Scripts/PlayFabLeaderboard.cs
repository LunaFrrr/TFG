using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLeaderboard : MonoBehaviour
{

    public int percList;
    public int percRead;
    public int percComp;

    public int correctList, correctRead, correctComp;

    public Text errorLeader;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendLeaderboardReading(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate{

                    StatisticName = "CorrectAnswersReading",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, LeaderError);
    }

    public void SendLeaderboardListening(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate{

                    StatisticName = "CorrectAnswersListening",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, LeaderError);
    }

    public void SendLeaderboardComplete(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate{

                    StatisticName = "CorrectAnswersComplete",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, LeaderError);
    }


    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Succesfull leaderboard sent");
    }

    public void GetLeaderBoardReading()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "CorrectAnswersReading",
            StartPosition = 0
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardReadingGet, LeaderError);
    }

    public void GetLeaderBoardListening()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "CorrectAnswersListening",
            StartPosition = 0
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardListeningGet, LeaderError);
    }

    public void GetLeaderBoardComplete()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "CorrectAnswersComplete",
            StartPosition = 0,
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardCompleteGet, LeaderError);
    }

    void OnLeaderboardReadingGet(GetLeaderboardResult result)
    {
        int winners = 0;
        int players = 0;
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + "" + item.PlayFabId + "" + item.StatValue);
            if (item.StatValue == 4)
                winners++;

            players++;
        }

        percRead = winners * 100 / players;
        Debug.Log("Porcentaje aciertos: " + winners * 100 / players);
    }

    void OnLeaderboardListeningGet(GetLeaderboardResult result)
    {
        int winners = 0;
        int players = 0;
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + "" + item.PlayFabId + "" + item.StatValue);
            if (item.StatValue == 10)
                winners++;

            players++;
        }

        percList = winners * 100 / players;
        Debug.Log("Porcentaje aciertos: " + winners * 100 / players);
    }

    void OnLeaderboardCompleteGet(GetLeaderboardResult result)
    {
        int winners = 0;
        int players = 0;
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + "" + item.PlayFabId + "" + item.StatValue);
            if (item.StatValue == 5)
                winners++;

            players++;
        }

        percComp = winners * 100 / players;
        Debug.Log("Porcentaje aciertos: " + winners * 100 / players);

    }

    public void LeaderError(PlayFabError error)
    {
        errorLeader.text = error.GenerateErrorReport();
    }

}
