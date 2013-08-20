using UnityEngine;
using System.Collections;

public class WorldGen : MonoBehaviour
{
	Chunk CHNK;
	public Chunk chunk {
		get {return CHNK;}
		set {CHNK = value;}
	}
	public string test = "Hello World!";

	void Start()
	{
		chunk = new Chunk();
	}

	void Update()
	{
		chunk.Update();
	}
}