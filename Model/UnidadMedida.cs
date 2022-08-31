

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("UnidadMedida")]
    public class UnidadMedida
    {

        //public UnidadMedida()
        //{
        //    Producto = new HashSet<Producto>();

        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Idunidad { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        //public virtual ICollection<Producto> Producto { get; set; }

        public List<UnidadMedida> ListarUnidadMedida()
        {
            var listaum = new List<UnidadMedida>();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    listaum = ctx.UnidadMedida.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listaum;
        }
    }
}
