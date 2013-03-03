using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	[SerializeField]
	public float speed = 0.5f;
	public float rotY = 0.0f;
	
	private float rotX = 0.0f;
	private bool plus = true;

	// Use this for initialization
	void Start () {
		rotX = this.transform.localEulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
		Random.seed = (int)(Time.time*Time.deltaTime);
		plus = (Random.Range(0,100) >= 90) ? !plus : plus;
		rotY = (plus) ? rotY+speed : rotY-speed;
		this.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
	}
}
