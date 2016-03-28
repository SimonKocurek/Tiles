public class GamePhase {

	public enum phases { start, play};
	public static phases phase;

	public static float phaseChangeTime = 0f;

	private static int playerId = 0;
	// returns Id of current player and increments it 
	public static int getPlayerId() {
		playerId++;
		return playerId;
	}
}
