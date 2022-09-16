using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo PI;

    public int mySelectedCharacter;

    public GameObject[] allCharacters;

    private void OnEnable()
    {
        if(PlayerInfo.PI == null)
        {
            PlayerInfo.PI = this;
        }
        else
        {
            if(PlayerInfo.PI != this)
            {
                Destroy(PlayerInfo.PI.gameObject);
                PlayerInfo.PI = this;

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            mySelectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);
        }
    }

    // public void ChangeNext()
    // {
    //     allCharacters[mySelectedCharacter].SetActive(false);


    //     mySelectedCharacter++;
    //     if (mySelectedCharacter == allCharacters.Length)
    //         mySelectedCharacter = 0;

    //     allCharacters[mySelectedCharacter].SetActive(true);
    //     PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);
    // }

}
