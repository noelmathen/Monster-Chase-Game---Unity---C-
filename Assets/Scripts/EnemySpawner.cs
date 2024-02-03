using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;

    private int randomMonsterIndex, randomSide;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMonsters());

    }

    IEnumerator spawnMonsters()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0,5));

            randomMonsterIndex = Random.Range(0,monsterReference.Length);
            randomSide = Random.Range(0,2);

            spawnedMonster = Instantiate(monsterReference[randomMonsterIndex]);

            if(randomSide == 1)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4,10);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4,10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
