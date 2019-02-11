using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class FireDecay : MonoBehaviour {


    private Light fireLight;
    public float Intensity;

    public float snowheightspeed;

    public PostProcessingBehaviour cameraPostProcess;

    public GameObject snowOBJ;

	void Start () {

        fireLight = this.gameObject.GetComponentInChildren<Light>();
        InvokeRepeating("fireDecay", 10f, 0.01f);
        Intensity = 0.3f;
        this.gameObject.GetComponentInChildren<Light>().intensity = 2.0f;
//        cameraPostProcess = GameObject.Find("MainCamera").GetComponent<PostProcessingBehaviour>();

    }

    void fireDecay()
    {
        this.gameObject.GetComponentInChildren<Light>().intensity = Mathf.Clamp(fireLight.intensity - 0.0003f, 0.0f, 2f);
        snowControl();
//        Debug.Log("fire decaying");
    }

    private void FixedUpdate()
    {
        /*
        if (Input.GetKeyUp(KeyCode.Slash))
        {
            IncreaseFire();
        }
        */
    }

    public void IncreaseFire()
    {
        fireLight.intensity = Mathf.Clamp(fireLight.intensity + Intensity, 0.0f, 2f);
    }

    void snowControl()
    {
        if (fireLight.intensity < 0.2)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0.351f, snowOBJ.transform.position.y);
        }
        if (0.2 < fireLight.intensity && fireLight.intensity < 0.4)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0.312f, snowOBJ.transform.position.y);
        }
        if (0.4 < fireLight.intensity && fireLight.intensity < 0.6)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0.273f, snowOBJ.transform.position.y);
        }
        if (0.6 < fireLight.intensity && fireLight.intensity < 0.8)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0.234f, snowOBJ.transform.position.y);
        }
        if (0.8 < fireLight.intensity && fireLight.intensity < 1.0)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0.195f, snowOBJ.transform.position.y);
        }
        if (1.0 < fireLight.intensity && fireLight.intensity < 1.2)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0.156f, snowOBJ.transform.position.y);
        }
        if (1.2 < fireLight.intensity && fireLight.intensity < 1.4)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0.117f, snowOBJ.transform.position.y);
        }
        if (1.4 < fireLight.intensity && fireLight.intensity < 1.6)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0.078f, snowOBJ.transform.position.y);
        }
        if (1.6 < fireLight.intensity && fireLight.intensity < 1.8)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0.039f, snowOBJ.transform.position.y);

        }
        if (1.8 < fireLight.intensity && fireLight.intensity < 2.0)
        {
            snowOBJ.transform.position = new Vector3(snowOBJ.transform.position.x, 0, snowOBJ.transform.position.y);
        }

        //changing the speed of the character when walking through snow


    }

}
