using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class textHandler : MonoBehaviour
{
    Vector3 destinationPoint;
    TextMeshProUGUI text;
    public float speed;

    public void SetupImage(Vector3 dest){
        destinationPoint = dest;
    }
    public void Setup(Vector3 dest, string dmg)
    {
        // setting up destination and text from UImanager
        // destination could be set on this object, as it should only go up and should not change with anything.
        destinationPoint = dest;
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.SetText(dmg);
    }
    public void Start()
    {
        // move to destination, wait, destroy
        transform.DOMove(destinationPoint, 1f).SetEase(Ease.OutSine).OnComplete(() => StartCoroutine(WaitBeforeRemoval()));
    }
    IEnumerator WaitBeforeRemoval()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
