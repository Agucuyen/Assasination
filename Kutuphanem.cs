using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OlcayUdemy
{



    public class Animasyon

    {
        private float MaXSpeedClass;
        private float MaXinputXClass;               
        /*   public void Sol_hareket(Animator Anim, string AnaParametreAdi, string KontrolParametre,
               float Yurume, float Kosma, float İlerisol, float GeriSol)
        {*/

        public void Sol_hareket(Animator Anim, string AnaParametreAdi, string KontrolParametre,
            List<float> parametredegerleri)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Anim.SetBool(KontrolParametre, true);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[1]);

                }
                else if (Input.GetKey(KeyCode.W))
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[2]);

                }
                else if (Input.GetKey(KeyCode.S))
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[3]);

                }
                else
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[0]);
                }

            }


            if (Input.GetKeyUp(KeyCode.A))
            {
                Anim.SetFloat(AnaParametreAdi, 0f);
                Anim.SetBool(KontrolParametre, false);

            }

        }
        public void Sag_hareket(Animator Anim, string AnaParametreAdi, string KontrolParametre,
            List<float> parametredegerleri)
        {
            if (Input.GetKey(KeyCode.D))
            {
                Anim.SetBool(KontrolParametre, true);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[1]);

                }
                else if (Input.GetKey(KeyCode.W))
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[2]);

                }
                else if (Input.GetKey(KeyCode.S))
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[3]);

                }
                else
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[0]);
                }

            }


            if (Input.GetKeyUp(KeyCode.D))
            {
                Anim.SetFloat(AnaParametreAdi, 0f);
                Anim.SetBool(KontrolParametre, false);

            }

        }
        public void Geri_hareket(Animator Anim, string AnaParametreAdi)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Anim.SetBool(AnaParametreAdi, true);

            }

            if (Input.GetKeyUp(KeyCode.S))
            {

                Anim.SetBool(AnaParametreAdi, false);
            }

        }
        public void Egilme_hareket(Animator Anim, string AnaParametreAdi,List<float> parametredegerleri)
        {
            if (Input.GetKey(KeyCode.C))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[1]);

                }
                else if (Input.GetKey(KeyCode.S))
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[2]);

                }
                else if (Input.GetKey(KeyCode.A))
                {  
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[3]);

                }
                else if (Input.GetKey(KeyCode.D))
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[4]);

                }
                else
                {
                    Anim.SetFloat(AnaParametreAdi, parametredegerleri[0]);
                }

            }

            if (Input.GetKeyUp(KeyCode.C))
            {

                Anim.SetFloat(AnaParametreAdi, 0f);
            }

        }

        /* public void Karakter_hareket(Animator Anim,string hizdegeri,Vector3 mevcutyon,float MaxSpeed,float maksimumuzunluk)
         {
             Anim.SetFloat(hizdegeri, Vector3.ClampMagnitude(mevcutyon, MaxSpeed).magnitude, maksimumuzunluk, Time.deltaTime * 10);

         }*/        
        public void Karakter_hareket(Animator Anim, string hizdegeri, float maksimumuzunluk, float TamHiz, float YurumeHizi)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                MaXSpeedClass = TamHiz;

            }
            else if (Input.GetKey(KeyCode.W))
            {
                MaXSpeedClass = YurumeHizi;
                MaXinputXClass = 1;
            }
            else
            {
                MaXSpeedClass = 0f;
                MaXinputXClass = 0;

            }


            Anim.SetFloat(hizdegeri, Vector3.ClampMagnitude(new Vector3(MaXinputXClass, 0, 0), MaXSpeedClass).magnitude, maksimumuzunluk, Time.deltaTime * 10);

        }

        public void Karakter_Rotation(Camera MainCam,float rotationSpeed,GameObject Karakter)
        {
            Vector3 CamOfset = MainCam.transform.forward;
            CamOfset.y = 0;
            Karakter.transform.forward = Vector3.Slerp(Karakter.transform.forward, CamOfset, Time.deltaTime * rotationSpeed);

        }




        public List<float> ParametreOlustur(float[] deger)
        {
            List<float> Sol_Yon_parametreleri = new List<float>();

            foreach (float item in deger)
            {
                Sol_Yon_parametreleri.Add(item);
            }

            return Sol_Yon_parametreleri;

        }
         
    }

}

