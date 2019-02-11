using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireScript : MonoBehaviour {

    public Text FirePercent;

    private GameObject FireLight;

    // Use this for initialization
    void Start () {

        FireLight = GameObject.Find("FireLight");
		
	}
	
	// Update is called once per frame
	void Update () {

        FirePercent.text = FireLight.GetComponent<Light>().intensity.ToString();

	}
}
