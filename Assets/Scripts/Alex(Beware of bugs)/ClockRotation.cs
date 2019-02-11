using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotation : MonoBehaviour {

        public Transform from;
        public Transform to;

        private float timeCount = 0.0f;
        public int timeDurationInSeconds;
	
	void Update ()
    {
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
        timeCount = timeCount + Time.deltaTime/timeDurationInSeconds;
	}
}
