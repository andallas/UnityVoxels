using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	WorldGen world;

	void Start()
	{
		world = (WorldGen)GameObject.Find("World").GetComponent(typeof(WorldGen));
	}
	
	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				BreakBlock(BlockAtPoint(hit.point));
			}
		}
	}

	Voxel BlockAtPoint(Vector3 point)
	{
		Debug.Log("X: " + FloatToInt(point.x) + " Y: " + FloatToInt(point.y) + " Z: " + FloatToInt(point.z));
		return world.chunk.voxels[FloatToInt(point.x),FloatToInt(point.y),FloatToInt(point.z)];
	}

	void BreakBlock(Voxel block)
	{
		block.type = 0;
	}

	int FloatToInt(float value)
	{
		float dec =  (int)value - value;
		if(dec < 0.5)
		{
			float num = value - dec;
			return (int)num;
		}
		else
		{
			return (int)value;
		}
	}
}
