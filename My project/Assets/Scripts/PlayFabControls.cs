using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabControls : MonoBehaviour
{
    [SerializeField] GameObject signUpTab, loginTab, startPanel, HUD;
    public Text userName, userEmail, userPassword, userEmailLogin, userPasswordLogin, errorSignUp, errorLogin;
    string encryptedPassword;

    public void SwitchToSignUpTab()
    {
        signUpTab.SetActive(true);
        loginTab.SetActive(false);
        errorSignUp.text = "";
        errorLogin.text = "";
    }

    public void SwitchToLoginTab()
    {
        signUpTab.SetActive(false);
        loginTab.SetActive(true);
        errorSignUp.text = "";
        errorLogin.text = "";
    }

    string Encrypt(string password)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(password);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();

        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }

        return s.ToString();
    }

    public void SignUp()
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail.text, Password = Encrypt(userPassword.text), Username = userName.text };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterSuccess, RegisterError);
    }

    public void RegisterSuccess(RegisterPlayFabUserResult result)
    {
        errorSignUp.text = "";
        errorLogin.text = "";
        StartGame();
    }

    public void LoginSuccess(LoginResult result)
    {
        errorSignUp.text = "";
        errorLogin.text = "";
        StartGame();
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin.text, Password = Encrypt(userPasswordLogin.text) };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, LoginError);
    } 
     
    public void RegisterError(PlayFabError error)
    {
        errorSignUp.text = error.GenerateErrorReport();
    }

    public void LoginError(PlayFabError error)
    {
        errorLogin.text = error.GenerateErrorReport();
    }

    void StartGame()
    {
        startPanel.SetActive(false);
        HUD.SetActive(true);

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
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, LoginError);
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
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, LoginError);
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
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, LoginError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        int winners = 0;
        int players = 0;
        foreach(var item in result.Leaderboard)
        {
            Debug.Log(item.Position + "" + item.PlayFabId + "" + item.StatValue);
            if (item.StatValue == 4)
                winners++;

            players++;
        }

        Debug.Log("Porcentaje aciertos: " + winners * 100 / players); 
    }
}

