using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWindHit : MonoBehaviour {

    public float MaxStrength;
    public float CurrentWindStrength;

    public bool BrokenNow;

	void Start () {
        MaxStrength = 0.9f;
	}
	
	void Update () {
       CurrentWindStrength = GameObject.Find("Sectors").GetComponentInChildren<SectorController>().WindStrength;

    }

    void OnParticleCollision()
    {
        CheckShieldHit();
    }

        public void CheckShieldHit()
    {
        if (CurrentWindStrength >= MaxStrength && BrokenNow == false)
        {
            BrokenNow = true;
        }
    }
}
