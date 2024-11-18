using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public List<GameObject> powerupPrefabs;
    [SerializeField]
    private float spawntime;
    [SerializeField]
    private float lifeTime;
    public Transform upperBound;
    public Transform lowerBound;
    public Transform Player;
    public float offsetFromPlayer;

    private Coroutine previous;
    private void Start()
    {
        StartCoroutine(LoopedSpawning());
    }

    IEnumerator LoopedSpawning()
    {
        yield return new WaitForSeconds(spawntime);

        int indexvalue = Random.Range(0, powerupPrefabs.Count);
        GameObject powerup = Instantiate(powerupPrefabs[indexvalue], transform);
        powerup.transform.position = new Vector2(Player.transform.position.x + offsetFromPlayer, RandomizeYposition());

        yield return new WaitForSeconds(lifeTime);
        Destroy(powerup);
        StartCoroutine(LoopedSpawning());
    }
    private float RandomizeYposition()
    {
        float yvalue = Random.Range(lowerBound.position.y, upperBound.position.y);
        return yvalue;
    }
}
