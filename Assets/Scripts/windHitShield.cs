using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windHitShield : MonoBehaviour {

    void OnParticleCollision()
    {
        GameObject.Find("Sectors").GetComponent<SectorController>().shieldHit = true;
    }
}
