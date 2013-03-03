using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	[SerializeField]
	public float speed = 0.5f;
	public float rotY = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rotY += speed;
		this.transform.rotation = Quaternion.Euler(90, rotY, 0);
	}
}
