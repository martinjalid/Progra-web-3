using Progra_web_3_Tp_final.Models;
using System;

namespace Progra_web_3_Tp_final.Servicios
{
    public class UsuariosServicio : IUsuariosServicio
    {
        private _20211CTPContext _dbContext;

        public UsuariosServicio(_20211CTPContext dbContext)
        {
            _dbContext = new _20211CTPContext();
        }

        public void CrearNuevo(Usuario user)
        {
         _dbContext.Usuarios.Add(user);
         _dbContext.SaveChanges();
        }

        public void EditarUsuario(Usuario user)
        {
            _dbContext.Usuarios.Remove(user);
            _dbContext.SaveChanges();
        }

        public Usuario ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
