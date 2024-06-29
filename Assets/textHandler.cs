using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class textHandler : MonoBehaviour
{
    Vector3 destinationPoint;
    TextMeshProUGUI text;
    public float speed;
    string type;
    string imageType;

    // in this script, "frames" are used to determine relative time for animations. Used 30 FPS to convert frames on the videos to seconds. Because of this, most animations are divided into 30f.


    public void Start()
    {
        // Text spawns over the damaged characters head, spawns in with a set rotation and goes only up before fading out quickly = 20 frames for moving up, 10 frames for fading out.
        if (type == "text") // if damage text
            // FOR DAMAGE TEXT: 20 frames to complete, 10 frames to fade out. so 2 to 1 ratio
            transform.DOMove(destinationPoint, (20f / 30f)).SetEase(Ease.OutCubic).OnComplete(() => StartCoroutine(FadeOutText()));
        else if(type == "image") // if super or weak image
        { 
            if (imageType == "weak")
            {
                // Spawns from under the damage text with 0 alpha val
                // Fades in as it goes up. As it reaches the middle of the way and reaches full alpha value, it slows down and stops for a bit.Then it starts gaining speed upwards and starts fading out.

                // for images, 10 frame to reach middle, 10 frame to fade out so 20 frames
                StartCoroutine(FadeInWeakImage());
                transform.DOMove(new Vector3(destinationPoint.x, ((destinationPoint.y - transform.position.y) / 2) + transform.position.y, destinationPoint.z),
                    (10f / 30f)).SetEase(Ease.OutQuart).OnComplete(() =>
                    {
                        StartCoroutine(FadeOutWeakImage());
                        transform.DOMove(destinationPoint, (10f / 30f)).SetEase(Ease.InQuart);
                    });
            }
            // white background pops up with the damage text, at the same position. While weak text spawns long distance away from damage text

            // First white background pops up, then SUPER. first the S of super pops up, then remaining characters (not implemented in this demo, need the right images before doing this.)

            // white background disappears just before super text starts fading out. it takes around 3 frames.
            // doesnt move for a while (15 frames in 30), then fades out as it goes down(5 frames in 30).
            else if (imageType == "whiteBG") // background for super text
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
    // setting up destination and text from DamageGenerator
    public void SetupImage(Vector3 dest, string imageTypeParam){
        destinationPoint = dest;
        type = "image";
        imageType = imageTypeParam;
    }
    public void Setup(Vector3 dest, string dmg)
    {
        // destination could be set on this object, as it should only go up and should not change with anything (only for damage texts, which are handled in this function).
        type = "text";
        destinationPoint = dest;
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.SetText(dmg);
    }
    #endregion

    #region Fade Coroutines
    IEnumerator FadeOutText()
    {
        // 10 frames to disappear
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
        // 15 frames lifespan
        // 12 frames to wait
        yield return new WaitForSeconds(12f / 30f);
        // 3 frames to disappear
        Image sprite = GetComponent<Image>();
        for (float f = 1f; f > -0.05f; f -= 0.17f)
        {
            Color c = sprite.color;
            c.a = f;
            sprite.color = c;
            yield return new WaitForSeconds(0.5f / 30f);
        }
        Destroy(gameObject);
    }
    IEnumerator FadeOutWeakImage()
    {
        // 10 frames to disappear
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
        // *instead of 10, starting with additional alpha value. Looks much better IMO.
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
