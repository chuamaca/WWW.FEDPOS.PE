

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Caja")]
    public class Caja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Caja { get; set; }
        public string Descripcion { get; set; }
        public string Tema { get; set; }
        public string Serial_PC { get; set; }
        public string Impresora_Ticket { get; set; }
        public string Impresora_A4 { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string PuertoBalanza { get; set; }
        public string EstadoBalanza { get; set; }


    }
}
