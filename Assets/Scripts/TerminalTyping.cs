using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalTyping : MonoBehaviour {

    public Text consoleText;
    public Scrollbar scrollbar;
    public InputField console;

    public string command;
    [HideInInspector ]
    public string allText;
    public bool commandExecuting;

    private KeyCode keyCode;

    private float loadingCounter;
    private int loadingStringIndex;
    private bool terminalLoaded;

	// Use this for initialization
	void Start ()
    {
        terminalLoaded = false;
        allText = " ";
        loadingStringIndex = 0;
        commandExecuting = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*if (keyCode != KeyCode.None && terminalLoaded)
            Typing();
        else if (!terminalLoaded)
            FunLoading();*/

        if(!commandExecuting)
            console.ActivateInputField();

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            commandExecuting = true;
            command = console.text;
            allText += command + "\n";
            console.text = "";
            GetComponent<ConsoleCommand>().IdentCommand(command);
            command = "";
            consoleText.text = allText;
        }
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
            keyCode = e.keyCode;
        //Debug.Log(keyCode);
    }

    void FunLoading()
    {
        /* CURE - Coyote uses r..... e.....????? */
        /* WCD - White Coyote OS */
        string myString = "$$$$$CURE TERMINAL STATION$$$$$" + "\n" + "TESTING SOFTWARE...ok" + "\n" + "TESTING HARDWARE...ok" + "\n" + "TESTING NETWORK...ok" + "\n" + "RUNNING WC OS...ok" + "\n" + "OS STARTED SUCCESSFULLY...ok" + "\n" + "TYPE \"HELP\" IN ORDER TO GET COMMAND LIST\n";
        loadingCounter += Time.deltaTime;
        if(loadingCounter >= 0.03)
        {
            loadingCounter = 0;
            if (loadingStringIndex > myString.Length - 1)
                terminalLoaded = true;
            else
            {
                allText += myString[loadingStringIndex];
                consoleText.text = allText;
                loadingStringIndex++;
            }
        }

    }

    void Typing()
    {
        switch (keyCode)
        {
            case KeyCode.A :
                {
                    command += "a";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.B:
                {
                    command += "b";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.C:
                {
                    command += "c";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.D:
                {
                    command += "d";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.E:
                {
                    command += "e";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.F:
                {
                    command += "f";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.G:
                {
                    command += "g";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.H:
                {
                    command += "h";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.I:
                {
                    command += "i";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.J:
                {
                    command += "j";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.K:
                {
                    command += "k";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.L:
                {
                    command += "l";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.M:
                {
                    command += "m";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.N:
                {
                    command += "n";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.O:
                {
                    command += "o";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.P:
                {
                    command += "p";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Q:
                {
                    command += "q";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.R:
                {
                    command += "r";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.S:
                {
                    command += "s";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.T:
                {
                    command += "t";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.U:
                {
                    command += "u";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.V:
                {
                    command += "v";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.W:
                {
                    command += "w";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.X:
                {
                    command += "x";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Y:
                {
                    command += "y";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Z:
                {
                    command += "z";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha0:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += ")";
                    else command += "0";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha1:
                {
                    if (Input.GetKey(KeyCode.LeftShift)  || Input.GetKey(KeyCode.RightShift))
                        command += "!";
                    else command += "1";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha2:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "@";
                    else command += "2";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha3:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "#";
                    else command += "3";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha4:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "$";
                    else command += "4";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha5:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "%";
                    else command += "5";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha6:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "^";
                    else command += "6";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha7:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "&";
                    else command += "7";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha8:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "*";
                    else command += "8";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Alpha9:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "(";
                    else command += "9";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad0:
                {
                    command += "0";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad1:
                {
                    command += "1";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad2:
                {
                    command += "2";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad3:
                {
                    command += "3";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad4:
                {
                    command += "4";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad5:
                {
                    command += "5";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad6:
                {
                    command += "6";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad7:
                {
                    command += "7";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad8:
                {
                    command += "8";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Keypad9:
                {
                    command += "9";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.KeypadDivide:
                {
                    command += "/";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.KeypadMinus:
                {
                    command += "-";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.KeypadPeriod:
                {
                    command += ",";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.KeypadMultiply:
                {
                    command += "*";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.KeypadPlus:
                {
                    command += "+";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Comma:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "<";
                    else command += ",";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Minus:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "_";
                    else command += "-";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Period:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += ">";
                    else command += ".";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Slash:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "?";
                    else command += "/";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Backslash:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "|";
                    else command += "\\";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Semicolon:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += ":";
                    else command += ";";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Equals:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "+";
                    else command += "=";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Quote:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "\"";
                    else command += "'";
                    keyCode = KeyCode.None;
                    break;
                }
                case KeyCode.BackQuote:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "~";
                    else command += "`";
                    keyCode = KeyCode.None;
                    break;
                }
                case KeyCode.LeftBracket:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "{";
                    else command += "[";
                    keyCode = KeyCode.None;
                    break;
                }
                case KeyCode.RightBracket:
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        command += "}";
                    else command += "]";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Backspace :
                {
                    /*if (allText.Length > 0)
                        allText = allText.Remove(allText.Length - 1);*/
                    if (command.Length > 0)
                        command = command.Remove(command.Length - 1);
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Space :
                {
                    command += " ";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.KeypadEnter:
                {
                    allText += command;
                    allText += "\n";
                    GetComponent<ConsoleCommand>().IdentCommand(command);
                    command = "";
                    keyCode = KeyCode.None;
                    break;
                }
            case KeyCode.Return:
                {
                    /*command += "\n";
                    waitingForCommand = false;
                    GetComponent<ConsoleCommand>().IdentCommand(command);
                    command = "";
                    keyCode = KeyCode.None;
                    break;*/

                    allText += command;
                    allText += "\n";
                    GetComponent<ConsoleCommand>().IdentCommand(command);
                    command = "";
                    keyCode = KeyCode.None;
                    break;
                }
            default:
                {
                    keyCode = KeyCode.None;
                    break;
                }
        }

        consoleText.text = allText + command;
    }
}
