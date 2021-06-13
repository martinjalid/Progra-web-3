using Progra_web_3_Tp_final.Models;
using System;

namespace Progra_web_3_Tp_final.Servicios
{
    public class ArticulosServicio : IArticulosServicio
    {
        private _20211CTPContext _dbContext;

        public ArticulosServicio(_20211CTPContext dbContext)
        {
            _dbContext = new _20211CTPContext();
        }

        public void Alta(Articulo art)
        {
            _dbContext.Articulos.Add(art);
            _dbContext.SaveChanges();
        }
    }
}
