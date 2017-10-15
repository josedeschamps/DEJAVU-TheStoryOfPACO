using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StoryDialogue : MonoBehaviour {


	public string playerName;
	[TextArea(3,10)]
	public string[] sentences;


}
