using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=8eJ_gxkYsyY&t=857s <-Tutorial für die Cutscene
namespace Dialogue {
    public class DialogueBase : MonoBehaviour
    {
        // Start is called before the first frame update
        public bool finished {get; private set;}
        
        protected IEnumerator WriteText(string input, Text textholder, Color textColor, Font textFont, float delay) {
        
           textholder.color = textColor;
           textholder.font = textFont; 

            for(int i = 0; i < input.Length; i++) {
                textholder.text += input[i];
                yield return new WaitForSeconds(delay);
                
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            finished = true;
            
        }
        
    }
}