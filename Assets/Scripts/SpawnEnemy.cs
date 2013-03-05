using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
	[SerializeField]
	public GameObject enemyPrefab = null;
	[SerializeField]
	public GameObject target = null;

	public Vector3[] spawnPosition = {
		new Vector3(10f, 0.01f, 25f),
		new Vector3(-10f, 0.01f, 25f),
		new Vector3(10f, 0.01f, -25f),
		new Vector3(-10f, 0.01f, -25f),
		new Vector3(25f, 0.01f, 10f),
		new Vector3(-25f, 0.01f, 10f),
		new Vector3(25f, 0.01f, -10f),
		new Vector3(-25f, 0.01f, -10f)
	};
	// Use this for initialization
	void Start () {
		StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	IEnumerator Spawn () {
		Random.seed = (int)(Time.time*Time.deltaTime*1000);
		yield return new WaitForSeconds(Random.value*3f+0.4f);
		Random.seed = (int)(Time.time*Time.deltaTime*1000);
		Debug.Log("Time.time:" + Time.time);
		Debug.Log("Random.value:" +Random.value);
		Debug.Log("Random.seed" + Random.seed);
		var index = Random.Range(0,8);
		index %= 8;
		var position = spawnPosition[index] + new Vector3(1000f, 0f, 1000f);

		var enemy = GameObject.Instantiate(enemyPrefab) as GameObject;
		enemy.gameObject.transform.position = position;
		var targetDir = target.transform.position - enemy.gameObject.transform.position;
		bool forward = (targetDir.z >= 0) ? true : false;
		var angleY = 0.0f;
		Quaternion rotation = new Quaternion();
		if (forward) {
			angleY =Vector3.Angle(targetDir, -enemy.gameObject.transform.right);
			rotation = Quaternion.Euler(90f, angleY-90f, 0f);
		} else {
			angleY =Vector3.Angle(targetDir, enemy.gameObject.transform.right);
			rotation = Quaternion.Euler(90f, angleY+90f, 0f);
		}
		enemy.gameObject.transform.rotation = rotation;

		StartCoroutine_Auto(Spawn());
	}
}
