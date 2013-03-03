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
	}
	
	void Update () {
		if ((int)Time.time%5 == 0) {
			colorIndex++;
			colorIndex %= 6;
			switch(colorIndex){
				case 0: color = new Color(1.0f, 0.0f, 0.0f, 1.0f); break;
				case 1: color = new Color(0.0f, 1.0f, 0.0f, 1.0f); break;
				case 2: color = new Color(0.0f, 0.0f, 1.0f, 1.0f); break;
				case 3: color = new Color(1.0f, 1.0f, 0.0f, 1.0f); break;
				case 4: color = new Color(1.0f, 0.0f, 1.0f, 1.0f); break;
				case 5: color = new Color(0.0f, 1.0f, 1.0f, 1.0f); break;
			}
		}
		lightComponent.light.color = Color.Lerp(lightComponent.light.color, color, Time.deltaTime);
	}
}