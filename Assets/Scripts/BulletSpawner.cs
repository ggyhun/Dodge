using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 2f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    
    void Start() {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update() {
        timeAfterSpawn += Time.deltaTime;
        
        if (timeAfterSpawn >= spawnRate) {
            timeAfterSpawn = 0f;
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
