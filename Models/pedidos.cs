﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPagos.Models
{
    public class pedidos
    {
        public int Id { get; set; }

        public string Cliente { get; set; }

        public string Producto { get; set; }

        public int Cantidad { get; set; }
    }
}
