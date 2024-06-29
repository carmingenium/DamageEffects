using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGenerator : MonoBehaviour
{
    public GameObject enemy;
    public EnemyStats enemyStats;
    public GameObject player;
    public PlayerStats playerStats;

    private Vector3 spawnPoint;
    [SerializeField] private Vector3 destinationPoint;

    [SerializeField] private GameObject canvas;
    [SerializeField] private List<GameObject> texts;
    public void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        enemyStats = enemy.GetComponent<EnemyStats>();
    }
    private int TiltCalculator()
    {
        // There are 3 tilt positions, -15 degrees, 0 degrees, 15 degrees
        int tilt = Random.Range(0, 3);
        return tilt - 1;
    }
    private void DamageTextGenerator(float dmg, int index)
    {
        GameObject text = Instantiate(texts[index], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + dmg.ToString();
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText);
    }

    #region Damage Enemy Functions
    public void DealDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(120, 150);
        enemyStats.TakeDamage(damage);
        DamageTextGenerator(damage, 0);
    }
    public void DealCritDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(240, 300);
        enemyStats.TakeDamage(damage);
        DamageTextGenerator(damage, 1);
    }
    public void SuperDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(240, 300);
        enemyStats.TakeDamage(damage);
        DamageTextGenerator(damage, 2);
        // display super text
        StartCoroutine(SuperTextSpawn(0.33f));
    }
    public void SuperCritDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(240, 300);
        enemyStats.TakeDamage(damage);
        DamageTextGenerator(damage, 3);
        // display super text
        StartCoroutine(SuperTextSpawn(0.33f));
    }
    public void WeakDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(10, 20);
        enemyStats.TakeDamage(damage);
        DamageTextGenerator(damage, 4);
        // display weak text
        StartCoroutine(WeakTextSpawn(0.33f));
    }
    public void PoisonDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(20, 35);
        enemyStats.TakeDamage(damage);
        DamageTextGenerator(damage, 5);
    }
    #endregion
    #region Player Functions
    public void TakeDamage()
    {
        spawnPoint = player.transform.position;
        float damage = Random.Range(500, 600);
        playerStats.TakeDamage(damage);
        DamageTextGenerator(damage, 8);
    }
    public void Heal()
    {
        spawnPoint = player.transform.position;
        float healAmount = Random.Range(200, 250);
        playerStats.Heal(healAmount);
        GameObject text = Instantiate(texts[9], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "+" + healAmount.ToString();
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText);
    }
    public void Revive()
    {
        playerStats.Revive();
    }
    #endregion
    #region Image Spawners
    IEnumerator WeakTextSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject weakText = Instantiate(texts[6], spawnPoint - new Vector3(0,1f,0), Quaternion.identity, canvas.transform);
        weakText.GetComponent<textHandler>().SetupImage(spawnPoint + destinationPoint - new Vector3(0, 1, 0), "weak");
    }
    IEnumerator SuperTextSpawn(float time)
    {
        // first spawn white bg, then text.
        yield return new WaitForSeconds(time);
        GameObject whiteBG = Instantiate(texts[10], spawnPoint, Quaternion.identity, canvas.transform);
        whiteBG.GetComponent<textHandler>().SetupImage(spawnPoint, "whiteBG");
        yield return new WaitForSeconds(0.05f);
        GameObject superText = Instantiate(texts[7], spawnPoint, Quaternion.identity, canvas.transform);
        superText.GetComponent<textHandler>().SetupImage(spawnPoint - new Vector3(0, 0.5f, 0), "super");
    }
    #endregion
}
