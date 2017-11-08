using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGenerator : MonoBehaviour
{
	public ObjectPooler HealthPool;

	public void SpawnLife(Vector2 HealthPosition)
	{
		GameObject Life = HealthPool.GetPooledObject ();
		Life.transform.position = HealthPosition;
		Life.SetActive (true);
	}

}
