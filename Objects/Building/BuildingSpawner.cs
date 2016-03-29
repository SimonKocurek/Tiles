using UnityEngine;

public class BuildingSpawner{

	public enum buildings { fort, house, watchTower, farm };

	private ScoreHandler scoreHandler;
	private InputHandler inputHandler;
	private Material selectionMaterial;
	private int id;

	private static GameObject fortModel = Resources.Load("Fort") as GameObject;
	private static GameObject towerModel = Resources.Load("Tower") as GameObject;

	public BuildingSpawner(ScoreHandler _scoreHandler, InputHandler _inputHandler, Material _selectionMaterial, int _id) {
		scoreHandler = _scoreHandler;
		inputHandler = _inputHandler;
		selectionMaterial = _selectionMaterial;
		id = _id; 
	}

	// spawns building of input type
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
		TopTile tile = (TopTile)TileData.hash[inputHandler.clickedTile];
		if (tile.ownerId == -1) {
			Fort fort = new Fort(tile.tileObject.transform.position, fortModel, tile.x, tile.y);
			selectTeritory(fort);
		}
	}

	private void spawnHouse() {
		TopTile tile = (TopTile)TileData.hash[inputHandler.clickedTile];
		if (tile.ownerId == id) {
			Tower tower = new Tower(tile.tileObject.transform.position, towerModel, tile.x, tile.y);
			selectTeritory(tower);
		}
	}

	private void spawnWatchTower() {
		// TODO move house function insides here once you start implementing the rest of the buildings
	}

	private void spawnFarm() {
		
	}

	// selects all tiles belonging to building
	private void selectTeritory(Building building) {
		for (int i = 0; i < building.ownedCount; i ++) {
			select(building.ownedTiles[i]);
		}
	}

	// selects tile 
	private void select(TopTile tileData ) {
		scoreHandler.score += 15;
		tileData.ownerId = id;

		tileData.tileObject.GetComponent<Renderer>().material = selectionMaterial;
	}
}
