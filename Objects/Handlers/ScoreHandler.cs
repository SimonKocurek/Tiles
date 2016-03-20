public class ScoreHandler {

	public int score;

	public ScoreHandler() {
		score = 0;
	}

	public void addSecondScore() {
		score += 5;
	}

	public void add(int points) {
		score += points;
	}
}
