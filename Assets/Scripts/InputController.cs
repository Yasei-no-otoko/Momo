using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	[SerializeField]
	public float r = 10.0f;
	[SerializeField]
	public float theta = 0.0f;
	[SerializeField]
	public float x = 0.0f;
	[SerializeField]
	public float z = 0.0f;
	[SerializeField]
	public float speed = 0.01f;

	// Use this for initialization
	void Start () {
		x = this.transform.position.x;
		z = this.transform.position.z;
		translateAxis();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Debug.Log("A pushed");
			theta += speed;
			this.transform.position = new Vector3 (x + r * Mathf.Cos(theta), 0, z + r * Mathf.Sin(theta));
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			Debug.Log("D pushed");
			theta -= speed;
			this.transform.position = new Vector3(x + r * Mathf.Cos(theta), 0, z + r * Mathf.Sin(theta));
		}
	}

	void translateAxis ()
	{
		this.transform.position = new Vector3(x + r * Mathf.Cos(theta), 0, z + r * Mathf.Sin(theta));
	}

	void OnTriggerEnter ()
	{
		var audio = this.GetComponent<AudioSource>();
		audio.Play();
	}
}
