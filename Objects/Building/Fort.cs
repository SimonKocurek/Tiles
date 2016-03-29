using UnityEngine;

public class Fort : Building {
	public Fort( Vector3 _position, GameObject model, int _x, int _y ) {
		x = _x;
		y = _y;

		gameObject = (GameObject)ScriptableObject.Instantiate(model, new Vector3(_position.x - offset.x, _position.y - offset.y, _position.z - offset.z), new Quaternion());
		//tileObject.transform.SetParent(parent.transform);
		//TileData.hash.Add(tileObject, this);

		select(5);
	}
}
