using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRocketScript : MonoBehaviour {

    public GameObject editorManager;
    //public GameObject rocket;
    public Transform editorCenter;
    public Transform editorCanvas;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Button>().onClick.AddListener(New);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Active();	
	}

    void New()
    {
        editorManager.GetComponent<EditorManager>().rocket = new GameObject();
        //rocket = new GameObject();
        editorManager.GetComponent<EditorManager>().rocket.transform.SetParent(editorCanvas);
        editorManager.GetComponent<EditorManager>().rocket.transform.position = editorCenter.position;
        editorManager.GetComponent<EditorManager>().rocket.name = "New Rocket";
        //editorManager.GetComponent<EditorManager>().rocket = rocket;
    }

    void Active()
    {
        if (editorManager.GetComponent<EditorManager>().rocket != null)
            GetComponent<Button>().interactable = false;
        else GetComponent<Button>().interactable = true;
    }
}
