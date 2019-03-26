using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToTerminalScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(ReturnToTerminal);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void ReturnToTerminal()
    {
        SceneManager.LoadScene("Terminal");
    }
}
