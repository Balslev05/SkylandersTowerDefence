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

        // 🎲 Random initial rotation
        float startRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, 0, startRotation);

        // 🔄 Smooth, slow spin (adds life)
        float spinSpeed = Random.Range(20f, 40f);
        transform.DORotate(new Vector3(0, 0, 360f), spinSpeed, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);

        // 🔥 Flame-like wandering motion
        WanderMotion();

        // 🧊 Fade out and destroy
        bulletRenderer.DOFade(0, flameTimer).OnComplete(() => Destroy(gameObject));
    }

    void WanderMotion()
{
    // Repeat small smooth random movements
    Sequence wander = DOTween.Sequence();

    int steps = 5;
    float stepTime = flameTimer / steps;

    for (int i = 0; i < steps; i++)
    {
        Vector3 randomStep = new Vector3(
            Random.Range(-0.3f, 0.3f),
            Random.Range(0.3f, 0.6f),
            0f
        );

        wander.Append(transform.DOMove(transform.position + randomStep, stepTime)
            .SetEase(Ease.InOutSine));
    }

    // Optional: loop if you want endless flame behavior (for e.g. a torch)
    // wander.SetLoops(-1);
}

    public void StartGradient(SpriteRenderer bulletMaterial)
    {
        DOTween.To(() => bulletMaterial.color, x => bulletMaterial.color = x, FlameGradient.Evaluate(1), 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}
