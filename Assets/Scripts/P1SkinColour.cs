using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1SkinColour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponentInChildren<MeshRenderer>().material = GameObject.Find("MasterControl").GetComponentInChildren<CharacterCustomiser>().Player1Skin;
    }
}
