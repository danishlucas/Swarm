using UnityEngine;



public class EnemyCounter : MonoBehaviour
{
    public int enemyCount;
    private int timesPlayed;

    void Start()
    {
        timesPlayed = 0;
    }

    void Update()
    {
        if (enemyCount == 0 & timesPlayed == 0)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            timesPlayed++;
        }
    }
}