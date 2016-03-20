using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private Text text;

	void Start () {
		text = GetComponent<Text>();
	}
	
	void Update () {
		// start only when player chose fort position
		if (GamePhase.phase == GamePhase.phases.play) {

			float gameTime = Time.realtimeSinceStartup - GamePhase.phaseChangeTime;
			text.text = Mathf.CeilToInt(gameTime / 60 - 1).ToString("00") + ":" +
				Mathf.CeilToInt(gameTime % 60).ToString("00");
		}
	}
}
