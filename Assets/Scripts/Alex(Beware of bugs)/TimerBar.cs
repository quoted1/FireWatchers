using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour {

    public Camera cameraToLookAt;

	// Use this for initialization
	void Start () {
		//transform.Rotate( 180,0,0 );
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 v = cameraToLookAt.transform.position - transform.position;

        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
		
	}
}
