using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

[RequireComponent(typeof(Text))]

public class Slider_note2 : MonoBehaviour
{
    public Text ValueText2;
    public float valueVolume;
    void Start()
    {
        ValueText2 = GetComponent<Text>();
        
    }

    public void OnSliderValueChanged(float value2)
    {
        ValueText2.text = value2.ToString("0");
        valueVolume = float.Parse(ValueText2.text);
        //Debug.Log(valueNote);
    }
    
}