using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Level01StoryTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public PlayerController playerController;
	public Animator playerAnim;





	public void TriggerDialogue()
	{


		FindObjectOfType<_Level01DialogueManager> ().StartDialogue (dialogue);
		playerController.canMove = true;
		playerAnim.SetFloat ("Speed", 0.0f);

	}
}
