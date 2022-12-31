using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Karakter : MonoBehaviour
{
    public int can = 1; // Karakter sayisi (kalabalik sayisi)
    public float hareketHizi; // Karakter hizi

    public float sagSolHizi = 2;
    public float sinirMes = 0;

    public SwipeManager swipeKontrol;

    public TextMeshPro canTxt;

    //public GameObject uye;

    public bool carpmaMi;  //gecitten gecme degerleri
    public int miktar;
    public float gecitBeklemeSuresi = 0.5f; //ayni anda gecitten gecmeyi engellemek icin sayac
    public float engelBS = 0.1f;
    public float gecmeZamani =0f;

    private void Start()
    {
        sinirMes = transform.position.x;
        canTxt.text = can.ToString();
    }

    private void Update()
    {
        KarakterIleriHareketi();
        KarakterSagSolHareket();
        KarakterOlumKontrol();
    }
    private void KarakterIleriHareketi() // Karakterlerin hareketi
    {
        transform.Translate(0, 0, hareketHizi * Time.deltaTime);

        if (swipeKontrol.SwipeRight)
        {
            sinirMes += sagSolHizi;

        }else if(swipeKontrol.SwipeLeft)
        {
            sinirMes -= sagSolHizi;
        }
        else
        {
            sinirMes = transform.position.x;
        }
    }

    public void KarakterSagSolHareket()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(sinirMes, transform.position.y, transform.position.z), hareketHizi * Time.deltaTime);
    }

    public void Hasar(int hasar) // Karakter sayisini azaltir
    {
        can -= hasar;
    }

    private void KarakterOlumKontrol() // karakterlerin bitip bitmedigini kontrol eder.
    {
        if(can <= 0)
        {
            can = 0;
            canTxt.text = can.ToString();
            OyunBitti();
        }
    }

    private void OyunBitti()
    {
        hareketHizi = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "gecit")
        {
            miktar = other.GetComponent<Gecit>().miktar;
            carpmaMi = other.GetComponent<Gecit>().carpmaMi;

            KarakterArttir(miktar, carpmaMi);
        }else if(other.tag == "engel")
        {
            if (Time.time > gecmeZamani + engelBS)
            {
                    can -= 10;

            }

            canTxt.text = can.ToString();
            gecmeZamani = Time.time;
        }else if(other.tag == "son")
        {
            Invoke("OyunBitti", 2f); ;
        }
    }

    public void KarakterArttir(int miktar, bool carpmaMi)
    {
        //int oncekiCan = can;
        if(Time.time > gecmeZamani + gecitBeklemeSuresi)
        {
            if (carpmaMi)
            {
                can *= miktar;
            }
            else
            {
                can += miktar;
            }

            //for (int i = 0; i < can-oncekiCan; i++)
            //{
            //    Instantiate(uye, transform);
            //}
        }

        canTxt.text = can.ToString();
        gecmeZamani = Time.time;
    }

}
