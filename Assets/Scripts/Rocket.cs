using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float speed;

    public GameObject _testWayPoint;

    public Transform destinationPoint;
    public Transform laucnhPoint;

    private GameObject[] way = new GameObject[9];
    public GameObject currentWay;
    private int counter;
    private bool nearDestionation;

    private bool ok;


    // Use this for initialization
    void Start ()
    {
        CalculateTrajectory();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ok)
            FlyToDestination();
    }

    void CalculateTrajectory()
    {
        Vector3[] points = new Vector3[9];

        way[0] = Instantiate(_testWayPoint, GameObject.Find("Cities Storage").transform, true);
        way[8] = Instantiate(_testWayPoint, GameObject.Find("Cities Storage").transform, true);
        way[0].transform.localPosition = laucnhPoint.localPosition;
        way[8].transform.localPosition = destinationPoint.localPosition;
        way[0].name = "0";
        way[8].name = "8";
        
        points[4] = CalculateSectionMiddle(laucnhPoint.localPosition, destinationPoint.localPosition);
        way[4] = Instantiate(_testWayPoint, GameObject.Find("Cities Storage").transform, true);
        way[4].transform.localPosition = points[4];
        way[4].name = "4";
        
        /* левая половина */
        points[2] = CalculateSectionMiddle(way[0].transform.localPosition, way[4].transform.localPosition);
        way[2] = Instantiate(_testWayPoint, GameObject.Find("Cities Storage").transform, true);
        way[2].transform.localPosition = points[2];
        way[2].name = "2";

        points[1] = CalculateSectionMiddle(way[0].transform.localPosition, way[2].transform.localPosition);
        way[1] = Instantiate(_testWayPoint, GameObject.Find("Cities Storage").transform, true);
        way[1].transform.localPosition = points[1];
        way[1].name = "1";

        points[3] = CalculateSectionMiddle(way[2].transform.localPosition, way[4].transform.localPosition);
        way[3] = Instantiate(_testWayPoint, GameObject.Find("Cities Storage").transform, true);
        way[3].transform.localPosition = points[3];
        way[3].name = "3";

        /* правая половина */
        points[6] = CalculateSectionMiddle(way[8].transform.localPosition, way[4].transform.localPosition);
        way[6] = Instantiate(_testWayPoint, GameObject.Find("Cities Storage").transform, true);
        way[6].transform.localPosition = points[6];
        way[6].name = "6";

        points[5] = CalculateSectionMiddle(way[6].transform.localPosition, way[4].transform.localPosition);
        way[5] = Instantiate(_testWayPoint, GameObject.Find("Cities Storage").transform, true);
        way[5].transform.localPosition = points[5];
        way[5].name = "5";

        points[7] = CalculateSectionMiddle(way[8].transform.localPosition, way[6].transform.localPosition);
        way[7] = Instantiate(_testWayPoint, GameObject.Find("Cities Storage").transform, true);
        way[7].transform.localPosition = points[7];
        way[7].name = "7";

        float maxDistance = Vector3.Distance(GameObject.Find("Flight Area").transform.GetChild(0).transform.position, GameObject.Find("Earth").transform.position);
        for (int i = 0; i < way.Length; i++)
        {
            way[i].transform.LookAt(GameObject.Find("Earth").transform.position);
            //way[i].transform.Translate(-way[i].transform.forward * Time.deltaTime);
            float currentDistance = Vector3.Distance(way[i].transform.position, GameObject.Find("Earth").transform.position);
            while (currentDistance < maxDistance)
            {
                way[i].transform.Translate(-way[i].transform.forward * 0.1f, Space.World);
                currentDistance = Vector3.Distance(way[i].transform.position, GameObject.Find("Earth").transform.position);
            }
        }

        transform.LookAt(way[0].transform.position);
        currentWay = way[0];
        counter = 0;

        ok = true;
    }

    void FlyToDestination()
    {
        if (Vector3.Distance(transform.position, currentWay.transform.position) > 0.1f)
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        else
        {
            counter++;
            if (counter < way.Length)
            {
                currentWay = way[counter];
                Destroy(way[counter - 1].gameObject);
                transform.LookAt(currentWay.transform.position);
            }
            else if (nearDestionation)
                Destroy(gameObject);
            else
            {
                currentWay = destinationPoint.gameObject;
                transform.LookAt(currentWay.transform.position);
                Destroy(way[counter - 1].gameObject);
                nearDestionation = true;
            }
        }
    }

    Vector3 CalculateSectionMiddle(Vector3 startPoint, Vector3 endPoint)
    {
        Vector3 res = new Vector3((endPoint.x + startPoint.x) / 2,
                                  (endPoint.y + startPoint.y) / 2,
                                  (endPoint.z + startPoint.z) / 2);
        return res;
    }
}
