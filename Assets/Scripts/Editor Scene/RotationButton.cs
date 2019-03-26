using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class RotationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    //directions:
    // 0 - left
    // 1 - right
    public int direction;
    public GameObject editorManager;

    private bool can;
    private bool handled;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(Rotate);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Rotate()
    {
        switch (direction)
        {
            case 0:
                {
                    if (can && handled)
                        editorManager.GetComponent<EditorManager>().rocket.transform.Rotate(editorManager.GetComponent<EditorManager>().rocket.transform.up * Time.deltaTime);
                    break;
                }
            case 1:
                {
                    if (can && handled)
                        editorManager.GetComponent<EditorManager>().rocket.transform.Rotate(-editorManager.GetComponent<EditorManager>().rocket.transform.up * Time.deltaTime);
                    break;
                }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        handled = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handled = false;
    }
}
