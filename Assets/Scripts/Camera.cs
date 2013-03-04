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
		StartCoroutine(ChangeRotation());
	}
	
	// Update is called once per frame
	void Update () {
		rotY = (plus) ? rotY+speed : rotY-speed;
		this.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
	}
	
	IEnumerator ChangeRotation () {
		yield return new WaitForSeconds(10f);
		Random.seed = (int)(Time.time*Time.deltaTime*1000);
		plus = (Random.Range(0,2) == 0) ? !plus : plus;
		StartCoroutine(ChangeRotation());
		yield break;
	}
}
