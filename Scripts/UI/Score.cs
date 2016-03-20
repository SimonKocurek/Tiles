using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Text text;

	private float sizeChange;
	private int lastScore;

	private float timer = 0f;

	private ScoreHandler scoreHandler;

	void Start () {
		text = GetComponent<Text>();
		sizeChange = 1f;
		lastScore = 0;

		scoreHandler = GameObject.Find("Player").GetComponent<PlayerControls>().scoreHandler;
	}
	
	void Update () {
		// change size on increased score
		if (scoreHandler.score != lastScore) {
			sizeChange = 1.25f;
		} else if ( sizeChange > 1f) {
			sizeChange = Mathf.Max(sizeChange - Time.deltaTime * 0.25f, 1f);
		}

		// save last score
		lastScore = scoreHandler.score;
		tick();

		// update score UI
		text.text = scoreHandler.score.ToString();
		transform.localScale = new Vector3( sizeChange, sizeChange, sizeChange);
	}

	// add score every second
	private void tick() {
		if ( GamePhase.phase == GamePhase.phases.play) {
			timer += Time.deltaTime;

			if (timer > 5f) {
				scoreHandler.score += 1;
				lastScore += 1;
				timer -= 5f;
			}
		}
	}
}
