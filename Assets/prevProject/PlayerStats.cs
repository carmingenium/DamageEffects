using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsOld : MonoBehaviour, IDamagableOld
{
    public float health;
    private Vector3 spawnPoint;
    private Vector3 destinationPoint;

    public float destinationPointX;
    public float destinationPointY;
    public float destinationPointZ;

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject damageText;
    public void Start()
    {
        Time.timeScale = 0.1f;
        health = 100;
        spawnPoint = transform.position;
    }
    public void TakeDamage()
    {
        float offsetX = Random.Range(-0.2f, 0.2f);
        float offsetY = Random.Range(-0.2f, 0.2f);
        float offsetZ = Random.Range(-0.2f, 0.2f);

        destinationPointX += spawnPoint.x + offsetX;
        destinationPointY += spawnPoint.y + offsetY;
        destinationPointZ += spawnPoint.z + offsetZ;

        destinationPoint = new Vector3(destinationPointX,destinationPointY,destinationPointZ);

        float damage = 0;
        damage = Random.Range(120, 150);

        GameObject text = Instantiate(damageText, spawnPoint, Quaternion.identity, canvas.transform);
        text.GetComponent<damageTextHandlerOld>().Setup(destinationPoint, damage);

        health -= damage;
    }
}
