using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reading : MonoBehaviour
{
    private int page = 1;
    private int totalPages = 4;
    private Text pages;
    // Start is called before the first frame update
    void Start()
    {
        pages = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pages.text = page + "/4"; 

    }
}
