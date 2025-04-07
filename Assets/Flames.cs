using UnityEngine;
using DG.Tweening;

public class Flames : MonoBehaviour
{
    public float flameTimer = 2f;
    public Gradient FlameGradient;

    void Start()
    {
        SpriteRenderer bulletRenderer = GetComponent<SpriteRenderer>();
        StartGradient(bulletRenderer);

        // 🎲 Random start rotation
        float startRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, 0, startRotation);

        // 🔄 Continuous spinning
        float randomRotationSpeed = Random.Range(60f, 120f); // Faster spin
        transform.DORotate(new Vector3(0, 0, 360f), randomRotationSpeed, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);

        // ⚡ More energetic drifting motion
        Vector3 randomDirection = new Vector3(
            Random.Range(-1.5f, 1.5f),
            Random.Range(1f, 2.5f), // more vertical lift
            0f
        );

        float driftDuration = flameTimer * 0.5f; // move faster
        transform.DOMove(transform.position + randomDirection, driftDuration)
            .SetEase(Ease.OutSine)
            .OnComplete(() => {
                // Optional: slight secondary drift for natural feel
                Vector3 extraDrift = new Vector3(
                    Random.Range(-0.5f, 0.5f),
                    Random.Range(0.3f, 0.8f),
                    0f
                );
                transform.DOMove(transform.position + extraDrift, flameTimer * 0.3f).SetEase(Ease.OutQuad);
            });

        // 🔥 Fade out and destroy
        bulletRenderer.DOFade(0, flameTimer).OnComplete(() => Destroy(gameObject));
    }


    public void StartGradient(SpriteRenderer bulletMaterial)
    {
        DOTween.To(() => bulletMaterial.color, x => bulletMaterial.color = x, FlameGradient.Evaluate(1), 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}
