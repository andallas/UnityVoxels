using UnityEngine;
using System.Collections;

public class Voxel
{
	Vector3 position;
	VoxelMesh mesh;
	private byte Type;
	public byte type {
		get { return Type;}
		set { Type = value;}
	}

	public Voxel(Vector3 pos, byte t)
	{
		position = pos;
		type = t;
		mesh = new VoxelMesh(position, type);
	}

	public void isActive(bool value)
	{
		mesh.gameObject.SetActive(value);
	}
}
