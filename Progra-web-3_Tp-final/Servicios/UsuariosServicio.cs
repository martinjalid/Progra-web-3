﻿using Progra_web_3_Tp_final.Models;
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

        public Usuario ObtenerPorId(int id)
        {
            return _dbContext.Usuarios.Find(id);
        }

        public void CrearNuevo(Usuario user)
        {
         _dbContext.Usuarios.Add(user);
         _dbContext.SaveChanges();
        }

        public void ModificarUsuario(Usuario user)
        {
            Usuario userNuevo = ObtenerPorId(user.IdUsuario);
            userNuevo.Email = user.Email;
            userNuevo.Password = user.Password;
            userNuevo.EsAdmin = user.EsAdmin;
            userNuevo.Nombre = user.Nombre;
            userNuevo.Apellido = user.Apellido;
            userNuevo.FechaNacimiento = user.FechaNacimiento;
            _dbContext.SaveChanges();
        }

        public void Eliminar(Usuario user)
        {
            _dbContext.Usuarios.Remove(user);
            _dbContext.SaveChanges();
        }


    }
}
