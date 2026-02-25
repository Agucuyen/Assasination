using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Taramali1 : MonoBehaviour
{
    [Header("AYARLAR")]
    float AtesEtmeSikligi_1;
    public float AtesEtmeSikligi_2;
    public float menzil;
    int ToplamMermiSayisi = 930;
    int SarjorKapasitesi = 30;
    int KalanMermi;
    float DarbeGucu = 25;
    public TextMeshProUGUI ToplamMermi_text;
    public TextMeshProUGUI KalanMermi_text;

    [Header("SESLER")]
    public AudioSource[] Sesler;
    [Header("EFEKTLER")]
    public ParticleSystem[] Efektler;
    /* public ParticleSystem Mermiİzi;
     public ParticleSystem KanEfekti;*/

    [Header("GENEL İSLEMLER")]
    public Camera BenimKameram;
    public Animator KarakterinAnimatoru;

    void Start()
    {
        KalanMermi = SarjorKapasitesi;
        ToplamMermi_text.text = ToplamMermiSayisi.ToString();
        KalanMermi_text.text = KalanMermi.ToString();

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ReloadKontrol();

        }
        if (KarakterinAnimatoru.GetBool("reload"))
        {
            ReloadislemiTeknikFonksiyon();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > AtesEtmeSikligi_1 && KalanMermi != 0)
            {
                AtesEt();
                AtesEtmeSikligi_1 = Time.time + AtesEtmeSikligi_2;

            }
            if (KalanMermi == 0)
            {

                Sesler[1].Play();
            }


        }
    }



    void AtesEt()
    {

        KalanMermi--;
        KalanMermi_text.text = KalanMermi.ToString();
        Efektler[0].Play();
        Sesler[0].Play();
        KarakterinAnimatoru.Play("Egilme_ates_etme");
        RaycastHit hit;
        if (Physics.Raycast(BenimKameram.transform.position, BenimKameram.transform.forward, out hit, menzil))
        {


            if (hit.transform.gameObject.CompareTag("Dusman"))
            {
                hit.transform.gameObject.GetComponent<Dusman>().SaglikDurumu(DarbeGucu);

                Instantiate(Efektler[2], hit.point, Quaternion.LookRotation(hit.normal));

            }
            else
            {
                Instantiate(Efektler[1], hit.point, Quaternion.LookRotation(hit.normal));
            }
            
         

        }

    }

    void ReloadKontrol()
    {
        if (KalanMermi < SarjorKapasitesi && ToplamMermiSayisi != 0)
        {
            KarakterinAnimatoru.Play("sarjordegistir");
            
             if(!Sesler[2].isPlaying)
                Sesler[2].Play();
        }

    }

    void ReloadislemiTeknikFonksiyon()
    {
        if (KalanMermi == 0) // mermi yok
        {

            if (ToplamMermiSayisi <= SarjorKapasitesi)
            {
                /// 3 -- 5 =  -2

                KalanMermi = ToplamMermiSayisi;
                // 3
                ToplamMermiSayisi = 0;

            }
            else
            {
                ToplamMermiSayisi -= SarjorKapasitesi;
                KalanMermi = SarjorKapasitesi;

            }


        }
        else // mermi var
        {
            // kalan mermi  Toplammermi
            //    3             4 = 7

            if (ToplamMermiSayisi <= SarjorKapasitesi)
            {
                int OlusanDeger = KalanMermi + ToplamMermiSayisi;
                ///  7
                if (OlusanDeger > SarjorKapasitesi)
                {
                    KalanMermi = SarjorKapasitesi; // 2
                    ToplamMermiSayisi = OlusanDeger - SarjorKapasitesi;
                    //  2

                }
                else
                {
                    // kalan mermi  Toplammermi
                    //    3             1 = 4
                    KalanMermi += ToplamMermiSayisi; // 4
                    ToplamMermiSayisi = 0;
                }



            }
            else
            {
                int MevcutMermimiz = SarjorKapasitesi - KalanMermi;
                ToplamMermiSayisi -= MevcutMermimiz;
                KalanMermi = SarjorKapasitesi;

            }


        }
        ToplamMermi_text.text = ToplamMermiSayisi.ToString();
        KalanMermi_text.text = KalanMermi.ToString();

        KarakterinAnimatoru.SetBool("reload", false);

    }
}
