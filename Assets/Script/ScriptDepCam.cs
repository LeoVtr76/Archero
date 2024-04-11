using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class ScriptDepCam : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(-18, 12.53f, ScriptPlayer.PosZ-5);
    }
}
