using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ortopedia.BE;

namespace Ortopedia.UI.Shared
{
    public class Funciones
    {
        public enum Catalogos
        {
            Especialidad = 1,
            Telefonos = 2,
            Mails = 3,
            Tamaños = 4,
            Bancos = 5,
            Privilegios = 6,
            Estados = 7,
            Ciudades = 8,
            Puestos = 9,
            ProductosOrtopedia = 13,
            NumerosCalzado = 10,
            EstantesOrtopedia = 11,
            DepartamentosOrtopedia = 12,
            ProveedoresOrtopedia = 13
        }

        /// <summary>
        /// Obtiene Catalogos
        /// </summary>
        /// <param name="tipoCatalogo">Tipo de Catálogo a cargar</param>
        /// <param name="control">Control al que se le quiere asignar el catalogo</param>
        /// <param name="filtro1">Filtro 1 para el catálogo</param>
        /// <param name="filtro2">Filtro 2 para el catálogo</param>
        /// <param name="filtro3">Filtro 3 para el catálogo</param>
        /// <param name="filtro4">Filtro 4 para el catálogo</param>
        /// <param name="filtro5">Filtro 5 para el catálogo</param>
        /// <param name="filtro6">Filtro 6 para el catálogo</param>
        public static void CargarCatalogo(Catalogos tipoCatalogo, ComboBox control, string filtro1, string filtro2, string filtro3, string filtro4, bool ItemCero)
        {
            List<CatalogosBE> catalogo = new List<CatalogosBE>();
            //catalogo = new SEP.Danos.DañosService.DanosServiceClient().ObtenerCatalogo((int)tipoCatalogo, filtro1, filtro2, filtro3, filtro4, filtro5, filtro6);
            catalogo = new OrtopediaService.OrtopediaServiceClient().ObtieneCatalogosGenerales((int)tipoCatalogo, "", "", "", "");
            if (ItemCero)
            {
                ComboItem firstItem = new ComboItem();
                firstItem.Text = "[Selecciona una opción]";
                firstItem.Value = "0";
                firstItem.Tag = "0";
                control.Items.Add(firstItem);
            }

            foreach (CatalogosBE c in catalogo)
            {
                ComboItem item = new ComboItem();
                item.Value = c.Id;
                item.Text = c.Descripcion.TrimEnd();
                item.Tag = c.Tag;
                control.Items.Add(item);
            }
            control.SelectedIndex = 0;
        }


        public static void LlenarDropDownCatalogo(ComboBox ddl, bool itemCero, List<CatalogosBE> catalogo)
        {
            if (itemCero)
            {
                ComboItem firstItem = new ComboItem();
                firstItem.Text = "[Selecciona una opción]";
                firstItem.Value = "0";
                firstItem.Tag = "0";
                ddl.Items.Add(firstItem);

            }

            foreach (var c in catalogo)
            {
                ComboItem item = new ComboItem();
                item.Value = c.Id;
                item.Text = c.Descripcion.TrimEnd();
                //item.Tag = c.Tag;
                ddl.Items.Add(item);
            }
            ddl.SelectedIndex = 0;
        }
    }


    public class ComboItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public object Tag { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
