using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomiser : MonoBehaviour {

    public float ShirtR, ShirtG, ShirtB;
    public float SkinR, SkinG, SkinB;

    public Material Player1Skin, Player1Shirt;
    public Material Player2Skin, Player2Shirt;

    //BORDERS
    public Image P1SkinWhite, P1SkinBlack, P1ShirtGreen, P1ShirtRed;
    public Image P2SkinWhite, P2SkinBlack, P2ShirtGreen, P2ShirtRed;


    private static bool Created = false;

    private void Awake()
    {
        if (!Created)
        {
            DontDestroyOnLoad(this.gameObject);
            Created = true;
            Debug.Log("MADE NEW SAVE");
        }

    }

    void Start () {
        Player1Skin.color = new Color(0.796f, 0.714f, 0.522f);      //WHITE
        P1SkinWhite.enabled = true;
        P1SkinBlack.enabled = false;

        Player1Shirt.color = new Color(0.529f, 0.141f, 0.141f);     //RED
        P1ShirtGreen.enabled = false;
        P1ShirtRed.enabled = true;

        Player2Skin.color = new Color(0.388f,0.227f, 0.165f);       //BLACK
        P2SkinWhite.enabled = false;
        P2SkinBlack.enabled = true;

        Player2Shirt.color = new Color(0.165f, 0.565f, 0.153f);     //GREEN
        P2ShirtGreen.enabled = true;
        P2ShirtRed.enabled = false;
    }

    public void Player1GreenShirt()
    {
        Player1Shirt.color = new Color(0.165f, 0.565f, 0.153f);
        P1ShirtGreen.enabled = true;
        P1ShirtRed.enabled = false;
    }
    public void Player1RedShirt()
    {
        Player1Shirt.color = new Color(0.529f, 0.141f, 0.141f);
        P1ShirtGreen.enabled = false;
        P1ShirtRed.enabled = true;
    }
    public void Player1WhiteSkin()
    {
        Player1Skin.color = new Color(0.796f, 0.714f, 0.522f);
        P1SkinWhite.enabled = true;
        P1SkinBlack.enabled = false;
    }
    public void Player1BlackSkin()
    {
        Player1Skin.color = new Color(0.388f, 0.227f, 0.165f);
        P1SkinWhite.enabled = false;
        P1SkinBlack.enabled = true;
    }


    public void Player2GreenShirt()
    {
        Player2Shirt.color = new Color(0.165f, 0.565f, 0.153f);
        P2ShirtGreen.enabled = true;
        P2ShirtRed.enabled = false;
    }
    public void Player2RedShirt()
    {
        Player2Shirt.color = new Color(0.529f, 0.141f, 0.141f);
        P2ShirtGreen.enabled = false;
        P2ShirtRed.enabled = true;
    }
    public void Player2WhiteSkin()
    {
        Player2Skin.color = new Color(0.796f, 0.714f, 0.522f);
        P2SkinWhite.enabled = true;
        P2SkinBlack.enabled = false;
    }
    public void Player2BlackSkin()
    {
        Player2Skin.color = new Color(0.388f, 0.227f, 0.165f);
        P2SkinWhite.enabled = false;
        P2SkinBlack.enabled = true;
    }

}
