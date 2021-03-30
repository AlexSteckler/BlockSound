using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidiNoteValue : MonoBehaviour
{
    public float midiNote;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveValue(float val) {
        midiNote = val;
    }
}
