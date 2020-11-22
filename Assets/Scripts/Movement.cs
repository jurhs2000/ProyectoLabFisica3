using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Particle particleInfo;
    private SimulationSceneController simulationSceneController;
    public float timeDelay; // Retraso para cada particula (Se indica en SimulationSceneController cuando se inicializa la particula)
    private float time; // Tiempo real de la particula
    private float timeSelector0; // Tiempo inicial para el selector de velocidades
    private double x0;  // Posicion inicial en x del objeto en unity
    private double y0;  // Posicion inicial en y del objeto en unity
    private bool deselected = false; // Si es true, la particula fue deselecta por el selector de velocidades y ya no se haran sus calculos

    // Start is called before the first frame update
    void Start()
    {
        simulationSceneController = GameObject.Find("SceneController").GetComponent<SimulationSceneController>();
        x0 = gameObject.transform.position.x;
        y0 = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        time = simulationSceneController.timer.deltaT - timeDelay; // Calcula tiempo real de salida de cada particula
        if (simulationSceneController.isPlay && time > 0 && !deselected)
        {
            particleInfo.x = particleInfo.velocity * time;  // Calculo de posicion lineal en X
            // Aplicacion de fuerzas del selector de velocidades
            Transform selectorTrigger = simulationSceneController.magneticElectricForceTrigger.transform;
            if (gameObject.transform.position.x > (selectorTrigger.position.x - (selectorTrigger.localScale.x / 2)) &&  // Entrada al selector de velocidades
                gameObject.transform.position.x < (selectorTrigger.position.x + (selectorTrigger.localScale.x / 2)))    // Salida del selector de velocidades
            {
                /**
                 * Si la fuerza magnetica y electrica NO son iguales (la particula no va a ser seleccionada)
                 * y sufre una aceleracion en el eje Y.
                 * Fuerza electrica = q*E;  campo electrico E = V/d; Fuerza magnetica = q*v*B
                 * Se cancelan las cargas.
                 */
                // Se desprecia carga de particula en ambas fuerzas ya que sera cancelada
                particleInfo.electricForce = simulationSceneController.runtimeData.electricField;
                particleInfo.magneticForce = simulationSceneController.runtimeData.magneticFieldSelector * particleInfo.velocity;
                if (particleInfo.electricForce != particleInfo.magneticForce)
                {
                    particleInfo.acceleration = (particleInfo.electricForce - particleInfo.magneticForce) / particleInfo.mass;
                    // Movimiento simulado en el eje Y, ya que este realmente es muy grande.
                    particleInfo.y = (double)((particleInfo.acceleration * Mathf.Pow((time - timeSelector0),2))/2);
                    particleInfo.y = (particleInfo.y / Mathf.Abs((float)particleInfo.y)) * (Mathf.Log10(Mathf.Abs((float)particleInfo.y)))/8;
                    // Comprobar extremos del selector para parar la particula
                    if (gameObject.transform.position.y > (selectorTrigger.position.y + (selectorTrigger.localScale.y / 2)) ||  // Extremo superior
                        gameObject.transform.position.y < (selectorTrigger.position.y - (selectorTrigger.localScale.y / 2)))    // Extremo inferior
                    {
                        deselected = true;
                    }
                }
            } else
            {
                timeSelector0 = time;
            }
            // Aplica las posiciones calculadas respecto a su posicion inicial del objeto en la escena 
            gameObject.transform.position = new Vector3((float)(x0 + particleInfo.x), (float)(y0 + particleInfo.y), 0);
        }
    }

}
