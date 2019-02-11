using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public GameObject PlayerCharacter;
    public GameObject PlayerCharacterBody;
    public bool Player1, Player2;
    public float Speed;

    public bool EnabledMovement;

    public GameObject Shield;

    public int Twig = 0, Stick = 0, Log = 0; 
    public int Weight;

    public bool Pickupable;
    public bool InFire;

    public bool ShieldBroken;

    public GameObject ItemPickingUp;

    public AudioSource StickUp;
    public AudioSource StickDown;
    public AudioSource ShieldBroke;

    public AudioSource ShieldDeployed;
    public AudioSource ShieldPutDown;

    public Animator PlayerAnimations;

    void Awake()
    {
        EnabledMovement = true;
        Weight = 0;
        Speed = 5;
        PlayerCharacter = this.gameObject;
        Twig = 0;
        Stick = 0;
        Log = 0;
        PlayerAnimations = this.GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stick" || other.gameObject.tag == "Twig" || other.gameObject.tag == "Log")
        {
//            Debug.Log("ON ITEM");
            Pickupable = true;
            ItemPickingUp = other.gameObject;
        }

        if (other.gameObject.tag == "Fire")
           {
//            Debug.Log("IN FIRE");
               InFire = true;
           }

        if (other.tag == "Snow")
        {
            Debug.Log(this.name + " walking on snow");
            Speed = Speed / 1.35f;
        }
    }

    void PlayerShieldCheck()
    {
        if (Shield.GetComponentInChildren<CharacterWindHit>().BrokenNow == true)
        {
//            Debug.Log("BROKEN SHIELD");
            PlayerAnimations.SetTrigger("Broke");



            EnabledMovement = false;
            StartCoroutine(RestoreBrokenShield());
        }
    }

    public IEnumerator RestoreBrokenShield()
    {
        if (ShieldBroke.isPlaying == false)  
        {
            ShieldBroke.Play();
        }

        yield return new WaitForSecondsRealtime(5);
        Shield.GetComponentInChildren<CharacterWindHit>().BrokenNow = false;
        PlayerAnimations.ResetTrigger("DownShield");
        PlayerAnimations.ResetTrigger("Broke");
        PlayerAnimations.ResetTrigger("Walking");
        PlayerAnimations.ResetTrigger("Deposit");
        EnabledMovement = true;
        StopCoroutine(RestoreBrokenShield());
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            InFire = false;
//            Debug.Log("LEFT FIRE");
        }
        if (other.gameObject.tag == "Stick" || other.gameObject.tag == "Twig" || other.gameObject.tag == "Log")
        {
//            Debug.Log("LEFT ITEM");
            Pickupable = false;
            ItemPickingUp = null;
        }
    }

    private void FixedUpdate()
    {
        if (Player1 == true)
        {
//            Player1Shield();
//            PlayerShieldCheck();

            if (EnabledMovement == true)
            {
                ControlPlayer1();
                Player1Pickup();
                Player1Deposit();
            }
        }

        if (Player2 == true)
        {
//            Player2Shield();
//            PlayerShieldCheck();

            if (EnabledMovement == true)
            {
                ControlPlayer2();
                Player2Pickup();
                Player2Deposit();
            }
        }
    }

    void Update()
            {

        if (Player1 == true)
        {
            Player1Shield();
            PlayerShieldCheck();
        }
        if (Player2 == true)

        {
            Player2Shield();
            PlayerShieldCheck();
        }


            //Alex Implementing max carrying capacity slow
            if (Weight == 10)
        {
            Speed = 2.5f;
        }
        else
        {
            Speed = 5f;
        }
    }

    void Player1Shield()
    {
        if (Input.GetKey(KeyCode.Space))
        {
//            Debug.Log("P1 Shield Up");
            PlayerAnimations.ResetTrigger("DownShield");

            PlayerAnimations.SetBool("PutUpShield", true);
            PlayerAnimations.SetBool("Walking", false);
            EnabledMovement = false;

            ShieldDeployed.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
//            Debug.Log("P1 Shield Down");
            PlayerAnimations.SetBool("PutUpShield", false);
            PlayerAnimations.SetTrigger("DownShield");
            EnabledMovement = true;

            ShieldPutDown.PlayOneShot(ShieldPutDown.clip);
        }

    }

    void Player2Shield()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
//            Debug.Log("P2 Shield Up");
            PlayerAnimations.ResetTrigger("DownShield");

            PlayerAnimations.SetBool("PutUpShield", true);
            PlayerAnimations.SetBool("Walking", false);
            EnabledMovement = false;

            ShieldDeployed.Play();

        }

        if (Input.GetKeyUp(KeyCode.RightControl))
        {
 //           Debug.Log("P2 Shield Down");
            PlayerAnimations.SetBool("PutUpShield", false);
            PlayerAnimations.SetTrigger("DownShield");
            EnabledMovement = true;

            ShieldPutDown.PlayOneShot(ShieldPutDown.clip);

        }

    }

    public IEnumerator RestoreMovement()
    {
        yield return new WaitForSecondsRealtime(5);
        EnabledMovement = true;
        StopCoroutine(RestoreMovement());
    }

    void Player1Pickup() {
        if(Pickupable == true)
        {
            if (Input.GetKeyDown(KeyCode.H) && ItemPickingUp.tag == "Twig" && Weight <= 9)
            {
 //               Debug.Log("Player 1 picked up Twig");
                StickUp.PlayOneShot(StickUp.clip);
                PlayerAnimations.SetTrigger("Pickup");
                Weight += 1;
                Twig += 1;
                Destroy(ItemPickingUp);
                ItemPickingUp = null;
                Pickupable = false;
            }
            if (Input.GetKeyDown(KeyCode.H) && ItemPickingUp.tag == "Stick" && Weight < 9)
            {
//                Debug.Log("Player 1 picked up Stick");
                StickUp.PlayOneShot(StickUp.clip);
                PlayerAnimations.SetTrigger("Pickup");
                Weight += 3;
                Stick += 1;
                Destroy(ItemPickingUp);
                ItemPickingUp = null;
                Pickupable = false;
            }
            if (Input.GetKeyDown(KeyCode.H) && ItemPickingUp.tag == "Log" && Log == 0 && Stick ==0 && Twig == 0)
            {
//                Debug.Log("Player 1 picked up Log");
                StickUp.PlayOneShot(StickUp.clip);
                PlayerAnimations.SetTrigger("Pickup");
                Weight += 10;
                Log += 1;
                Destroy(ItemPickingUp);
                ItemPickingUp = null;
                Pickupable = false;
            }
        }
    }

    void Player2Pickup()
    {
        if (Pickupable == true)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) && ItemPickingUp.tag == "Twig" && Weight <= 9)
            {
//                Debug.Log("Player 2 picked up Twig");
                StickUp.PlayOneShot(StickUp.clip);
                PlayerAnimations.SetTrigger("Pickup");
                Weight += 1;
                Twig += 1;
                Destroy(ItemPickingUp);
                ItemPickingUp = null;
                Pickupable = false;
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter) && ItemPickingUp.tag == "Stick" && Weight < 9)
            {
//                Debug.Log("Player 2 picked up Stick");
                StickUp.PlayOneShot(StickUp.clip);
                PlayerAnimations.SetTrigger("Pickup");
                Weight += 3;
                Stick += 1;
                Destroy(ItemPickingUp);
                ItemPickingUp = null;
                Pickupable = false;
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter) && ItemPickingUp.tag == "Log" && Log == 0 && Stick == 0 && Twig == 0)
            {
//                Debug.Log("Player 2 picked up Log");
                StickUp.PlayOneShot(StickUp.clip);
                PlayerAnimations.SetTrigger("Pickup");
                Weight += 10;
                Log += 1;
                Destroy(ItemPickingUp);
                ItemPickingUp = null;
                Pickupable = false;
            }
        }
    }

    void Player1Deposit()
    {
        if (Input.GetKeyDown(KeyCode.J) && Twig >= 1)
        {
//            Debug.Log("Player 1 added Twig to fire");
            StickDown.PlayOneShot(StickDown.clip);
            PlayerAnimations.SetTrigger("Deposit");
            Twig -= 1;
            Weight -= 1;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().Intensity = 0.1f;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().IncreaseFire();
        }
        if (Input.GetKeyDown(KeyCode.J) && Stick >= 1)
        {
//            Debug.Log("Player 1 added Stick to fire");
            StickDown.PlayOneShot(StickDown.clip);
            PlayerAnimations.SetTrigger("Deposit");
            Stick -= 1;
            Weight -= 3;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().Intensity = 0.3f;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().IncreaseFire();
        }
        if (Input.GetKeyDown(KeyCode.J) && Log == 1)
        {
//            Debug.Log("Player 1 added Log to fire");
            StickDown.PlayOneShot(StickDown.clip);
            PlayerAnimations.SetTrigger("Deposit");
            Log -= 1;
            Weight -= 10;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().Intensity = 0.5f;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().IncreaseFire();
        }
    }

    void Player2Deposit()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && Twig >= 1)
        {
//            Debug.Log("Player 2 added Twig to fire");
            StickDown.PlayOneShot(StickDown.clip);
            PlayerAnimations.SetTrigger("Deposit");
            Twig -= 1;
            Weight -= 1;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().Intensity = 0.1f;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().IncreaseFire();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) && Stick >= 1)
        {
//            Debug.Log("Player 2 added Stick to fire");
            StickDown.PlayOneShot(StickDown.clip);
            PlayerAnimations.SetTrigger("Deposit");
            Stick -= 1;
            Weight -= 3;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().Intensity = 0.3f;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().IncreaseFire();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) && Log == 1)
        {
//            Debug.Log("Player 2 added Log to fire");
            StickDown.PlayOneShot(StickDown.clip);
            PlayerAnimations.SetTrigger("Deposit");
            Log -= 1;
            Weight -= 10;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().Intensity = 0.5f;
            GameObject.Find("CampFire").GetComponentInChildren<FireDecay>().IncreaseFire();
        }
    }

    void ControlPlayer1()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movement != Vector3.zero)
        {
            PlayerAnimations.SetBool("Walking", true);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.15f);
            transform.Translate(movement * Speed * Time.deltaTime, Space.World);
        }
        else
        {
            PlayerAnimations.SetBool("Walking", false);
        }
    }

    void ControlPlayer2()
    {
        float moveHorizontal = Input.GetAxisRaw("ArrowHorizontal");
        float moveVertical = Input.GetAxisRaw("ArrowVertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            PlayerAnimations.SetBool("Walking", true);
//
//            if(PlayerAnimations.GetBool("PutUpShield") == true)
//            {
//
//                PlayerAnimations.SetBool("PutUpShield", false);
//            }

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.15f);
            transform.Translate(movement * Speed * Time.deltaTime, Space.World);
        }
        else
        {
            PlayerAnimations.SetBool("Walking", false);
        }
    }
}

