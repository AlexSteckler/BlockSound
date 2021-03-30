using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor; 

namespace Dialogue {
    public class DialogueLines : DialogueBase
    {
        // Start is called before the first frame update
        
        private Text textholder;
        [Header (" Text Options")] 
        [SerializeField] private string input; 
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont; 
        [SerializeField] private float delay;

        private void Awake() {
            textholder = GetComponent<Text>(); 
            textholder.text = "";
            
        }
        private void Start() {
            StartCoroutine(WriteText(input, textholder, textColor, textFont, delay));
        }
    }
}
