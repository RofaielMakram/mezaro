using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public PixelGunGameManager GameManager;
    [SerializeField] int numCharacter;
    // Start is called before the first frame update

    void Start()
    {
        GameManager.select1();
    }
    
}
