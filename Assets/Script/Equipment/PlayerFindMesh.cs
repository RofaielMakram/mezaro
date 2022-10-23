using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFindMesh : MonoBehaviour
{
    public SkinnedMeshRenderer playerMesh;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }
}
