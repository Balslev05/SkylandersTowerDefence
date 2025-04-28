using UnityEngine;
using DG.Tweening;
using System.Collections;
public class Eksplosion : MonoBehaviour
{
    public Sprite[] anim;
    public float animtime = 1;
    public float scale = 1.5f;
    public float FireMarksTime = 0.5f;
    public GameObject FiremarksPrefab;

    public float physicalDamage = 0.1f;
    public float elementalDamage = 0.1f;

    void Start()
    {
        EKSPLODE();
        StartCoroutine(Animate());
    }

    public void EKSPLODE()
    {
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(scale, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => 
        transform.DOScale(0, 0.5f).SetEase(Ease.InExpo)).onComplete += () => LeaveFireMarks();
        Destroy(this.gameObject,0.6f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Target>().TakeDamage(physicalDamage, elementalDamage);
        }
    }
    public void LeaveFireMarks()
    {
        if (!FiremarksPrefab) return;
        
        GameObject Firemarks = Instantiate(FiremarksPrefab, transform.position, Quaternion.identity);
        Destroy(Firemarks, FireMarksTime);
    }

    public IEnumerator Animate()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            this.GetComponent<SpriteRenderer>().sprite = anim[i];
            yield return new WaitForSeconds(animtime);
        }
    }
}
