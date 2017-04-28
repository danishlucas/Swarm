using UnityEngine;
using System.Collections;
using System;


public class KillWhenTouched : MonoBehaviour
{

    private int done;
    GameObject room;
    void Start()
    {
        room = gameObject.transform.root.gameObject;
        done = 0;
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().isDashing == true && done == 0)
            {
                done++;
                if (GetComponentInParent<TankEnemyMovement>() != null)
                {
                    GameObject.Find("ScoreObject").GetComponent<Score>().changeScore(3);
                } else if (GetComponentInParent<OmniTurretAI>() != null)
                {
                    GameObject.Find("ScoreObject").GetComponent<Score>().changeScore(1);
                }
                else if (GetComponentInParent<SpiderBossFiring>() != null)
                {
                    GameObject.Find("ScoreObject").GetComponent<Score>().changeScore(10);
                }
                else
                {
                    GameObject.Find("ScoreObject").GetComponent<Score>().changeScore(2);
                }
                gameObject.GetComponent<EnemyAttributes>().tryDropHealth();
                Destroy(gameObject);
                EnemyCounter script = room.GetComponent<EnemyCounter>();
                script.enemyCount -= 1;

            }
        }
    }
}


