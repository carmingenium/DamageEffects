using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
public class textHandler : MonoBehaviour
{
    Vector3 destinationPoint;
    TextMeshProUGUI text;
    public float speed;
    bool type;
    public void SetupImage(Vector3 dest, bool image){
        destinationPoint = dest;
        type = image;
    }
    public void Setup(Vector3 dest, string dmg, bool txt)
    {
        // setting up destination and text from UImanager
        // destination could be set on this object, as it should only go up and should not change with anything.
        type = txt;
        destinationPoint = dest;
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.SetText(dmg);
    }
    public void Start()
    {
        // move to destination, wait, destroy
        // 20 frames to complete, 10 frames to fade out. so 2 to 1 ratio count 30 frames as 1 sec
        if (type)
            transform.DOMove(destinationPoint, (20f / 30f)).SetEase(Ease.OutCubic).OnComplete(() => StartCoroutine(FadeOutText()));
        else
        {
            // !!! right now, image stuff is made for weak image. Super image acts differently. need to find a way to differentiate them

            // for images, 5 frame to reach middle, 5 frame to fade out so 10 frames = 1/3 sec
            StartCoroutine(FadeInImage());
            transform.DOMove(new Vector3(destinationPoint.x, destinationPoint.y/2, destinationPoint.z)
                ,(5f / 30f)).SetEase(Ease.OutQuart)
                .OnComplete(() => 
                {
                    StartCoroutine(FadeOutImage());
                    transform.DOMove(destinationPoint, (5f / 30f)).SetEase(Ease.InQuart);
                });
        }
            
    }
    IEnumerator FadeOutText()
    {
        // 10 frames
        for(float f = 1f; f > -0.05f; f -= 0.10f)
        {
            Color c = text.color;
            c.a = f;
            text.color = c;
            yield return new WaitForSeconds(1f/30f);
        }
        Destroy(gameObject);
    }
    IEnumerator FadeOutWeakImage()
    {
        // 5 frames
        Image sprite = GetComponent<Image>();
        for (float f = 1f; f > -0.05f; f-= 0.10f)
        {
            Color c = sprite.color;
            c.a = f;
            sprite.color = c;
            yield return new WaitForSeconds(5f / 30f);
        }
        Destroy(gameObject);
    }
    IEnumerator FadeInWeakImage()
    {
        // 5/30
        Image sprite = GetComponent<Image>();
        for (float f = 0f; f < 1.05f; f += 0.10f)
        {
            Color c = sprite.color;
            c.a = f;
            sprite.color = c;
            yield return new WaitForSeconds(5f / 30f);
        }
    }
}
