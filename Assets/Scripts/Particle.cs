using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // para que Unity pueda ver nuestras clases
public class Particle
{
    public Particle(string name, double charge, double mass)
    {
        this.name = name;
        this.charge = charge;
        this.mass = mass;
    }
    public string name;
    public double charge;
    public double mass;
    public int velocity;
    public double x;
    public double y;
    public double magneticForce;
    public double electricForce;
    public double acceleration;
    public double angle;
    public double ratio;
    public double centripetalAcceleration;
}
