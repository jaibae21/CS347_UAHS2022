using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float gravity = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per graphical frame
    void Update()
    {
        //up because simulating tapping
        bool isTapping = Input.GetKeyUp(KeyCode.Space);

    }
}
