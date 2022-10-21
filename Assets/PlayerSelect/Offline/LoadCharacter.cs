using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    //public Transform spawnPoint;
    //public TMP_Text label;
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];

        int spawnPoint = Random.Range(-20, 20);
        GameObject clone = Instantiate(prefab, new Vector3(spawnPoint, 0, spawnPoint), Quaternion.identity);
        //label.text = prefab.name;
    }

    
}
