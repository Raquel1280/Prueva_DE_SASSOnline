using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
///Clase para almacenar almacenar las imgenes  
/// </summary>

namespace Prueva_DE_SASS.Clase
{
    public class FileHelpers
    {
        public static string UploadPhoto(HttpPostedFileBase file, string folder)
        {
            var path = string.Empty;
            var pic = string.Empty;

            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath(folder), pic);
                file.SaveAs(path);
                using (MemoryStream memory = new MemoryStream())
                {
                    file.InputStream.CopyTo(memory);
                    byte[] array = memory.GetBuffer();
                }
            }

            return pic;

        }

    }
}