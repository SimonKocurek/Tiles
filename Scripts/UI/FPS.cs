using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour {

	private Text counter;
	private float fps;

	void Start () {
		counter = GetComponent<Text>();
	}
	
	void Update () {
		fps = 1f / Time.smoothDeltaTime;

		// colors UI if framerate drops too low
		if (fps < 15) {
			counter.color = Color.red;
		} else {
			counter.color = Color.white;
		}

		counter.text = (fps).ToString("00");
	}
}
