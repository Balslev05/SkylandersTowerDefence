using UnityEngine;
using DG.Tweening;
public class Eksplosion : MonoBehaviour
{
    public float scale = 1.5f;

    void Start()
    {
        EKSPLODE();
    }

    public void EKSPLODE()
    {
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(scale, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => 
        transform.DOScale(0, 0.5f).SetEase(Ease.InExpo)).onComplete += () => Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
