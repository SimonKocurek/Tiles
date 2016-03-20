using UnityEngine;

public class BuildingSpawner{

	public enum buildings { fort, house, watchTower, farm };

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
		//ScriptableObject.Instantiate()
	}

	private void spawnHouse() {

	}

	private void spawnWatchTower() {

	}

	private void spawnFarm() {

	}

	// selects tile 
	private void select( Material mat ) {
		inputHandler.clickedTile.GetComponent<Renderer>().material = mat;
		inputHandler.clickedTileObject.selected = true;
	}
}
