using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingPlatform : MonoBehaviour {

	public GameObject Platform;
	public Transform Point;
	private float Distance;
	private float PWidth;
	public float DBmin;
	public float DBmax;

	private float ymax;
	private float ymin;
	private float ChangeY;
	public Transform maxYPoint;
	public float maxYChange;

	public ObjectPooler TheObjectPool;


	private CoinGenerator TheCoinGenerator;
	public float RandomCoinThreshold;

	private SpikeGenerator TheSpikeGenerator;
	public float ChanceToSpawnSpike;

	private PowerUpGenerator ThePowerUpGenerator;
	public float ChanceToSpawnSlowDownPowerUp;

	private HealthGenerator TheHealthgenerator;
	public float ChanceToSpawnAHeart;

	void Start () 
	{
		PWidth = Platform.GetComponent<BoxCollider2D>().size.x;
		ymin = transform.position.y;
		ymax = maxYPoint.position.y;
		TheCoinGenerator = FindObjectOfType<CoinGenerator> ();
		TheSpikeGenerator = FindObjectOfType<SpikeGenerator> ();
		ThePowerUpGenerator = FindObjectOfType<PowerUpGenerator> ();
		TheHealthgenerator = FindObjectOfType<HealthGenerator> ();
	}


	void Update () 
	{
		if(transform.position.x < Point.position.x)
		{
			Distance = Random.Range (DBmin, DBmax);
			ChangeY = transform.position.y + Random.Range (ymax, -ymax);
			if (ChangeY > ymax) {
				ChangeY = ymax;
			} else if (ChangeY < ymin)
			{
				ChangeY = ymin;
			}


			transform.position = new Vector3 (transform.position.x + PWidth + Distance, ChangeY, transform.position.z);
			GameObject newPlatform = TheObjectPool.GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			if (Random.Range (0f, 100f) < RandomCoinThreshold)
			{
				TheCoinGenerator.SpawnCoins (new Vector2 (transform.position.x, transform.position.y +.5f));
			}

			else if (Random.Range (0f, 100f) < ChanceToSpawnSpike) 
			{
				TheSpikeGenerator.SpawnSpike(new Vector2 (transform.position.x, transform.position.y));

			}
			else if (Random.Range (0f, 100f) < ChanceToSpawnSlowDownPowerUp) 
			{
				ThePowerUpGenerator.SpawnSlowDown(new Vector2 (transform.position.x+ Random.Range (-PWidth, PWidth), transform.position.y+ 1f));

			}
			else if (Random.Range (0f, 100f) < ChanceToSpawnAHeart) 
			{
				TheHealthgenerator.SpawnLife(new Vector2 (transform.position.x+ Random.Range (-PWidth, PWidth), transform.position.y+ 1f));

			}
		}  
	}
}