using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabSelect : MonoBehaviour
{
    public SelectDay selectDay;
    // Start is called before the first frame update
    void Start()
    {
        GetDays();
        Debug.Log("desde fab" + selectDay.days);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDays()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
        
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        Debug.Log("Recieved user data.");
        if (result.Data != null && result.Data.ContainsKey("Days"))
        {
            selectDay.GetIntDays(int.Parse(result.Data["Days"].Value));
        }

        else
        {
            Debug.Log("Player data not complete.");
            selectDay.days = 1;
        }
            
    }

    public void SaveDays()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Days", selectDay.days.ToString() },
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Succesfull user data send!");
    }

    public void OnError(PlayFabError error)
    {
        Debug.Log("OnERROR");
    }
}
