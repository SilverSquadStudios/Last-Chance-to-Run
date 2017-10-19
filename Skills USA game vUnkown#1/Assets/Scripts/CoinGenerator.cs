using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool;

	private float RandomNumber;
	private float RandomNumberInside;

	public float DistanceBetweenCoins;

	public void SpawnCoins(Vector2 startPosition)
	{
		RandomNumber = Random.Range (1, 4);
		for(float i=RandomNumber; i>0; i--)
		{
			RandomNumberInside = Random.Range (1, 4);
			if (RandomNumberInside == 1) {
				GameObject Coin1 = coinPool.GetPooledObject ();
				Coin1.transform.position = startPosition;
				Coin1.SetActive (true);
			}
			if (RandomNumberInside == 2) {
				GameObject Coin2 = coinPool.GetPooledObject ();
				Coin2.transform.position = new Vector2 (startPosition.x - DistanceBetweenCoins, startPosition.y);
				Coin2.SetActive (true);
			}
			if (RandomNumberInside == 3) {
				GameObject Coin3 = coinPool.GetPooledObject ();
				Coin3.transform.position = new Vector2 (startPosition.x + DistanceBetweenCoins, startPosition.y);
				Coin3.SetActive (true);
			}
		}
	}
}
