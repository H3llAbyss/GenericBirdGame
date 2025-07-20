using System;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float randomnessScale = 1;
    public float spawnPeriod = 1;
    public GameObject pipe;
    public LogicScript logic;

    private TimeSpan _spawnPeriodInternal;
    private TimeSpan _timer;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        _timer = TimeSpan.Zero;
        _spawnPeriodInternal = TimeSpan.FromSeconds(spawnPeriod);
    }

    void Update()
    {
        _timer += TimeSpan.FromSeconds(Time.deltaTime);
        if (_timer > _spawnPeriodInternal)
        {
            SpawnPipe();
            _timer = TimeSpan.Zero;
        }
    }

    void SpawnPipe()
    {
        if (!logic.IsAlive)
        {
            return;
        }
        Instantiate(pipe, position: new Vector3(transform.position.x, transform.position.y + (UnityEngine.Random.value - 0.5f) * randomnessScale), transform.rotation);
    }
}
