using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.



[RequireComponent(typeof(Text))]

public class Slider : MonoBehaviour
{
    public Text ValueText;
    void Start()
    {
        ValueText = GetComponent<Text>();
        
    }

    public void OnSliderValueChanged(float value)
    {
        ValueText.text = value.ToString("0");
    }

}