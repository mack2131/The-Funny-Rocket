using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotationgPlanet : MonoBehaviour,IPointerDownHandler, IPointerUpHandler{

    public GameObject planet;//планета
    //направление - т.к. на кнопки поворотов планеты и ее приближения вешается один скрипт (этот), то направления имеют кодовые значения 
    // 0 - вращение планеты в лево не по оси
    // 1 - вращение планеты в право не по оси
    // 2 - вращение планеты не по оси назад (к нам)
    // 3 - вращение планеты не по оси от вперед (от нас)
    // 4 - сброс поворотов планеты к исходному
    // 5 - поворот планеты вокруг своей оси на лево
    // 6 - поворот планеты вокруг своей оси на право
    // 7 - приближение земли
    // 8 - отдаление земли
    public int direction;

    private bool holded;//зажата ли кнопка
    
    private Quaternion defaultRotation;//стартовое вращение планеты

    [HideInInspector]
    public bool zooming;//планета в данный момент приближается или отдоляется
    private bool zoomed;//нажималась кнопка приближения/отдаления
	
    void Start()
    {

        if (direction == 4)/* если эта кнопка имеет код 4 - сброс вращения */
        {
            GetComponent<Button>().onClick.AddListener(ResetTransformPlanet);//ждем, когда на нее нажмут, чтобы вызвать функцию ResetTransformPlanet
            defaultRotation = planet.transform.rotation;//запоминаем стартовое вращение планеты
        }
        else if (direction == 7)/* если кнопка имеет код 7 - приблизить планету */
            GetComponent<Button>().onClick.AddListener(ZoomButton);//ждем функцию нажатия на кнопку
        else if (direction == 8)/* если кнопка имеет код 8 - отдалить планету */
            GetComponent<Button>().onClick.AddListener(ZoomButton);//ждем функцию нажатия на кнопку
    }

	// Update is called once per frame
	void Update ()
    {
        if (holded && direction != 4)//если зажата кнопка и это не кнопка с кодом 4 - сброс вращения планеты
            RotatePlanet();//функция поворота планеты

        if (zoomed && direction == 7)//если код кнопки 7 - приблизить планету и кнопка нажалась
            Zoom();//вызываем функцию приближения планеты
        else if (zoomed && direction == 8)//если код кнопки 8 - отдалить планету и кнопка нажалась
            UnZoom();//вызываем функцию отдаления
	}

    public void OnPointerDown(PointerEventData eventData)//мышь нажата на кнопке
    {
        holded = true;//значит кнопка зажимается в данный момент
    }

    public void OnPointerUp(PointerEventData eventData)//отпустили мышь на кнопке
    {
        holded = false;//кнопка больше не зажиматся
    }

    void ResetTransformPlanet()//возвращение вращения земли к исходному состоянию
    {
        planet.transform.rotation = defaultRotation;//ставим начальное вращение
    }

    void ZoomButton()//функция нажатия на кнопки приблизить/отдалить
    {
        if(!zooming)//если планеты в данный момент не приближается/отдаляется
            zoomed = true;//говорим, что можно приближать/отдалять

        zooming = true;//говорим, что приближаем в данный момент
        //т.к. кнопки приблизить и отдалить имеют один и тот же скрипт,
        //то надо сказать, что сейчас приближаем/отдаляем планету
        //поэтому если это кнопка с кодом 7, то говорим кнопке 8, которая идет следом по списку у родителя
        //если это кнопка с кодом 8, то говорим кнопке 7 по списку
        if(direction == 7)
            transform.parent.transform.GetChild(8).GetComponent<RotationgPlanet>().zooming = true;
        else if(direction == 8)
            transform.parent.transform.GetChild(7).GetComponent<RotationgPlanet>().zooming = true;
    }
    void Zoom()//функция приближения планеты
    {
        if (planet.transform.localScale.x < 6f)//если размер по иксу меньше 2
        {
            //увеличиваем размер планеты каждый тик
            Vector3 newScale = new Vector3(planet.transform.localScale.x + Time.deltaTime, planet.transform.localScale.y + Time.deltaTime, planet.transform.localScale.z + Time.deltaTime * 0.90f);
            planet.transform.Translate(-Vector3.up * Time.deltaTime * 13);
            planet.transform.localScale = newScale;//увеличиваем планету
        }
        else//как только достигли двойки в размере
        {
            zoomed = false;//говорим, что можно опять жать на кнопки
            //выставляем параметр, который отвечает за работу приближения/отдаления в данный момент обоим кнопкам в зависимости от их кода
            if (direction == 7)
                transform.parent.transform.GetChild(8).GetComponent<RotationgPlanet>().zooming = false;
            else if (direction == 8)
                transform.parent.transform.GetChild(7).GetComponent<RotationgPlanet>().zooming = false;
            //ставим планете правильный размер
            //planet.transform.localScale = new Vector3(/*2f, 2f, 1.8f*/4f, 4f, 3.5f);
        }
    }

    void UnZoom()//фукнция отдаления планеты
    {
        if (planet.transform.localScale.x > /*0.5f*/2)//если размер по иксу больше 0,8
        {
            //уменьшаем размер планеты каждый тик
            Vector3 newScale = new Vector3(planet.transform.localScale.x - Time.deltaTime, planet.transform.localScale.y - Time.deltaTime, planet.transform.localScale.z - Time.deltaTime * 0.90f);
            planet.transform.Translate(Vector3.up * Time.deltaTime * 15);
            planet.transform.localScale = newScale;//уменьшаем планету
        }
        else//как только достигли 0,5 в размере
        {
            zoomed = false;//говорим, что можно опять жать на кнопки
            //выставляем параметр, который отвечает за работу приближения/отдаления в данный момент обоим кнопкам в зависимости от их кода
            if (direction == 7)
                transform.parent.transform.GetChild(8).GetComponent<RotationgPlanet>().zooming = false;
            else if (direction == 8)
                transform.parent.transform.GetChild(7).GetComponent<RotationgPlanet>().zooming = false;
            //ставим планете правильный размер
            //planet.transform.localScale = new Vector3(/*0.5f, 0.5f, 0.45f*/2f, 2f, 1.8f);
        }
    }

    void RotatePlanet()//функция вращения планеты
    {
        switch (direction)//в зависимости от кода кнопки, на которой весит скрипт, крутим планету в соответсвии с нужным направлением
        {
            case 0: /* влево не по оси планеты */
                {
                    /*planet.transform.Rotate(Vector3.forward, -30 * Time.deltaTime);*/
                    planet.transform.RotateAround(planet.transform.position, Vector3.up, 30* Time.deltaTime);
                    break;
                }
            case 1: /* вправо не по оси планеты */
                {
                    /*planet.transform.Rotate(Vector3.forward, 30 * Time.deltaTime);*/
                    planet.transform.RotateAround(planet.transform.position, Vector3.up, -30 * Time.deltaTime);
                    break;
                }
            case 2: /* от нас не по оси планеты*/
                {
                    /*planet.transform.Rotate(Vector3.right, 30 * Time.deltaTime);*/
                    planet.transform.RotateAround(planet.transform.position, Vector3.right, 30 * Time.deltaTime);
                    break;
                }
            case 3: /* на нас не по оси планеты*/
                {
                    /*planet.transform.Rotate(Vector3.right, -30 * Time.deltaTime);*/
                    planet.transform.RotateAround(planet.transform.position, Vector3.right, -30 * Time.deltaTime);
                    break;
                }
            case 5: /* влнво по оси планеты */
                {
                    planet.transform.Rotate(Vector3.forward, 30 * Time.deltaTime);
                    break;
                }
            case 6: /* вправо по оси планеты */
                {
                    planet.transform.Rotate(Vector3.forward, -30 * Time.deltaTime);
                    break;
                }
        }
    }
}
