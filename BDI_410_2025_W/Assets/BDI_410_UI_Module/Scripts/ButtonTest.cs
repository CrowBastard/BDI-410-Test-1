using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    // A public string variable that can be set from the Unity Inspector
    public string message;

    // This method will be called when the script is loaded or a value is changed in the Inspector (Editor only)
    public void TestButton()
    {
        // Check if the message is not empty or null
        if (!string.IsNullOrEmpty(message))
        {
            Debug.Log("Debugging message: " + message);
        }
        else
        {
            Debug.LogWarning("Message is either null or empty.");
        }
    }

  
}
