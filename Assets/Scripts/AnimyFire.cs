using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimyFire : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<Sprite> AnimyImages;
    [SerializeField] GameObject AnimyBullet,MyCanvas, DestroyParticle, HitParticle, Slider;

    int cnt = 0, rnd = 0;
    float Damage = 0;
    bool IsLeft=true;
    public bool IsFire=false;
    
   
   
   
    private void Start()
    {
        Slider=transform.GetChild(0).gameObject;
        ReCreateAnimy();
    }
    void Update()
    {
        if (Score_And_Panels.IsGamePlay)
        {
            if (cnt == 0)
            {
                cnt = 1;
              
                if (rnd == 0) {
                    StartCoroutine(Animi2Fire());
                } else {

                   
                    StartCoroutine(Animi1Fire());
                }
              
            }

        }
    }

    private IEnumerator Animi1Fire()
    {

        while (true)
        {

            yield return new WaitForSeconds(0.5f);
            if (Slider.GetComponent<Slider>().value > 0)
            {
                if (IsFire)
                {
                    MySounds.Instance.OnAnimyBullet();
                    GameObject MyBullet = Instantiate(AnimyBullet);
                   
                    MyBullet.GetComponent<BulletMove>().IsUp = false;
                    MyBullet.transform.parent = transform;
                    MyBullet.transform.localPosition = Vector3.zero;
                    MyBullet.transform.localScale = Vector3.one;
                  
                    MyBullet.transform.localPosition = IsLeft ? new Vector2( - 20, transform.localPosition.y - 50) : new Vector2(20, transform.localPosition.y - 50);
                  

                    if (IsLeft)
                    {
                        IsLeft = false;
                    }
                    else
                    {

                        IsLeft = true;
                    }
                }

            }
           
         
              

            if (Score_And_Panels.IsGameOver)
            {

                break;
            }

        }

    } 
    private IEnumerator Animi2Fire()
    {

        while (true)
        {

            yield return new WaitForSeconds(1f);
            if (Slider.GetComponent<Slider>().value > 0)
            {

                if (IsFire)
                {
                    MySounds.Instance.OnAnimyBullet();

                    GameObject MyBullet = Instantiate(AnimyBullet);
                    MyBullet.GetComponent<BulletMove>().IsUp = false;
                    MyBullet.transform.parent = transform;
                    MyBullet.transform.localPosition = Vector3.zero;
                    MyBullet.transform.localScale = Vector3.one;
                 
                    MyBullet.transform.localPosition = new Vector2(0, transform.localPosition.y - 50);
                  

                }



            }

            if (Score_And_Panels.IsGameOver)
            {

                break;
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag == "PlayerFire") {
            Destroy(collision.gameObject);
            Debug.Log("PlayerFire");
              GameObject newHitParticle = Instantiate(HitParticle);
            newHitParticle.transform.localPosition = transform.position;
            Slider.GetComponent<Slider>().value -= Damage;
            if (Slider.GetComponent<Slider>().value == 0) {
                Score_And_Panels.LiveScore += 1;
                GameObject newDestroyParticle = Instantiate(DestroyParticle);
                newDestroyParticle.transform.localPosition = transform.position;
                transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InCubic);

                Invoke("ReCreateAnimy",2);
            }
        }
    }
    void ReCreateAnimy() {

        rnd = Random.Range(0, 2);
        if (rnd == 0)
        {
            Damage = 0.5f;
            transform.GetComponent<Image>().sprite = AnimyImages[0];
        }
        else
        {
            Damage = 0.2f;
            transform.GetComponent<Image>().sprite = AnimyImages[1];
        }
        Slider.GetComponent<Slider>().value = 1;
        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InCubic);
    }
}
