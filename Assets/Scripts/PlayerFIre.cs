using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFIre : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject PlayerBullet;
    int cnt = 0;
  [SerializeField]  GameObject MyCanvas;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Score_And_Panels.IsGamePlay) {
            if (cnt == 0) {
                cnt = 1;    
                StartCoroutine(PlayerFire());
            }
          
        }
    }

    private IEnumerator PlayerFire()
    {

        while (true)
        {
           
            yield return new WaitForSeconds( 1f );
           
          
            transform.DOLocalMoveY(110, 0.1f).SetEase(Ease.Flash).OnComplete(() =>
            {
                MySounds.Instance.OnPlayerBullet();
                for (int i = 0; i < 2; i++)
                {
                    GameObject MyBullet = Instantiate(PlayerBullet);
                    MyBullet.GetComponent<BulletMove>().IsUp = true;
                    MyBullet.transform.parent = transform;
                    MyBullet.transform.transform.localPosition = Vector3.zero;
                    MyBullet.transform.localScale = Vector3.one;
                    MyBullet.transform.localPosition = transform.localPosition;
                    MyBullet.transform.localPosition = i == 0 ? new Vector2(transform.localPosition.x - 70, transform.localPosition.y + 10): new Vector2(transform.localPosition.x + 70, transform.localPosition.y + 10);
                    MyBullet.transform.parent = MyCanvas.transform;
                }
              
                transform.DOLocalMoveY(130, 0.1f).SetEase(Ease.Flash);
            });
            if (Score_And_Panels.IsGameOver)
            {
                
                break;
            }

        }

    }
    
}
