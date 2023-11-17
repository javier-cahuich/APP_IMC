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
    //Comando para el boton calcular 
    public ICommand CalcularIMCCommand { get; }

    //Constructor de la clase
    public MainViewModel()
    {
        //Inicializar el comando para el boton Calcular 
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

        //notificar a las vistas que la propiedad Persona ha cambiado
        OnPropertyChanged(nameof(Persona));
    }

    //notificar cambios en las propiedades a las vistas
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

