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
    public double platesDistance = 5;
    public double voltage = 12;
    public double magneticFieldSelector = 1;
    public double magneticFieldDeflector = 1;
    // --
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

    public void initializeParticles(Particle type1, Particle type2, Particle type3)
    {
        for (int i = 0; i < n_poblation; i++)
        {
            poblation1[i] = type1;
            poblation2[i] = type2;
            poblation3[i] = type3;
        }
    }
}
