using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject selectedObject, MySlider;

    float Damage = 0.1f;
    Vector3 offset;
    [SerializeField] GameObject DestroyParticle, HitParticle,GameOverPanel;

    void Start()
    {
        MySlider = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.07f, 0.93f);
      
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.tag == "Player") {

                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;


            }
        }
        if (selectedObject)
        {
            if (selectedObject)
            {

                selectedObject.transform.position = new Vector3(mousePosition.x + offset.x, transform.position.y, mousePosition.z + offset.z);

            }
            //  selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0)) {

            selectedObject = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AnimiFire")
        {
           
            Destroy(collision.gameObject);
            MySlider.GetComponent<Slider>().value -= Damage;
            if (MySlider.GetComponent<Slider>().value == 0) {
                if (PlayerPrefs.GetInt("best") < Score_And_Panels.LiveScore) {

                    PlayerPrefs.SetInt("best", Score_And_Panels.LiveScore);
                }
                GameObject newDestroyParticle = Instantiate(DestroyParticle);
                newDestroyParticle.transform.localPosition = transform.position;
                transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InCubic);
                Score_And_Panels.IsGameOver = true; 
            Score_And_Panels.IsGamePlay = false; 
                GameOverPanel.SetActive(true);
       
            }
        }
    }
}
