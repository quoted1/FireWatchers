using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorController : MonoBehaviour {

    public GameObject[] sectors;
    public GameObject chosenWindZone;
    public GameObject twig;
    public GameObject stick;
    public GameObject log;
    private GameObject[] fuel;
    public bool fireHit;
    public bool shieldHit;
    public int gameWinTime;
    public float windfireinteraction;
    private float windStrengthMin;
    private float windStrengthMax;
    public Light campFireLight;
    private Color windLow, windMedium, windHigh;

    public float WindStrength;

    public AudioSource WindStartUpSound;

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject instructionsOverlayOBJ;

    private bool gameComplete;
    private bool gameLost;
    private bool instructionsVisible;

    private int timeInt;

    private void Awake()
    {
        fireHit = false;
        shieldHit = false;
        campFireLight = GameObject.Find("FireLight").GetComponent<Light>();
        fuel = new GameObject[]
        {
            twig,twig,twig, stick,stick, log
        };
        windfireinteraction = 0.1f;
        windStrengthMin = 0.2f;
        windStrengthMax = 1.2f;

        winScreen.SetActive(false);
        gameComplete = false;
        loseScreen.SetActive(false);
        gameLost = false;
//        instructionsVisible = false;
        timeInt = 0;
    }
   
    private void Start()
    {
        windZoneInit();
        StartCoroutine(instructionsOverlay());
        InvokeRepeating("increasetimeInt", 0f, 1f);
    }

    void increasetimeInt()
    {
        timeInt++;
    }

    private IEnumerator instructionsOverlay()
    {
        instructionsOverlayOBJ.SetActive(true);

        yield return new WaitForSeconds(20f);

        instructionsOverlayOBJ.SetActive(false);

        StopCoroutine(instructionsOverlay());
    }

    void FixedUpdate()
    {
        if (shieldHit == true)
        {
            //do something
            
            shieldHit = false;
        }

        if (fireHit == true)
        {
            //do something
           
            campFireLight.intensity = Mathf.Clamp(campFireLight.intensity - windfireinteraction, 0.2f, 2f);
            fireHit = false;
        }

        if (timeInt == 40)
        {
            windStrengthMin = 0.4f;
            windStrengthMax = 1.2f;
        }
        if (timeInt == 80)
        {
            windStrengthMin = 0.6f;
            windStrengthMax = 1.5f;
        }
        if (timeInt == 120)
        {
            winScreen.SetActive(true);
            gameComplete = true;
        }
        if (campFireLight.intensity == 0.2f && gameComplete == false)
        {
            //game lose function
            loseScreen.SetActive(true);
            gameLost = true;
        }
    }

    void windZoneInit()
    {
        StartCoroutine(windZoneStart());
        //windZoneStart_02();
    }

    private IEnumerator windZoneStart()
    {
        sectors = GameObject.FindGameObjectsWithTag("Sectors"); //finds and defines the 8 sectors
        chosenWindZone = sectors[Random.Range(0, 7)]; // randomly chooses a sector

        ParticleSystem ps = chosenWindZone.GetComponentInChildren<ParticleSystem>();
        ParticleSystem.MainModule psmain = chosenWindZone.GetComponentInChildren<ParticleSystem>().main;
        ParticleSystem.VelocityOverLifetimeModule psvelmod = chosenWindZone.GetComponentInChildren<ParticleSystem>().velocityOverLifetime;

        //set the particle system variables
        psvelmod.orbitalY = -10.0f;
        ps.Play(); // start playing the emitter
        WindStartUpSound.PlayOneShot(WindStartUpSound.clip);
        WindStrength = Random.Range(0.2f, 1.2f);
        psmain.simulationSpeed = WindStrength; // play the emitter at a certain speed

        yield return new WaitForSeconds(3);

        psvelmod.orbitalY = 0.0f;

        Invoke("addStick", Random.Range(0, 4)); //throw in a stick between 1 to 3 seconds later
        Invoke("addStick", Random.Range(0, 4));

        yield return new WaitForSeconds(2); //3 second pause

        ps.Stop(); // stop the emission
        Invoke("windZoneInit", Random.Range(2, 5)); // loop this function randomly between 2 to 7 seconds later
    }

    void addStick()
    {
        Vector3 stickThrowDir = new Vector3(chosenWindZone.transform.position.x, (chosenWindZone.transform.position.y + Random.Range(0, 2)), (chosenWindZone.transform.position.z + Random.Range(-20, 20)));
        GameObject spawnedStick = Instantiate(fuel[Random.Range(0, 6)], chosenWindZone.transform.position, chosenWindZone.transform.rotation);
        spawnedStick.GetComponent<Rigidbody>().AddForce((Random.Range(0.5f, 0.75f))*-(stickThrowDir), ForceMode.Impulse);
    }

   
}

