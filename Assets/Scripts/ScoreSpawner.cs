using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpawner : MonoBehaviour
{
    [SerializeField] GameObject scorePrefab;

    [SerializeField] Transform[] spawnPoints;

    [SerializeField] Transform player;

    public void SpawnScoree()
    {
        var score = Instantiate(scorePrefab, transform.position, Quaternion.identity);
        
        Transform choosenTransform;
        while (true)
        {
            choosenTransform = spawnPoints[Random.Range(0,spawnPoints.Length)];
            if(Mathf.Abs(Vector3.Distance(choosenTransform.position, player.position)) >= .5f)
            {
                break;
            }
        }

        score.transform.position = choosenTransform.position;
    }

}
