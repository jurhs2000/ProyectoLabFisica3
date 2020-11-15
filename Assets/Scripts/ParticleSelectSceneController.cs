using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParticleSelectSceneController : MonoBehaviour
{
    private RuntimeData runtimeData;
    private Particle[] particlesData =
    {
                     // Name      // Charge         // Mass
        new Particle("Electrón", -1.602176565e-19, 9.10938291e-31),
        new Particle("Positrón", 1.602176487e-19, 9.10938215e-31),
        new Particle("Protón", 1.602176487e-19, 1.672621898e-27),
        new Particle("Neutrón", 0f, 1.67492729e-27),
        new Particle("Partícula Alfa", 3.204352974e-19, 6.695098376e-27),
        new Particle("Núcleo de Oro", 1.265719425e-17, 3.2707065562e-25)
    };

    void Start()
    {
        runtimeData = GameObject.Find("RuntimeData").GetComponent<RuntimeData>();
    }

    public void NextButton()
    {
        runtimeData.initializeParticles(particlesData[1], particlesData[2], particlesData[4]); // TO-DO: Particulas de prueba solamente hasta tener UI
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
