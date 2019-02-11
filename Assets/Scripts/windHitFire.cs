using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windHitFire : MonoBehaviour {

    void OnParticleCollision()
    {
        GameObject.Find("Sectors").GetComponent<SectorController>().fireHit = true;
    }
}
