using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDragging;
    private bool collisionWord;
    private Vector2 initPos;

    public GameObject gap;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }


    }

    //Mouse down in the UI
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Entra en OnPointerDown");
        isDragging = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        Debug.Log("Entra en OnPointerUp");

        if (collisionWord)
        {
            Debug.Log("Entra en el if de OnPointerUp");
            transform.position = gap.transform.position;
        }

        else
            transform.position = initPos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.CompareTag("Gap"))
        {
            collisionWord = true;
        }

        if (other.collider.CompareTag("Word"))
        {
            transform.position = initPos;
        }
    }



}
