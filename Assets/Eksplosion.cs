using UnityEngine;
using DG.Tweening;
public class Eksplosion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EKSPLODE();
    }

    public void EKSPLODE()
    {
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1).OnComplete(() => Destroy(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
