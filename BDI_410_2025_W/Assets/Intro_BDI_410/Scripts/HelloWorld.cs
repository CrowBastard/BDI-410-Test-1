using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Hello(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hello()
    {
        Debug.Log("Hello World!");
    }
}
