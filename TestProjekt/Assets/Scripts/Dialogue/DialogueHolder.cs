using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Dialogue {
public class DialogueHolder : MonoBehaviour
{
    // Start is called before the first frame update
    //float duration = 1.3f;
    //public float intensity;
    //Light first;
    private void Awake() {
        StartCoroutine(dialogueSequence());
        //first = GameObject.Find("Point Light").GetComponent<Light>();
    }
    
    
    private IEnumerator dialogueSequence() {
        for(int i = 0; i < transform.childCount; i++) {
            Deactivate();
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLines>().finished);
        }
        gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
    private void Deactivate() {
        for(int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
}