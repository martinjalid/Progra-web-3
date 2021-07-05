using Progra_web_3_Tp_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Servicios
{
    interface IArticulosServicio
    {
        Articulo ObtenerPorId(int id);
        void Alta(Articulo art);
        void Modificar(Articulo art);
        void Eliminar(Articulo art);
    }
}
