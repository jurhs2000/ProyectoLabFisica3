using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SimulationSceneController : MonoBehaviour
{
    public RuntimeData runtimeData;

    // Controls
    public Image playpause;
    public Sprite playSprite;
    public Sprite pauseSprite;
    public bool isPlay = false;

    // Prefabs para generar particulas
    static int n_poblation = 100;
    public GameObject poblation1Object;
    public GameObject poblation2Object;
    public GameObject poblation3Object;
    public GameObject type1;
    public GameObject type2;
    public GameObject type3;

    // Referencias para que accedan a ellas todas las particulas
    public Timer timer; // Script de timer a partir del objeto Timer (Text) que muestra el tiempo en pantalla
    public GameObject magneticElectricForceTrigger; // Trigger manual para detectar cuando las particulas entran al selector de velocidades
    public GameObject magneticFieldDeflectorTrigger; // Trigger manual para detectar cuando las particulas entran al deflector

    // Objetos de interfaz
    public TMP_Text voltaje;
    public TMP_Text EFieldSelector;
    public TMP_Text MFieldSelector;
    public TMP_Text velocitySelected;
    public TMP_Text MFieldDeflector;

    // Start is called before the first frame update
    void Start()
    {
        runtimeData = GameObject.Find("RuntimeData").GetComponent<RuntimeData>();
        float timeDelay = 0.0000f;
        // Crea las 100 instancias de cada una de las particulas y copia los datos de las que vienen de RuntimeData (que ya traen la velocidad)
        for (int i = 0; i < n_poblation; i++)
        {
            // Particulas tipo 1
            var newParticle1 = Instantiate(type1, new Vector3(-25, -3, 0), Quaternion.identity);
            newParticle1.gameObject.GetComponent<Movement>().particleInfo = new Particle(runtimeData.poblation1[i].name, runtimeData.poblation1[i].charge,
                                                                                         runtimeData.poblation1[i].mass, runtimeData.poblation1[i].velocity);
            newParticle1.transform.parent = poblation1Object.transform; // Para ponerlo dentro del objeto Poblation1 y que esté ordenado :)
            newParticle1.gameObject.GetComponent<Movement>().timeDelay = timeDelay;
            newParticle1.gameObject.GetComponent<Movement>().type = 1;
            timeDelay += 0.0005f;
            // Particulas tipo 2
            var newParticle2 = Instantiate(type2, new Vector3(-25, -3, 0), Quaternion.identity);
            newParticle2.gameObject.GetComponent<Movement>().particleInfo = new Particle(runtimeData.poblation2[i].name, runtimeData.poblation2[i].charge,
                                                                                         runtimeData.poblation2[i].mass, runtimeData.poblation2[i].velocity);
            newParticle2.transform.parent = poblation2Object.transform; // Para ponerlo dentro del objeto Poblation2 y que esté ordenado :)
            newParticle2.gameObject.GetComponent<Movement>().timeDelay = timeDelay;
            newParticle2.gameObject.GetComponent<Movement>().type = 2;
            timeDelay += 0.0005f;
            // Particulas tipo 3
            var newParticle3 = Instantiate(type3, new Vector3(-25, -3, 0), Quaternion.identity);
            newParticle3.gameObject.GetComponent<Movement>().particleInfo = new Particle(runtimeData.poblation3[i].name, runtimeData.poblation3[i].charge,
                                                                                         runtimeData.poblation3[i].mass, runtimeData.poblation3[i].velocity);
            newParticle3.transform.parent = poblation3Object.transform; // Para ponerlo dentro del objeto Poblation3 y que esté ordenado :)
            newParticle3.gameObject.GetComponent<Movement>().timeDelay = timeDelay;
            newParticle3.gameObject.GetComponent<Movement>().type = 3;
            timeDelay += 0.0005f;
        }
        // Estableciendo textos
        voltaje.text = "Voltaje = " + runtimeData.voltage + " V";
        EFieldSelector.text = "Campo Eléctrico = " + runtimeData.electricField + " N/C";
        MFieldSelector.text = "Campo Magnético = " + runtimeData.magneticFieldSelector + " T";
        velocitySelected.text = "Velocidad seleccionada = " + System.Convert.ToInt32(runtimeData.electricField / runtimeData.magneticFieldSelector) + " m/s";
        MFieldDeflector.text = "Campo magnético = " + runtimeData.magneticFieldDeflector + " T";
    }

    public void BackButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void resetlvl()
    {
        SceneManager.LoadScene("Simulation");
    }

    public void changePlayPause()
    {
        if (isPlay)
        {
            playpause.sprite = playSprite;
            isPlay = false;
        }
        else
        {
            playpause.sprite = pauseSprite;
            isPlay = true;
        }
    }
}
