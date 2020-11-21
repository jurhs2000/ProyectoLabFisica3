using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeData : MonoBehaviour
{
    // Poblacion de particulas
    static int n_poblation = 100;
    public Particle[] poblation1 = new Particle[n_poblation];
    public Particle[] poblation2 = new Particle[n_poblation];
    public Particle[] poblation3 = new Particle[n_poblation];
    // TO DO: Data de los otros parametros de la simulacion
    public double platesDistance = 0.005; // metros
    public double voltage = 12; // volts
    public double electricField;
    public double magneticFieldSelector = 1; // tesla
    public double magneticFieldDeflector = 1; // tesla
    // Otros
    public static RuntimeData instance; // Static para que sea la misma en toda la simulacion

    void Awake() // Al iniciarse en cada escena prueba...
    {
        if (instance == null) // si es la primera ejecucion, se pone el mismo como la instancia estatica
            instance = this;
        else // Si ya se cargo antes, se destruye para no tenerlo duplicado
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); // El objeto original no se destruye
    }

    /**
     * Seleccionados los tres tipos de particulas, se hace que todos los objetos
     * de las 3 poblaciones sean cada uno de un tipo
     */
    public void initializeParticles(Particle type1, Particle type2, Particle type3)
    {
        for (int i = 0; i < n_poblation; i++)
        {
            poblation1[i] = new Particle(type1.name, type1.charge, type1.mass);
            poblation2[i] = new Particle(type2.name, type2.charge, type2.mass);
            poblation3[i] = new Particle(type3.name, type3.charge, type3.mass);
        }
    }

    /**
     * Genera las velocidades random para cada particula de las 3 poblaciones
     * en el rango establecido en los parametros de entrada (en metros/segundos)
     */
    public void setRandomVelocity(int minVelocity, int maxVelocity)
    {
        for (int i = 0; i < n_poblation; i++)
        {
            poblation1[i].velocity = Random.Range(minVelocity, maxVelocity);
            poblation2[i].velocity = Random.Range(minVelocity, maxVelocity);
            poblation3[i].velocity = Random.Range(minVelocity, maxVelocity);
        }

        // Ya que este metodo es llamado al pasar a la simulacion
        // aprovechamos para calcular el campo electrico
        calculateElectricField();
    }

    private void calculateElectricField()
    {
        electricField = voltage / platesDistance;
    }
}
