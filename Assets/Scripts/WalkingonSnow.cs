using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingonSnow : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
//        Debug.Log("mesh collision");
        if (other.tag == "Player1" || other.tag == "Player2")
        {
//            Debug.Log(other.name + " wlking on snow");
//            other.GetComponent<CharacterMovement>().Speed = other.GetComponent<CharacterMovement>().Speed / 1.35f;
        }
    }
}
