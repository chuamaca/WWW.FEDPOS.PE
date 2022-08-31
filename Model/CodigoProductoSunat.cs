

namespace Model
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
  

    [Table("CodigoProductoSunat")]
    public class CodigoProductoSunat
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Idcodigo { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigo { get; set; }

      
        public string descripcion { get; set; }

        public ResponseModel  InsertarcodigosProductosSunat(HttpPostedFileBase archivotxt)
        {
            var rm = new ResponseModel();
            try
            {
                string ruta = string.Empty;
                if (archivotxt!=null)
                {
                    string path = HttpContext.Current.Server.MapPath("~/Areas/Admin/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    ruta = path + Path.GetFileName(archivotxt.FileName);
                    string extension = Path.GetExtension(archivotxt.FileName);
                    archivotxt.SaveAs(ruta);
                    string csvData = System.IO.File.ReadAllText(ruta);

                    using (var cnx = new ProyectoContext())
                    {
                        string sql = "BULK INSERT CodigoProductoSunat " + "FROM '" + ruta + "' WITH (" + "CODEPAGE = 'ACP'," + "FIELDTERMINATOR = ';'," + "ROWTERMINATOR = '\n')";
                     //   string sql = "BULK INSERT CodigoSunat " + "FROM '" + ruta + "' WITH (" +  "FIELDTERMINATOR = ';'," + "ROWTERMINATOR = '\r\n')";

                        cnx.Database.ExecuteSqlCommand(sql);

                        rm.SetResponse(true);
                    }
                }
             }
            catch (Exception)
            {

                throw;
            }


            return rm;
        }

    }
}
