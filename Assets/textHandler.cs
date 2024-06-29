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
    string imageType;


    // need to change bool to string for clarification, optimization won't affect this project much aside from object pools.

    public void Start()
    {
        // FOR DAMAGE TEXT: 20 frames to complete, 10 frames to fade out. so 2 to 1 ratio count 30 frames as 1 sec
        if (type)
            transform.DOMove(destinationPoint, (20f / 30f)).SetEase(Ease.OutCubic).OnComplete(() => StartCoroutine(FadeOutText()));
        else{
            if (imageType == "weak")
            {
                // for images, 5 frame to reach middle, 5 frame to fade out so 10 frames = 1/3 sec
                StartCoroutine(FadeInWeakImage());
                transform.DOMove(new Vector3(destinationPoint.x, ((destinationPoint.y - transform.position.y) / 2) + transform.position.y, destinationPoint.z),
                    (10f / 30f)).SetEase(Ease.OutQuart).OnComplete(() =>
                    {
                        StartCoroutine(FadeOutWeakImage());
                        transform.DOMove(destinationPoint, (10f / 30f)).SetEase(Ease.InQuart);
                    });
            }
            else if (imageType == "whiteBG")
            {
                StartCoroutine(WhiteBGBehaviour());
            }
            else if (imageType == "super")
            {
                StartCoroutine(FadeOutSuperImage());
            }
        }
    }

    #region Setups
    public void SetupImage(Vector3 dest, bool image, string imageTypeParam){
        destinationPoint = dest;
        type = image;
        imageType = imageTypeParam;
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
    #endregion

    #region Fade Coroutines
    IEnumerator FadeOutText()
    {
        for(float f = 1f; f > -0.05f; f -= 0.10f)
        {
            Color c = text.color;
            c.a = f;
            text.color = c;
            yield return new WaitForSeconds(1f/30f);
        }
        Destroy(gameObject);
    }
    IEnumerator FadeOutSuperImage()
    {
        // 15 frames wait
        yield return new WaitForSeconds(15f / 30f);
        // 5 frames to disappear
        // 10 frames to move, so that text goes slower even though disappears at 5
        transform.DOMove(destinationPoint, (10f / 30f)).SetEase(Ease.OutSine);
        Image sprite = GetComponent<Image>();
        for (float f = 1f; f > -0.05f; f -= 0.20f)
        {
            Color c = sprite.color;
            c.a = f;
            sprite.color = c;
            yield return new WaitForSeconds(0.5f / 30f);
        }
        Destroy(gameObject);
    }
    IEnumerator WhiteBGBehaviour()
    {
        //15 frames lifespan
        yield return new WaitForSeconds(15f / 30f);
        Destroy(gameObject);
    }
    IEnumerator FadeOutWeakImage()
    {
        // 10 frames
        Image sprite = GetComponent<Image>();
        for (float f = 1f; f > -0.05f; f-= 0.10f)
        {
            Color c = sprite.color;
            c.a = f;
            sprite.color = c;
            yield return new WaitForSeconds(1f / 30f);
        }
        Destroy(gameObject);
    }
    IEnumerator FadeInWeakImage()
    {
        // 9* frames
        Image sprite = GetComponent<Image>();
        // instead of 10, starting with additional alpha value. Looks much better IMO.
        for (float f = 0.10f; f < 1.05f; f += 0.10f)
        {
            Color c = sprite.color;
            c.a = f;
            sprite.color = c;
            yield return new WaitForSeconds(1f / 30f);
        }
        // adding last frame at the end to increase the time of image being visible and wait time at the middle.
        yield return new WaitForSeconds(1f / 30f);
    }
    #endregion
}
