using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void OnTriggerEnter () {
		var audio = this.GetComponent<AudioSource>();
		audio.Play();
	}
}
