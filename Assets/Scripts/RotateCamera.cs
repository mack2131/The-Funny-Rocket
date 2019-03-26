using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
            Rotate();
        else if (Input.GetMouseButton(2))
            transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void Rotate()
    {
        float mY = -Input.GetAxis("Mouse X");
        float rot = Mathf.Clamp(-mY * 45 * Time.deltaTime, -40, 40);
        transform.RotateAround(transform.position, transform.up, rot);
    }
}
