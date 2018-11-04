using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceToNextDialogue : MonoBehaviour {

    [SerializeField]
    private DialogueManager dm;

    private void Update()
    {
        if (gameObject.activeInHierarchy && 
            Input.GetKeyDown(KeyCode.X) && dm.IsTalking)
        {
            // Moving to the next script;
            dm.ContinueConversation();
        }
    }
}
