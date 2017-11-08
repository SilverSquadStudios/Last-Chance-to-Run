using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour {

	public ObjectPooler SpikePool;

	public void SpawnSpike(Vector2 SpikePosition)
	{
		GameObject Spike = SpikePool.GetPooledObject ();
		Spike.transform.position = SpikePosition;
		Spike.SetActive (true);
	}
}
