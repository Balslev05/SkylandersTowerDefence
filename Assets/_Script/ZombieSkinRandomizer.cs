using UnityEngine;
using DG.Tweening;
public class ZombieSkinRandomizer : MonoBehaviour
{
    public bool RandomzieZombie = false;
    public bool animateZombie = false;
    [Header("Zombie Parts")]
    public GameObject Hair;
    public GameObject Head;
    public GameObject Body;
    public GameObject ArmR;
    public GameObject ArmL;
    [Header("Zombie Sprites")]
    public Sprite[] ListOfHair;
    public Sprite[] ListOfHead;
    public Sprite[] ListOfBody;
    public Sprite[] ListOfArmsR;
    public Sprite[] ListOfArmsL;
    [Header("Animation Settings")]
    public float floatAmount = 0.05f; 
    public float floatDuration = 0.5f;
    public float armSwingAmount = 15f;
    public float armSwingDuration = 0.4f;
    
    void Start()
    {
        if (RandomzieZombie)
        {
            RandomizedSkin(); 
        }
        if (animateZombie)
        {
            AnimateZombie();
        }
    }

    void Update()
    {
        
    }

    public void RandomizedSkin()
    {
        Hair.GetComponent<SpriteRenderer>().sprite = ListOfHair[Random.Range(0, ListOfHair.Length)];
        Head.GetComponent<SpriteRenderer>().sprite = ListOfHead[Random.Range(0, ListOfHead.Length)];
        Body.GetComponent<SpriteRenderer>().sprite = ListOfBody[Random.Range(0, ListOfBody.Length)];
        ArmR.GetComponent<SpriteRenderer>().sprite = ListOfArmsR[Random.Range(0, ListOfArmsR.Length)];
        ArmL.GetComponent<SpriteRenderer>().sprite = ListOfArmsL[Random.Range(0, ListOfArmsL.Length)];
    }

        void AnimateZombie()
        {
            // Body floating effect
            Body.transform.DOLocalMoveY(Body.transform.localPosition.y + floatAmount, floatDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);

            // Head slight bobbing effect
            Head.transform.DOLocalMoveY(Head.transform.localPosition.y + floatAmount * 0.5f, floatDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);

            // Arm swinging (right arm)
            ArmR.transform.DOLocalRotate(new Vector3(0, 0, armSwingAmount), armSwingDuration, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);

            // Arm swinging (left arm, opposite direction)
            ArmL.transform.DOLocalRotate(new Vector3(0, 0, -armSwingAmount), armSwingDuration, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
          /*   // Change the sprite render to a bit darker so that it looks like they go up and down using dotween Set to loop
            foreach (Transform child in transform){
                child.GetComponent<SpriteRenderer>().DOColor(new Color(0.9f, 0.9f, 0.9f, 0.9f), 0.25f).onComplete += ()
                => child.GetComponent<SpriteRenderer>().DOColor(new Color(1f, 1f, 1f, 1f), 0.25f).SetLoops(-1, LoopType.Yoyo);
            }

            transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.25f).onComplete += ()
            => transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f).SetLoops(-1, LoopType.Yoyo); */
        }
    }
