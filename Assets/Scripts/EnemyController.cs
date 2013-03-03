using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	[SerializeField]
	public Vector3 targerPosition = new Vector3(1000, 0, 1000);
	[SerializeField]
	public float speedRatio = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		 this.transform.position = Vector3.MoveTowards(this.transform.localPosition, targerPosition, speedRatio);
	}
	
	void OnTriggerEnter (Collider t) {
		if (t.name == "Player" || t.name == "Base")
		{
			Debug.Log ("Triggerd");
			DestroyObject(this.gameObject);
		}
	}
}
