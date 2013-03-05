using UnityEngine;
using System.Collections;

public class Light : MonoBehaviour {
	[SerializeField]
	public float blank = 1.0f;
	public Color color;
	public int colorIndex = 1;
	public Component lightComponent;

	// Use this for initialization
	void Start () {
		color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
		lightComponent = this.gameObject.GetComponent("Light");
		StartCoroutine(ChangeColor());
	}
	
	void Update () {
		lightComponent.light.color = Color.Lerp(lightComponent.light.color, color, Time.deltaTime);
	}

	IEnumerator ChangeColor () {
		yield return new WaitForSeconds(5.0f);
		Random.seed = (int)Time.time;
		colorIndex = Random.Range(-1, 11);
		colorIndex++;
		switch(colorIndex){
			case 0: color = new Color(1.0f, 0.0f, 0.0f, 1.0f); break;
			case 1: color = new Color(0.0f, 1.0f, 0.0f, 1.0f); break;
			case 2: color = new Color(0.0f, 0.0f, 1.0f, 1.0f); break;
			case 3: color = new Color(1.0f, 1.0f, 0.0f, 1.0f); break;
			case 4: color = new Color(1.0f, 0.0f, 1.0f, 1.0f); break;
			case 5: color = new Color(0.0f, 1.0f, 1.0f, 1.0f); break;
			case 6: color = new Color(0.5f, 0.8f, 1.0f, 1.0f); break;
			case 7: color = new Color(0.8f, 1.0f, 0.5f, 1.0f); break;
			case 8: color = new Color(1.0f, 0.5f, 0.8f, 1.0f); break;
			case 9: color = new Color(0.5f, 1.0f, 0.8f, 1.0f); break;
			case 10: color = new Color(0.8f, 0.5f, 0.8f, 1.0f); break;
			case 11: color = new Color(1.0f, 0.8f, 0.5f, 1.0f); break;
		}
		StartCoroutine(ChangeColor());
		yield break;
		
	}
}
