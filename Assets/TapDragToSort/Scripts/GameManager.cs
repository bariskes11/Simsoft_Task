using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("Total Box Count To Complete")]
    public int BoxCount;
    // current box left to complete level
    private int m_BoxLeft;
    private bool m_completed = false;
    public ParticleSystem winParticle;


    private void Start()
    {
        m_BoxLeft = BoxCount;
    }

    public void SetBoxLeft()
    {
        m_BoxLeft--;
    }
    private void Update()
    {
        if (m_BoxLeft <= 0 && !m_completed)
        {
            m_completed = true;
            winParticle.Play();
        }
    }
}
