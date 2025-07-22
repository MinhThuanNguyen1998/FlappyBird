using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_PipePrefab;
    [SerializeField] private Transform  m_SpawnPos;
    [SerializeField] private float m_SpawnInterval = 2f;
    [SerializeField] private float m_MinRange = -1f;
    [SerializeField] private float m_MaxRange = 1f;

    private int m_LastCheckedScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, m_SpawnInterval);
    }
    private void Update()
    {
        IncreaseSpawnInterval();
        
    }

    /// <summary>
    /// Spawns a pipe at a random y position
    /// </summary>
    private void SpawnPipe()
    {
       float xPos = m_SpawnPos.position.x;
       Instantiate(m_PipePrefab, new Vector3(xPos, Random.Range(m_MinRange, m_MaxRange), 0), Quaternion.identity);
    }
    /// <summary>
    /// Increases the spawn interval
    /// </summary>
    private void IncreaseSpawnInterval()
    {
       int currentScore = UIManager.Instance.Score;
       if (currentScore == m_LastCheckedScore) return; // No change in score, no need to update
       m_LastCheckedScore = currentScore; // Update the last checked score
     
        // Adjust the spawn interval based on the score
        switch (currentScore)
        {
            case 10:
                UpdateSpawnInterval(3f);
                break;
            case 20:
                UpdateSpawnInterval(2f);
                break;
            default:
                break;
        }
    }

    private void UpdateSpawnInterval(float newInterval)
    {
        //Debug.Log("UpdateSpawnInterval: " + m_SpawnInterval);
        m_SpawnInterval = newInterval;
        CancelInvoke("SpawnPipe");
        InvokeRepeating("SpawnPipe", 0.5f, m_SpawnInterval);
        //Debug.Log("Last Checked Score: " + m_LastCheckedScore);
    }

}
