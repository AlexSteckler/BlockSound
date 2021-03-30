using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomAudio : MonoBehaviour
{
   public double bpm = 140.0F;

    public double nextTick = 0.0F; // The next tick in dspTime
    public double sampleRate = 0.0F; 
    public bool ticked = false;

    void Start() {
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;

        nextTick = startTick + (60.0 / bpm);
    }

    void LateUpdate() {
        if ( !ticked && nextTick >= AudioSettings.dspTime ) {
            ticked = true;
            BroadcastMessage( "OnTick" );
        }
    }

    // Just an example OnTick here
    void OnTick() {
        Debug.Log( "Tick" );
        // GetComponent<AudioSource>().Play();
    }

    void FixedUpdate() {
        double timePerTick = 60.0f / bpm;
        double dspTime = AudioSettings.dspTime;

        while (dspTime >= nextTick ) {
            ticked = false;
            nextTick += timePerTick;
        }

    }
}
