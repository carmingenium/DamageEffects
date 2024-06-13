using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject player;
    public PlayerStats playerStats;

    private Vector3 spawnPoint;
    [SerializeField] private Vector3 destinationPoint;

    [SerializeField] private GameObject canvas;
    [SerializeField] private List<GameObject> texts;
    public void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        spawnPoint = player.transform.position;
    }
    private int TiltCalculator()
    {
        // There are 3 tilt positions, -15 degrees, 0 degrees, 15 degrees
        int tilt = Random.Range(0, 3);
        return tilt - 1;
    }
    public void DealDamage()
    {
        float damage = Random.Range(120, 150);
        playerStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[0], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
    }
    public void DealCritDamage()
    {
        float damage = Random.Range(240, 300);
        playerStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[1], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString() + "!";
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
    }
    public void SuperDamage()
    {
        float damage = Random.Range(240, 300);
        playerStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[2], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
        // display super text
    }
    public void SuperCritDamage()
    {
        float damage = Random.Range(240, 300);
        playerStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[3], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString() + "!";
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
        // display super text
    }
    public void WeakDamage()
    {
        float damage = Random.Range(10, 20);
        playerStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[4], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
        // display super text
    }
    public void PoisonDamage()
    {
        float damage = Random.Range(20, 35);
        playerStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[5], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
    }
    public void Revive()
    {
        playerStats.Revive();
    }
    public void TakeDamage()
    {
        float damage = Random.Range(500,600);
        playerStats.TakeDamage(damage);
        GameObject text = Instantiate(texts[6], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
    }
    public void Heal()
    {

        float healAmount = Random.Range(200, 250);
        playerStats.Heal(healAmount);
        GameObject text = Instantiate(texts[7], spawnPoint, Quaternion.identity, canvas.transform);
        float tiltDirection = TiltCalculator();
        text.transform.Rotate(0, 0, 15 * tiltDirection);
        string finalText = "+" + healAmount.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
    }
}
