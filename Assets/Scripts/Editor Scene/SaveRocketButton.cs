using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveRocketButton : MonoBehaviour {

    public GameObject editorManager;
    public InputField rocketName;

    private bool hasName;
    private bool isRocket;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Button>().onClick.AddListener(Save);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Check();

        if (!CanSave())
            GetComponent<Button>().interactable = false;
        else GetComponent<Button>().interactable = true;
    }

    bool CanSave()
    {
        if (!hasName || !isRocket)
            return false;
        else return true;
    }

    void Save()
    {

    }

    void Check()
    {
        if (rocketName.text.Length != 0)
            hasName = true;

        if (editorManager.GetComponent<EditorManager>().rocket != null)
            isRocket = true;
    }
}
