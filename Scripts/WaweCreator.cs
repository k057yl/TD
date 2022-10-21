using System.Collections;
using UnityEngine;

public class WaweCreator : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] GameObject spawn;
    [SerializeField] int maxEnemyOnScene;
    [SerializeField] int totalEnemy;
    [SerializeField] int maxSpawnEnemy;
    int enemyOnScreen = 0;
    const float spawnD = 1f;
    private void Start()
    {
        StartCoroutine(OnClick());
    }
    public IEnumerator OnClick()
    {
        if(maxSpawnEnemy > 0 && enemyOnScreen < totalEnemy)
        {
            for(int i = 0; i < maxSpawnEnemy; i++)
            {
                if(enemyOnScreen < maxEnemyOnScene)
                {
                    GameObject newEnemy = Instantiate(enemyPrefab[1]) as GameObject;
                    newEnemy.transform.position = spawn.transform.position;
                    enemyOnScreen++;
                }
            }
            yield return new WaitForSeconds(spawnD);
            StartCoroutine(OnClick());
        }
        //Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
