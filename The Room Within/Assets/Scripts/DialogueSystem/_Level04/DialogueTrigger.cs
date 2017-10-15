using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public PlayerController playerController;



	public void TriggerDialogue()
	{

		FindObjectOfType<DialogueManagerVer2> ().StartDialogue (dialogue);
		playerController.canMove = true;

	}
}
