using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public static Respawn instance;
    private Vector3 respawnPoint;
    public float spawnTime;
    private GameObject player;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = PlayerHp.instance.gameObject;
        respawnPoint = player.transform.position;
    }

    public void SetCheckpoint(Vector3 transform)
    {
        respawnPoint = transform;
    }

    public void Respawning()
    {
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(spawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.transform.position = respawnPoint;
        player.SetActive(true);
        PlayerHp.instance.FullHealth();
    }
}
