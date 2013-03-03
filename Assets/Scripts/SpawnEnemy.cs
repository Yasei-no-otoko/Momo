using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
	[SerializeField]
	public GameObject enemyPrefab = null;
	
	public Vector3[] spawnPosition = {
		new Vector3(10f, 0.01f, 25f),
		new Vector3(-10f, 0.01f, 25f),
		new Vector3(10f, 0.01f, -25f),
		new Vector3(-10f, 0.01f, 25f),
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
		yield return new WaitForSeconds(Random.value+0.3f);
		Random.seed = (int)(Time.time*Time.deltaTime*1000);
		Debug.Log("Time.time:" + Time.time);
		Debug.Log("Random.value:" +Random.value);
		Debug.Log("Random.seed" + Random.seed);
		var index = Random.Range(0,7);
		var position = spawnPosition[index] + new Vector3(1000f, 0f, 1000f);
		var rotation = Quaternion.Euler(0f,0f,0f);
		
		GameObject enemy = GameObject.Instantiate(enemyPrefab, position, rotation) as GameObject;
		StartCoroutine_Auto(Spawn());
	}
}
