﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Progra_web_3_Tp_final.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ArticuloBorradoPorNavigations = new HashSet<Articulo>();
            ArticuloCreadoPorNavigations = new HashSet<Articulo>();
            ArticuloModificadoPorNavigations = new HashSet<Articulo>();
            ClienteBorradoPorNavigations = new HashSet<Cliente>();
            ClienteCreadoPorNavigations = new HashSet<Cliente>();
            ClienteModificadoPorNavigations = new HashSet<Cliente>();
            InverseBorradoPorNavigation = new HashSet<Usuario>();
            InverseCreadoPorNavigation = new HashSet<Usuario>();
            InverseModificadoPorNavigation = new HashSet<Usuario>();
            PedidoBorradoPorNavigations = new HashSet<Pedido>();
            PedidoCreadoPorNavigations = new HashSet<Pedido>();
            PedidoModificadoPorNavigations = new HashSet<Pedido>();
        }

        public int IdUsuario { get; set; }
        public bool EsAdmin { get; set; }
        
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaUltLogin { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public int? ModificadoPor { get; set; }
        public int? CreadoPor { get; set; }
        public int? BorradoPor { get; set; }

        public virtual Usuario BorradoPorNavigation { get; set; }
        public virtual Usuario CreadoPorNavigation { get; set; }
        public virtual Usuario ModificadoPorNavigation { get; set; }
        public virtual ICollection<Articulo> ArticuloBorradoPorNavigations { get; set; }
        public virtual ICollection<Articulo> ArticuloCreadoPorNavigations { get; set; }
        public virtual ICollection<Articulo> ArticuloModificadoPorNavigations { get; set; }
        public virtual ICollection<Cliente> ClienteBorradoPorNavigations { get; set; }
        public virtual ICollection<Cliente> ClienteCreadoPorNavigations { get; set; }
        public virtual ICollection<Cliente> ClienteModificadoPorNavigations { get; set; }
        public virtual ICollection<Usuario> InverseBorradoPorNavigation { get; set; }
        public virtual ICollection<Usuario> InverseCreadoPorNavigation { get; set; }
        public virtual ICollection<Usuario> InverseModificadoPorNavigation { get; set; }
        public virtual ICollection<Pedido> PedidoBorradoPorNavigations { get; set; }
        public virtual ICollection<Pedido> PedidoCreadoPorNavigations { get; set; }
        public virtual ICollection<Pedido> PedidoModificadoPorNavigations { get; set; }
    }
}
