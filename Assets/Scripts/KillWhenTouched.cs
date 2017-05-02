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
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc == null)
                pc = other.GetComponent<PCPlayerController>();
            if (pc.isDashing == true && done == 0)
            {
                float pointsMult = other.GetComponent<Attributes>().pointsMult;
                done++;
                if (GetComponentInParent<TankEnemyMovement>() != null)
                {
                    GameObject.Find("ScoreObject").GetComponent<Score>().changeScore(10 * pointsMult);
                } else if (GetComponentInParent<OmniTurretAI>() != null)
                {
                    GameObject.Find("ScoreObject").GetComponent<Score>().changeScore(4 * pointsMult);
                }            
                else
                {
                    GameObject.Find("ScoreObject").GetComponent<Score>().changeScore(6 * pointsMult);
                }
                gameObject.GetComponent<EnemyAttributes>().tryDropHealth();
                Destroy(gameObject);
                EnemyCounter script = room.GetComponent<EnemyCounter>();
                script.enemyCount -= 1;

            }
        }
    }
}


