using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject player;
    public PlayerStats playerStats;

    private Vector3 spawnPoint;
    private Vector3 destinationPoint;

    public float destinationPointX;
    public float destinationPointY;
    public float destinationPointZ;

    [SerializeField] private GameObject canvas;
    [SerializeField] private List<GameObject> texts;
    public void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        spawnPoint = player.transform.position;
    }
    public void DestinationCalculator()
    {
        float offsetX = Random.Range(-0.2f, 0.2f);
        float offsetY = Random.Range(-0.2f, 0.2f);
        float offsetZ = Random.Range(-0.2f, 0.2f);

        destinationPointX += spawnPoint.x + offsetX;
        destinationPointY += spawnPoint.y + offsetY;
        destinationPointZ += spawnPoint.z + offsetZ;

        destinationPoint = new Vector3(destinationPointX, destinationPointY, destinationPointZ);
    }
    public void DealDamage()
    {
        float damage = Random.Range(120, 150);
        playerStats.TakeDamage(damage);
        DestinationCalculator();
        GameObject text = Instantiate(texts[0], spawnPoint, Quaternion.identity, canvas.transform);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
    }
    public void DealCritDamage()
    {
        float damage = Random.Range(240, 300);
        playerStats.TakeDamage(damage);
        DestinationCalculator();
        GameObject text = Instantiate(texts[1], spawnPoint, Quaternion.identity, canvas.transform);
        string finalText = "-" + damage.ToString() + "!";
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
    }
    public void SuperDamage()
    {
        float damage = Random.Range(240, 300);
        playerStats.TakeDamage(damage);
        DestinationCalculator();
        GameObject text = Instantiate(texts[2], spawnPoint, Quaternion.identity, canvas.transform);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
        // display super text
    }
    public void SuperCritDamage()
    {
        float damage = Random.Range(240, 300);
        playerStats.TakeDamage(damage);
        DestinationCalculator();
        GameObject text = Instantiate(texts[3], spawnPoint, Quaternion.identity, canvas.transform);
        string finalText = "-" + damage.ToString() + "!";
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
        // display super text
    }
    public void WeakDamage()
    {
        float damage = Random.Range(10, 20);
        playerStats.TakeDamage(damage);
        DestinationCalculator();
        GameObject text = Instantiate(texts[4], spawnPoint, Quaternion.identity, canvas.transform);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
        // display super text
    }
    public void PoisonDamage()
    {
        float damage = Random.Range(20, 35);
        playerStats.TakeDamage(damage);
        DestinationCalculator();
        GameObject text = Instantiate(texts[5], spawnPoint, Quaternion.identity, canvas.transform);
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
        DestinationCalculator();
        GameObject text = Instantiate(texts[6], spawnPoint, Quaternion.identity, canvas.transform);
        string finalText = "-" + damage.ToString();
        text.GetComponent<textHandler>().Setup(destinationPoint, finalText);
    }
}
