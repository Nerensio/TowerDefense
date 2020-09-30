using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class WaveSpawners : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float tempsWaves = 5f;

    private float compteARebourd = 2f;

    [SerializeField]
    private Text compteAReboursTimer;

    private int waveIndex = 1;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // vérification du compte à rebourd
        if (compteARebourd <= 0f)
        {
            // vague
            StartCoroutine(SpawnWave());
            compteARebourd = tempsWaves;
        }

        compteARebourd -= Time.deltaTime;
        compteAReboursTimer.text = Mathf.Floor(compteARebourd).ToString();
    }

    // Apparition des ennemis

    // petit délai entre l'apparition d'un ennemi
    IEnumerator SpawnWave()
    {
        Debug.Log("Apparition de la vague");
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();

            // délai en secondes
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Transform obj=Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); 
    
            

    }
}
