using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.Mathematics;
using UnityEngine;

public class FOWScript : MonoBehaviour
{
    public Renderer renderer;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        renderer.enabled = true;            
    }

    // Update is called once per frame
    void Update()
    { 

    }

    public void turnOffRenderer()
    {
        if (active)
        {
            renderer.enabled = false;            
            active = false;
        }
    }
    
    public void turnOnRenderer()
    {
        if (!active)
        {
            renderer.enabled = true;            
            active = true;
        }
    }

}
