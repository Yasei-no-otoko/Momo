using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	[SerializeField]
	public float speed = 0.5f;
	public float rotY = 0.0f;

	private float rotX = 0.0f;
	private bool plus = true;
	private bool flag = false;

	// Use this for initialization
	void Start () {
		rotX = this.transform.localEulerAngles.x;
		StartCoroutine(ChangeRotation());
		StartCoroutine(SpeedUp());
	}

	// Update is called once per frame
	void Update () {
		rotY = (plus) ? rotY+speed : rotY-speed;
		this.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
	}

	IEnumerator ChangeRotation () {
		Random.seed = (int)(Time.time*Time.deltaTime*1000);
		yield return new WaitForSeconds(Random.value*5f+3f);
		plus = (Random.Range(0,2) == 0) ? !plus : plus;
		StartCoroutine(ChangeRotation());
		yield break;
	}

	IEnumerator SpeedUp () {
		Random.seed = (int)(Time.time*Time.deltaTime*1000);
		yield return new WaitForSeconds((float)Random.Range(5, 10));
		flag = (Random.Range(0,2) == 0) ? true : false;
		if (flag) speed *= 3;
		yield return new WaitForSeconds(Random.value+0.5f);
		if (flag) speed /= 3;
		StartCoroutine(SpeedUp());
		yield break;
	}
}
