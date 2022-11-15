using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnlaser_script : MonoBehaviour
{ 
    public GameObject laser; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(laser, transform.position, transform.rotation);
        }
    }
}
