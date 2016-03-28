using UnityEngine;

public class BuildingSpawner{

	public enum buildings { fort, house, watchTower, farm };

	private ScoreHandler scoreHandler;
	private InputHandler inputHandler;
	private Material selectionMaterial;

	public BuildingSpawner(ScoreHandler _scoreHandler, InputHandler _inputHandler, Material _selectionMaterial) {
		scoreHandler = _scoreHandler;
		inputHandler = _inputHandler;
		selectionMaterial = _selectionMaterial;
	}

	public void spawn( buildings building) {
		
		switch (building) {
			case buildings.fort:
				spawnFort();
				break;

			case buildings.house:
				spawnHouse();
				break;

			case buildings.watchTower:
				spawnWatchTower();
				break;

			case buildings.farm:
				spawnFarm();
				break;
		}
	}

	private void spawnFort() {
		if (!inputHandler.clickedTileObject.playerTeritory) {
			//ScriptableObject.Instantiate()
			select(inputHandler.clickedTile, inputHandler.clickedTileObject);
		}
	}

	private void spawnHouse() {
		if (!inputHandler.clickedTileObject.playerTeritory) {
			select(inputHandler.clickedTile, inputHandler.clickedTileObject);
		}
	}

	private void spawnWatchTower() {
		if (!inputHandler.clickedTileObject.playerTeritory) {
			select(inputHandler.clickedTile, inputHandler.clickedTileObject);
		}
	}

	private void spawnFarm() {
		if (!inputHandler.clickedTileObject.playerTeritory) {
			select(inputHandler.clickedTile, inputHandler.clickedTileObject);
		}
	}

	// selects tile 
	private void select( GameObject tileObject, TopTile tileData ) {
		scoreHandler.score += 15;
		tileData.playerTeritory = true;

		tileObject.GetComponent<Renderer>().material = selectionMaterial;
	}
}
