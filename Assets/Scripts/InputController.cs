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
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A))
		{
			Debug.Log("A pushed");
			theta += speed;
			translateAxis();
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D))
		{
			Debug.Log("D pushed");
			theta -= speed;
			translateAxis();
		}
	}
	
	void translateAxis ()
	{
		this.transform.position = new Vector3(x + Mathf.Cos(theta), 0, z + r * Mathf.Sin(theta));
	}
}
