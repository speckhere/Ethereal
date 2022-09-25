using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;
    public Animator animator;

    private void Start() 
    {
        animator.SetBool ("Clicked", false);
    }

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        animator.SetBool ("Clicked", true);
	}

}
