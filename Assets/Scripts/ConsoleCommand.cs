using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsoleCommand : MonoBehaviour {

    public GameObject cityStorage;
    public GameObject[] rockets;

    public GameObject launchPlace;

    private GameObject destinationCity;

    private int index;
    private string cityName = "";
    /*&&&&&&*/private string defaultRocket = "def";/*%%%%%*/
    private string rocketName = "";

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void IdentCommand(string command)
    {
        string newCommand = "";
        cityName = "";
        rocketName = "";
        //понимаем, какое первое слово у команды
        for (index = 0; index < command.Length; index++)
        {
            if (command[index] != ' ')
                newCommand += command[index];
            else break;
        }
        //по первому слову понимаем, какая команда перед нами
        switch (newCommand)
        {
            case "attack"://запуск рокет
                {
                    bool cityExist = false;//пока города не существует

                    //берем имя города, оно идет после слова attack
                    for (int i = index + 1; i < command.Length; i++)
                    {
                        if (command[i] != ' ')
                        {
                            cityName += command[i];
                            index++;
                        }
                        else break;
                    }

                    for(int i = 0; i < cityStorage.transform.childCount; i++)//смотрим, если город с таким именем
                    {
                        if (cityName == cityStorage.transform.GetChild(i).name)//если есть
                        {
                            destinationCity = cityStorage.transform.GetChild(i).gameObject;
                            cityExist = true;//говорим, что город существет
                        }
                    }
                    //если город существует
                    if (cityExist)
                    {
                        for (int i = index + 2; i < command.Length; i++)//берем имя ракеты
                        {
                            if (command[i] != ' ')
                            {
                                rocketName += command[i];
                                index++;
                            }
                            else break;
                        }
                        //если есть такая ракета
                        if(rocketName == defaultRocket)
                        {
                            if (command.Length > index + 2)//после имени ракеты есть еще что-то
                            {
                                Error(command, true, false, false);
                            }
                            else
                            {
                                GameObject rocket = Instantiate(rockets[0], cityStorage.transform);
                                rocket.GetComponent<Rocket>().laucnhPoint = launchPlace.transform;
                                rocket.GetComponent<Rocket>().destinationPoint = destinationCity.transform;
                            }
                        }
                        else//если нет ракеты, то ошибка
                        {
                            Error(command, false, false, true);
                        }
                    }
                    else//если нет
                    {
                        Error(command, false, true, false);//то ошибка
                    }
                    break;
                }
            case "3d-printer"://редактор ракет
                {
                    if(command.Length > 10)
                        Error(command, true, false, false);//много аргументов
                    else
                    {
                        SceneManager.LoadScene("Editor");
                    }
                    break;
                }
            case "exit"://выход из игры
                {
                    //exit application
                    string app = "application";
                    string param = "";
                    for(index = 5; index < command.Length; index++)
                    {
                        if (command[index] != ' ')
                            param += command[index];
                        else break;
                    }
                    if (param == app && command.Length == 16)
                        Application.Quit();
                    else
                    {
                        Error(command, true, false, false);//много аргументов
                        break;
                    }
                    break;
                }
            case "brexit"://выход из игры
                {
                    //exit application
                    string app = "application";
                    string param = "";
                    for (index = 5; index < command.Length; index++)
                    {
                        if (command[index] != ' ')
                            param += command[index];
                        else break;
                    }
                    if (param == app && command.Length == 16)
                        Application.Quit();
                    else
                    {
                        Error(command, true, false, false);//много аргументов
                        break;
                    }
                    break;
                }
            default:
                {
                    Error(command, false, false, false);//вообще нет такой команды
                    break;
                }
        }
        GetComponent<TerminalTyping>().commandExecuting = false;
    }

    //функция вывода сообщения об ошибке
    void Error(string command, bool tooMuchArguments, bool noCity, bool noRocket)
    {
        GetComponent<TerminalTyping>().allText += "- unknow command: " + command + "\n";
        if(tooMuchArguments)//если есть каие-то лишние слова
            GetComponent<TerminalTyping>().allText += "- ooops...too much words: " + cityName + "\n";
        if (noCity)//если нет города с таким названием
            GetComponent<TerminalTyping>().allText += "- there is no city: " + cityName + "\n";
        if(noRocket)//если нет ракеты с таким названием
            GetComponent<TerminalTyping>().allText += "- there is no rocket: " + rocketName + "\n";
    }
}
