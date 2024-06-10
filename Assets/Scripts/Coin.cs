using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public IEnumerator Disappear()
    {
        float minTransparentValue = 0;
        float disappearingSpeed = 3f;
        float upSpeed = 0.04f;

        if (gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer renderer))
        {
            while (renderer.material.color.a > 0)
            {
                transform.Translate(Vector3.up*upSpeed);
                Color newColor = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, Mathf.MoveTowards(renderer.material.color.a, minTransparentValue, disappearingSpeed * Time.deltaTime));
                renderer.material.color = newColor;
                yield return null;
            }
        }

        gameObject.SetActive(false);
    }
}
