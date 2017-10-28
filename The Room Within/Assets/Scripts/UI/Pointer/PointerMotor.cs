using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(AudioSource))]
public class PointerMotor : MonoBehaviour, IPointerEnterHandler {

	private AudioSource buttonHighlight;

	 void Start(){

		buttonHighlight = GetComponent<AudioSource>();
	}

	public virtual void OnPointerEnter(PointerEventData eventData){

		buttonHighlight.Play ();

	}
}
