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
    public void DealDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(120, 150);
        enemyStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[0], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText , true);
    }
    public void DealCritDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(240, 300);
        enemyStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[1], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString() + "!";
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText , true);
    }
    public void SuperDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(240, 300);
        enemyStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[2], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText, true);
        // display super text
        StartCoroutine(SecondTextSpawn(0.3f, 7));
    }
    public void SuperCritDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(240, 300);
        enemyStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[3], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString() + "!";
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText, true);
        // display super text
        StartCoroutine(SecondTextSpawn(0.3f, 7));
    }
    public void WeakDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(10, 20);
        enemyStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[4], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText, true);
        // display weak text
        StartCoroutine(SecondTextSpawn(0.3f, 6));
    }
    public void PoisonDamage()
    {
        spawnPoint = enemy.transform.position;
        float damage = Random.Range(20, 35);
        enemyStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[5], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText , true);
    }
    public void TakeDamage()
    {
        spawnPoint = player.transform.position;
        float damage = Random.Range(500, 600);
        playerStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[8], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText , true);
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
        text.GetComponent<textHandler>().Setup(spawnPoint + destinationPoint, finalText , true);
    }
    public void Revive()
    {
        playerStats.Revive();
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
    IEnumerator SecondTextSpawn(float time, int index)
    {
        yield return new WaitForSeconds(time);
        GameObject secondText = Instantiate(texts[index], spawnPoint, Quaternion.identity, canvas.transform);
        secondText.GetComponent<textHandler>().SetupImage(spawnPoint + destinationPoint, false);
    }
}
