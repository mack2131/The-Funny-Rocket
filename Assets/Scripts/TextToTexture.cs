using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToTexture : MonoBehaviour {

    public InputField consoleInput;
    public GameObject consoleScreen;
    public Texture2D fontMap;
    public Texture2D fontMap2;
    public Texture2D emptyScreen;

    private string text;
    private Material screenMat;
    private Texture2D screenTex;
    private Image newImage;
    //private int[] start = new int[600 * 800];
    struct CursorPosition
    {
        public int x;
        public int y;
    }
    CursorPosition cur;

    private KeyCode keyCode;

	// Use this for initialization
	void Start ()
    {
        screenMat = consoleScreen.GetComponent<MeshRenderer>().materials[1];
        screenTex = emptyScreen;
        cur.x = 10;
        cur.y = 600 - 10;
    }
	
	// Update is called once per frame
	void Update ()
    {
        TransformText();
        if(Input.GetKey(KeyCode.G))
            screenMat.mainTexture = emptyScreen;
    }

    void TransformText()
    {
        text = consoleInput.text;
        /*for(int i = 0; i < text.Length; i++)
        {
            switch (text[i])
            {
                case 'a':
                    {
                        Debug.Log("1");
                        Color[] letter = new Color[11*13];
                        letter = fontMap.GetPixels(0, 0, 11, 13);
                        screenTex.SetPixels(0, 600 - 13, 11, 13, letter);
                        screenTex.Apply(true);
                        break;
                    }
            }
        }*/
        
        switch (keyCode)
        {
            case KeyCode.A:
                {
                    /*Debug.Log("a");
                    keyCode = KeyCode.None;
                    Color[] letter = new Color[11 * 13];
                    letter = fontMap.GetPixels(0, 0, 11, 13);
                    screenTex.SetPixels(cur.x, cur.y - 13, 11, 13, letter);
                    MoveCursorPosition(11,13);
                    screenTex.Apply(true)*/
                    keyCode = KeyCode.None;
                    Color[] letter = new Color[17 * 21];
                    letter = fontMap2.GetPixels(1, 0, 17, 21);
                    screenTex.SetPixels(cur.x, cur.y - 21, 17, 21, letter);
                    MoveCursorPosition(17, 21);
                    screenTex.Apply(true);

                    break;
                }
        }
        Debug.Log(text);
        screenMat.mainTexture = screenTex;
    }

    void MoveCursorPosition(int letterWidth, int letterHeight)
    {
        if (cur.x + 20 < 600)
            cur.x += letterWidth + 5;
        else
        {
            cur.x = 10;
            cur.y -= 15;
        }

        if (cur.y < 0)
            cur.y = 800 - 10; 
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
            keyCode = e.keyCode;
    }
}
