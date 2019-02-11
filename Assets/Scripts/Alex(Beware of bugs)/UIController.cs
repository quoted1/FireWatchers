using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private GameObject p1;
    private GameObject p2;
    private GameObject fireLight;

    public Text p1TwigText;
    public Text p1StickText;
    public Text p1LogText;
    public GameObject p1CarryWeight;

    public Text p2TwigText;
    public Text p2StickText;
    public Text p2LogText;
    public GameObject p2CarryWeight;

    private float fireIntensity;
    public float firePercent;
    public Text fireString;
    //public Text fireText;

	// Use this for initialization
	void Start () {
        p1 = GameObject.Find("Player1");//.GetComponent<CharacterMovement>();
        p2 = GameObject.Find("Player2");//.GetComponent<CharacterMovement>();
        fireLight = GameObject.Find("FireLight");
    }
	
	// Update is called once per frame
	void Update () {

        p1TwigText.text = p1.GetComponent<CharacterMovement>().Twig.ToString();
        p1StickText.text = p1.GetComponent<CharacterMovement>().Stick.ToString();
        p1LogText.text = p1.GetComponent<CharacterMovement>().Log.ToString();
        p1CarryWeight.GetComponent<Slider>().value = p1.GetComponent<CharacterMovement>().Weight;

        p2TwigText.text = p2.GetComponent<CharacterMovement>().Twig.ToString();
        p2StickText.text = p2.GetComponent<CharacterMovement>().Stick.ToString();
        p2LogText.text = p2.GetComponent<CharacterMovement>().Log.ToString();
        p2CarryWeight.GetComponent<Slider>().value = p2.GetComponent<CharacterMovement> ().Weight;

        fireIntensity = fireLight.GetComponent<Light>().intensity/2;
        firePercent = Mathf.RoundToInt(fireIntensity * 100);
        fireString.text = firePercent.ToString() + "%";
       
    }
}
