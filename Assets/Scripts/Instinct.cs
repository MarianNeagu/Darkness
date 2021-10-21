using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class Instinct : MonoBehaviour 
{
    public float timer;
    public float timerSpeed=1f;
    public float alphaSpeed=1f;
    public float cameraSpeed=1.5f;
    //public float butonAnimSpeed;
    public SpriteRenderer[] instinct;
    public Button instinctButton;
    public CinemachineVirtualCamera virtualCamera;
    public Image baraStare;
    //public Image centruButon;

    void Start()
    {
        for(int i = 0; i < instinct.Length; i++)
            instinct[i].color = new Color(1f,1f,1f,0f);
        virtualCamera.m_Lens.OrthographicSize = 3.5f;
        instinctButton.interactable = false;
        StartCoroutine(Inactive());
    }

    IEnumerator Inactive()
    {
        instinctButton.interactable = false;
        float timer = 0f;
        while(timer <= 15f)
        {
            timer += Time.deltaTime*timerSpeed;
            baraStare.fillAmount = timer/15;
            if(timer>=15)
            {
                instinctButton.interactable = true; 
                //StartCoroutine(AnimatieButonComplet());
            }
                
            yield return 0;
        }
    }

    /* IEnumerator AnimatieButonComplet()
    {
        float timer = 0.5f;
        bool opac = false;
        if(!opac)
            while(timer <= 1f)
            {
                timer += Time.deltaTime*butonAnimSpeed;
                instinctButton.nor = new Color(1f,133f/255f,47f/255f,timer);
                yield return 0;
                if(timer>=1f)
                    opac = true;
                    
            }
        else
            while(timer >= 0.5f)
            {
                timer -= Time.deltaTime*butonAnimSpeed;
                centruButon.color = new Color(1f,133f/255f,47f/255f,timer);
                yield return 0;
                if(timer<=0.5f)
                    opac = false;
            }
    }*/

    public void StartInstinct()
    {
        StartCoroutine(FadeIn()); 
        instinctButton.interactable = false;
    }

    IEnumerator FadeIn() //apare instinctul si camera se indeparteaza
    {
        float time = 0f;
		while(time <= 2f)                                                         
		{
            if(virtualCamera.m_Lens.OrthographicSize<=5.49f)
                virtualCamera.m_Lens.OrthographicSize += Time.deltaTime*cameraSpeed;
            else virtualCamera.m_Lens.OrthographicSize = 5.5f;
			time += Time.deltaTime * alphaSpeed;    
            for(int i = 0; i < instinct.Length; i++)                             
			    instinct[i].color = new Color (1f, 1f, 1f, time);
			yield return 0;
            if(time>=2f)
                StartCoroutine(WaitSeconds());
		}
    }

    IEnumerator WaitSeconds() //asteapta
    {
        timer=0f;
        while(timer<=10f)
        {
            timer+=Time.deltaTime*timerSpeed;
            yield return 0;
            if(timer>=10f)
                StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut() //dispare instinctul si camera se apropie
    {
        float time = 2f;
		while(time >= 0f)                                                         
		{
            baraStare.fillAmount = time/2;
            if(virtualCamera.m_Lens.OrthographicSize >= 3.51f)
                virtualCamera.m_Lens.OrthographicSize -= Time.deltaTime*cameraSpeed;
            else virtualCamera.m_Lens.OrthographicSize = 3.5f;
			time -= Time.deltaTime * alphaSpeed;       
            for(int i = 0; i < instinct.Length; i++)                         
			    instinct[i].color = new Color (1f, 1f, 1f, time);
			yield return 0;
            if(time<=0f)
                StartCoroutine(Inactive());
		}
    }

}