﻿using System.Collections.Generic;
using Data = DataLayer;
using Entity = EntityLayer;

namespace BusinessLayer
{
    public class Product
    {
        private readonly Data.Product _Db = new Data.Product();

        public bool Create(Entity.Product product, out string message)
        {
            // Validar Nombre
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrWhiteSpace(product.Name))
            {
                message = "El campo \"Nombre\" no puede ser vacio.";
                return false;
            }

            // Descripcion por defecto
            if (string.IsNullOrEmpty(product.Description) || string.IsNullOrWhiteSpace(product.Description))
            {
                product.Description = "Este producto no tiene descripción.";
            }

            return _Db.Create(product, out message);
        }

        public List<Entity.Product> Read()
        {
            return _Db.Read();
        }

        public bool Update(Entity.Product product, out string message)
        {
            // Validar Nombre
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrWhiteSpace(product.Name))
            {
                message = "El campo \"Nombre\" no puede ser vacio.";
                return false;
            }

            return _Db.Update(product, out message);
        }

        public bool Delete(Entity.Product product, out string message)
        {
            return _Db.Delete(product, out message);
        }
    }
}