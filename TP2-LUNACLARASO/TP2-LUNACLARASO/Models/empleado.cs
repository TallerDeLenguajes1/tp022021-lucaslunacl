using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP2_LUNACLARASO.Models
{
    public class empleado
    {
        private string nombre;
        private string apellido;
        private int edad;
        private string domicilio;
        private int antiguedad;
        private double salario;
        private DateTime fechaingreso;
        private const float sueldo_base = 25000;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public int Antiguedad { get => antiguedad; set => antiguedad = value; }
        public double Salario { get => salario; set => salario = value; }
        public DateTime Fechaingreso { get => fechaingreso; set => fechaingreso = value; }

        public static float Sueldo_base => sueldo_base;


        public int calcularAntiguedad(DateTime fecha)
        {
            int fechas = (DateTime.Today - fecha).Days;
            return Convert.ToInt32(fechas / 365.25);
        }

        public int calcularSalario(int antiguedad)
        {
            if (antiguedad < 20)
            {
                return (int)((sueldo_base * 0.85) + sueldo_base * ((double)antiguedad / 100));
            }
            else
            {
                return (int)(sueldo_base * 0.85 + sueldo_base * 0.25);
            }
        }

        public empleado(string nombre, string apellido, DateTime fechaIngreso)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaingreso = fechaIngreso;

            salario = calcularSalario(antiguedad);
            antiguedad = calcularAntiguedad(fechaIngreso);
        }
    }


}
