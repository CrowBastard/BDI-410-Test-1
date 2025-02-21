using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{
    public Image progressBar;
    public float frequency = 1.0f;
    public float magnitude = 0.5f;
    public float offSet = 0.5f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float fillAmount = offSet + Mathf.Sin(Time.time * frequency) * magnitude;
        fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);
        progressBar.fillAmount = fillAmount;
    }
}
