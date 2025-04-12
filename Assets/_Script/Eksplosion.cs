using UnityEngine;

using DG.Tweening;
public class Eksplosion : MonoBehaviour
{
    public float scale = 1.5f;
    public float FireMarksTime = 0.5f;
    public GameObject FiremarksPrefab;

    void Start()
    {
        EKSPLODE();
    }

    public void EKSPLODE()
    {
        LeaveFireMarks();
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(scale, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => 
        transform.DOScale(0, 0.5f).SetEase(Ease.InExpo)).onComplete += () => Destroy(gameObject);

    }
    public void LeaveFireMarks()
    {
        if (FiremarksPrefab == null) return;
        
        Destroy(gameObject);
        GameObject Firemarks = Instantiate(FiremarksPrefab, transform.position, Quaternion.identity);
        Destroy(Firemarks, FireMarksTime);
    }
}
