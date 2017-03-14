using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev {

    public class Personne {
    private string _nom;
    private string _prenom;
    private int _age;

    public Personne() : this("Skywalker", "Anakin", 25) { }

    public Personne(string nom, string prenom, int age)
    {
        this._nom = nom;
        this._prenom = prenom;
        this._age = age;
    }

    public void SePresenter()
    {
        Console.WriteLine("Bonjour, je suis " + this._prenom + " " + this._nom + " et j'ai " + this._age);
    }
}