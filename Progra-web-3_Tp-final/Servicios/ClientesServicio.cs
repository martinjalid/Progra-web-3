using Progra_web_3_Tp_final.Models;
using System;

namespace Progra_web_3_Tp_final.Servicios
{
    public class ClientesServicio : IClientesServicio
    {
        private _20211CTPContext _dbContext;

        public ClientesServicio(_20211CTPContext dbContext)
        {
            _dbContext = new _20211CTPContext();
        }

        public Cliente ObtenerPorId(int id)
        {
            return _dbContext.Clientes.Find(id);
        }

        //public Cliente ObtenerPorNumero(int numero)
        //{
        //    return _dbContext.Clientes(c => c.Numero == numero);
        //}

        public void Alta(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void Eliminar(Cliente cliente)
        {
            _dbContext.Clientes.Remove(cliente);
            _dbContext.SaveChanges();
        }


    }
}
