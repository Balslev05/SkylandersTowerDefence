using UnityEngine;
using DG.Tweening;
using Unity.Burst.Intrinsics;
using System.Collections;
public class UpgradeBox : MonoBehaviour
{
   public float speed = 1f;    
   public Vector3 startScale = new Vector3(8,4,1);
   public int StartPosX;
   public UpgradeBox OtherBox;
   public KeyCode key = KeyCode.RightArrow;
   public bool IsSelected = false;
  
    public void Reset()
    {
    transform.localPosition = new Vector3(StartPosX,-1000,0);
    }
    void Start()
    {
        transform.localPosition = new Vector3(StartPosX,-1000,0);
        MoveUp();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetKeyDown(key) && IsSelected)
        {
            StartCoroutine(purshaed());
            return;
        }
        if (Input.GetKeyDown(key)&& !IsSelected)
        {
            Selected();
        }

    }
    public void MoveUp()
    {
       transform.DOLocalMove(new Vector3(this.transform.localPosition.x,-200,0), speed).SetEase(Ease.OutExpo);
       transform.DORotate(Vector3.zero, speed).SetEase(Ease.OutBack);
    }
    public void MoveDown()
    {
        transform.DOLocalMove(new Vector3(this.transform.localPosition.x,-1000,0), speed).SetEase(Ease.OutExpo);
        transform.DORotate(Vector3.zero, speed).SetEase(Ease.OutBack);
    }
    public void Selected()
    {
        //Make slithly bigger and move up
      
        transform.DOScale(startScale * 1.2f, speed).SetEase(Ease.OutExpo);
        transform.DOLocalMove(new Vector3(this.transform.localPosition.x,-100,0), speed).SetEase(Ease.OutExpo).onComplete += () => IsSelected = true;
        OtherBox.Deselected();
    }
    public void Deselected()
    {
        transform.DOScale(startScale, speed).SetEase(Ease.OutExpo);
        transform.DOLocalMove(new Vector3(this.transform.localPosition.x, -200, 0), speed).SetEase(Ease.OutExpo).onComplete += () => IsSelected = false;
    }
    public IEnumerator purshaed()
    {
        transform.DOShakeScale(16f, 0.1f);
        CameraShake.Shake(2f, 0.1f);
        transform.DOScale(startScale*1.25f, speed).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(0.5f);
        MoveDown();
        OtherBox.MoveDown();
        yield return new WaitForSeconds(0.5f);
        OtherBox.Reset();
        Reset();
    }
}
