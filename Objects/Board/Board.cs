using UnityEngine;

public class Board {

	// result
	public Tile[,,] botTile;
	public TopTile[,] topTile;

	// dimensions
	private static int lengthX;
	private static int lengthY;

	public Board(int tilesX, int tilesY, Vector3 size, int maxHeight, int smoothness) {
		lengthX = tilesX;
		lengthY = tilesY;

		// get heightmap data
		HeightMap heightMap = new HeightMap(lengthX, lengthY, maxHeight);
		heightMap.smooth( smoothness);

		// map offset for centering
		Vector3 start = new Vector3( -lengthX * size.x / 2, 0, -lengthY * size.y / 2);

		// inicialize Tile arrays
		botTile = new Tile[lengthX, lengthY, maxHeight];
		topTile = new TopTile[lengthX, lengthY];

		// cache data of each tile
		GameObject tileModel = Resources.Load("Tile") as GameObject;
		GameObject TopTileModel = Resources.Load("TopTile") as GameObject;
		GameObject parent = GameObject.Find("Tiles");
		int waterHeightLevel = GameObject.Find("Water").GetComponent<WaterController>().waterHeightLevel;

		for (int x = 0; x < lengthX; x ++) {
			for (int y = 0; y < lengthY; y ++) {

				// cache height
				int height = heightMap.height[x, y];
				int lowestNeighbour = heightMap.lowestNeighbour(x, y) + 1;

				// exclude not visible tiles
				if ( lowestNeighbour > height) {
					lowestNeighbour = height;
				}

				for (int z = lowestNeighbour; z <= height; z ++) {
					// create tiles
					if (z < height || z < waterHeightLevel) {
						botTile[x,y,z] = new BotTile(new Vector3(start.x + x * size.x - (size.x / 2) * (y % 2), z * size.z, start.z + y * size.y), x, y, z, tileModel, parent, waterHeightLevel);
					} else {
						topTile[x,y] = new TopTile(new Vector3(start.x + x * size.x - (size.x / 2) * (y % 2), z * size.z, start.z + y * size.y), x, y, z, TopTileModel, parent);
					}
				}

			}
		}

		// move ocean to tile
		GameObject.Find("Ocean").transform.position = new Vector3(0, heightMap.lowestHeigh() * size.z, 0);
	}
}
