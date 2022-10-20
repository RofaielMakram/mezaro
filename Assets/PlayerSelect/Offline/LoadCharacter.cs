using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];

        int spawnPoint = Random.Range(-20, 20);
        GameObject clone = Instantiate(prefab, new Vector3(spawnPoint, 0, spawnPoint), Quaternion.identity);
    }

    
}
