using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Windows.Input;


public class MainViewModel : INotifyPropertyChanged
{
    public ICommand CalcularIMCCommand { get; }

    public MainViewModel()
    {
        CalcularIMCCommand = new Command(CalcularIMC);
        Persona = new Persona();
    }
    public event PropertyChangedEventHandler PropertyChanged;

    private Persona _persona;

    public Persona Persona
    {
        get { return _persona; }
        set
        {
            if (_persona != value)
            {
                _persona = value;
                OnPropertyChanged(nameof(Persona));
            }
        }
    }

    

    // Método para calcular el IMC y el estado nutricional
    public void CalcularIMC()
    {
        // Fórmula para el cálculo del IMC
        Persona.IMC = Persona.Peso / (Persona.Estatura * Persona.Estatura);

        // Determinar el estado nutricional según la OMS
        if (Persona.IMC < 18.5)
            Persona.EstadoNutricional = "Peso bajo";
        else if (Persona.IMC < 24.9)
            Persona.EstadoNutricional = "Peso normal";
        else if (Persona.IMC < 29.9)
            Persona.EstadoNutricional = "Sobrepeso";
        else if (Persona.IMC < 34.9)
            Persona.EstadoNutricional = "Obesidad";
        else
            Persona.EstadoNutricional = "Obesidad extrema";

        OnPropertyChanged(nameof(Persona));
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
// Gravedad	Código	Descripción	Proyecto	Archivo	Línea	Estado suprimido
//Error CS0111		APP_IMC (net7.0-android), APP_IMC(net7.0 - ios), APP_IMC(net7.0 - maccatalyst), APP_IMC(net7.0 - windows10.0.19041.0)  C: \Users\Francisco\OneDrive\Documentos\TECNM\APP_IMC\APP_IMC\ViewModel\MainViewModel.cs	36	Activo

