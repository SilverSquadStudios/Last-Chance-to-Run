using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool;

	public float DistanceBetweenCoins;

	public void SpawnCoins(Vector2 startPosition)
	{
		GameObject Coin1=coinPool.GetPooledObject();
		Coin1.transform.position=startPosition;
		Coin1.SetActive(true);

		GameObject Coin2=coinPool.GetPooledObject();
		Coin2.transform.position= new Vector2 (startPosition.x-DistanceBetweenCoins,startPosition.y);
		Coin2.SetActive(true);

		GameObject Coin3=coinPool.GetPooledObject();
		Coin3.transform.position = new Vector2 (startPosition.x + DistanceBetweenCoins, startPosition.y);
		Coin3.SetActive(true);
	}
}
