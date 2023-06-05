using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    
    public GameObject activeObject;
    public GameObject disactiveObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActiveAndDisActive();
    }

    public void ActiveAndDisActive()
    {
        if (Input.GetKeyDown(KeyCode.V))
            {

                activeObject.SetActive(true);
            }
        

    }
}
