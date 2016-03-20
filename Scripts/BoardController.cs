using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

	// parameters
	[Range(1,50)] public int tilesX;
	[Range(1,50)] public int tilesY;
	[Range(1,20)] public int maxHeight;
	[Range(1,5)] public int smoothness;

	// constant
	[HideInInspector]public Vector3 tileSize = new Vector3(1.075f, 0.95f, 0.35f);
	
	void Start () {
		// get board data
		TileHash.hash = new Hashtable();
		Board board = new Board(tilesX, tilesY, tileSize, maxHeight, smoothness);
		
		// index islands
		IslandGenerator islandGenerator = new IslandGenerator(board.topTile, tilesX, tilesY);
		islandGenerator.generate();
	}
}
