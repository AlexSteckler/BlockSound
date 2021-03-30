using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class LibPd2UnityExample : MonoBehaviour
{
    //The Pure Data patch we will listen to.
    public LibPdInstance pdPatch;
    public float note1, note2, note3, note4, note5, note6, note7, note8;
    public float vol1, vol2, vol3, vol4, vol5, vol6, vol7, vol8;
    public float speed;
    public GameObject metro;
    public GameObject volu;
    public float volume;
    public GameObject[] notes;
    public GameObject[] volumes;
    void Start()
    {
        //notes = new GameObject[8];
        //pdPatch.Bind("sequenzer_00.pd");
        pdPatch.SendBang("toggle");
        
    }
    void Update() {
        note1 = notes[0].GetComponent<MidiNoteValue>().midiNote;
        note2 = notes[1].GetComponent<MidiNoteValue>().midiNote;
        note3 = notes[2].GetComponent<MidiNoteValue>().midiNote;
        note4 = notes[3].GetComponent<MidiNoteValue>().midiNote;
        note5 = notes[4].GetComponent<MidiNoteValue>().midiNote;
        note6 = notes[5].GetComponent<MidiNoteValue>().midiNote;
        note7 = notes[6].GetComponent<MidiNoteValue>().midiNote;
        note8 = notes[7].GetComponent<MidiNoteValue>().midiNote;

        vol1 = volumes[0].GetComponent<UpDown>().percentage;
        vol2 = volumes[1].GetComponent<UpDown>().percentage;
        vol3 = volumes[2].GetComponent<UpDown>().percentage;
        vol4 = volumes[3].GetComponent<UpDown>().percentage;
        vol5 = volumes[4].GetComponent<UpDown>().percentage;
        vol6 = volumes[5].GetComponent<UpDown>().percentage;
        vol7 = volumes[6].GetComponent<UpDown>().percentage;
        vol8 = volumes[7].GetComponent<UpDown>().percentage;

        speed = metro.GetComponent<rotate>().angle;
        volume = volu.GetComponent<MidiNoteValue>().midiNote;

        pdPatch.SendFloat("note1", note1);
        pdPatch.SendFloat("note2", note2);
        pdPatch.SendFloat("note3", note3);
        pdPatch.SendFloat("note4", note4);
        pdPatch.SendFloat("note5", note5);
        pdPatch.SendFloat("note6", note6);
        pdPatch.SendFloat("note7", note7);
        pdPatch.SendFloat("note8", note8);

        pdPatch.SendFloat("vol1", vol1);
        pdPatch.SendFloat("vol2", vol2);
        pdPatch.SendFloat("vol3", vol3);
        pdPatch.SendFloat("vol4", vol4);
        pdPatch.SendFloat("vol5", vol5);
        pdPatch.SendFloat("vol6", vol6);
        pdPatch.SendFloat("vol7", vol7);
        pdPatch.SendFloat("vol8", vol8);

        pdPatch.SendFloat("volume", volume);
        pdPatch.SendFloat("speed_pd", speed);

    }
    void SendBang(string receiver) {
       // Debug.Log("Received a bang from: " + receiver);
    }
    void SendFloat(string receiver, float value) {

    }
}