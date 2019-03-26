using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyRocketButton : MonoBehaviour {

    public GameObject editorManager;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(Destroy);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Active();
	}

    void Destroy()
    {
        if(editorManager.GetComponent<EditorManager>().rocket != null)
        {
            Destroy(editorManager.GetComponent<EditorManager>().rocket.gameObject);
            editorManager.GetComponent<EditorManager>().rocket = null;
        }
    }

    void Active()
    {
        if (editorManager.GetComponent<EditorManager>().rocket != null)
            GetComponent<Button>().interactable = true;
        else GetComponent<Button>().interactable = false;
    }
}
