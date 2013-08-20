using UnityEngine;
using System.Collections;

public class Chunk
{
	int width, height, depth;
	Voxel[,,] VXLS;
	public Voxel[,,] voxels {
		get {return VXLS;}
		set {VXLS = value;}
	}

	public Chunk()
	{
		width = 8;
		height = 8;
		depth = 8;
		voxels = new Voxel[width, height, depth];
		BuildChunk();
	}

	public void Update()
	{
		CheckNeighbors();
	}

	private void BuildChunk()
	{
		for(int i = 0; i < width; i++)
		{
			for(int j = 0; j < height; j++)
			{
				for(int k = 0; k < depth; k++)
				{
					byte type = (byte)Random.Range(0, 3);
					voxels[i,j,k] = new Voxel(new Vector3(i,j,k), type);
				}
			}
		}

		CheckNeighbors();
	}

	private void CheckNeighbors()
	{
		for(int i = 0; i < width; i++)
		{
			for(int j = 0; j < height; j++)
			{
				for(int k = 0; k < depth; k++)
				{
					bool setActive = false;
					// Check Left
					if(i != 0)
					{
						if(voxels[i - 1, j, k].type == 0)
						{
							setActive = true;
						}
					}
					else
					{
						setActive = true;
					}
					// Check Right
					if(i < width - 1)
					{
						if(voxels[i + 1, j, k].type == 0)
						{
							setActive = true;
						}
					}
					else
					{
						setActive = true;
					}
					// Check Bottom
					if(j != 0)
					{
						if(voxels[i, j - 1, k].type == 0)
						{
							setActive = true;
						}
					}
					else
					{
						setActive = true;
					}
					// Check Top
					if(j < height - 1)
					{
						if(voxels[i, j + 1, k].type == 0)
						{
							setActive = true;
						}
					}
					else
					{
						setActive = true;
					}
					// Check Front
					if(k != 0)
					{
						if(voxels[i, j, k - 1].type == 0)
						{
							setActive = true;
						}
					}
					else
					{
						setActive = true;
					}
					// Check Back
					if(k < depth - 1)
					{
						if(voxels[i, j, k + 1].type == 0)
						{
							setActive = true;
						}
					}
					else
					{
						setActive = true;
					}

					if(!setActive || voxels[i,j,k].type == 0)
					{
						voxels[i,j,k].isActive(false);
					}
					else
					{
						voxels[i,j,k].isActive(true);
					}
				}
			}
		}
	}
}
