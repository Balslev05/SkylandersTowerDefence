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
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(scale, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => 
        transform.DOScale(0, 0.5f).SetEase(Ease.InExpo)).onComplete += () => Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeaveFireMarks()
    {
        Destroy(gameObject);
        GameObject Firemarks = Instantiate(FiremarksPrefab, transform.position, Quaternion.identity);

        Firemarks.transform.DOScale(scale, FireMarksTime).SetEase(Ease.OutExpo).OnComplete(() => 
        Firemarks.transform.DOScale(0, FireMarksTime).SetEase(Ease.InExpo)).onComplete += () => Destroy(Firemarks);

    }
}
