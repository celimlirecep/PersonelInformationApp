using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace PersonelList.Areas.Admin.Model
{
    public static class HelperClass
    {

        
        public static string ImportImage(HttpPostedFileBase fileImage,string temporaryPath,string newPath)
        {
            string pathResized = "";
            var extension = Path.GetExtension(fileImage.FileName).ToLower();
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
            {
                try
                {
                    string randomName = string.Format($"{Guid.NewGuid()}-{fileImage.FileName}");
                    var TemporaryPath = Path.Combine(temporaryPath, randomName);
                    fileImage.SaveAs(TemporaryPath);
                    using (Bitmap realImage = new Bitmap(TemporaryPath))
                    {
                        int height, width = 0;
                        if (realImage.Width > realImage.Height)
                        {
                            width = 250;
                            height = 250 * realImage.Height / realImage.Width;
                        }
                        else
                        {
                            height = 250;
                            width = 250 * realImage.Width / realImage.Height;
                        }

                        Size newSize = new Size(width, height);

                        Bitmap newImage = new Bitmap(realImage, newSize);

                        // resmi istenen klasöre kaydedelim

                        pathResized = Path.Combine(newPath, randomName);

                        newImage.Save(pathResized, ImageFormat.Jpeg);

                        realImage.Dispose();
                    }
                    FileInfo fi = new FileInfo(TemporaryPath);
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    //Genel log kaydı tutulmalı
                    Console.WriteLine(nameof(Register) + "Fonkiyonunda resim yükleme işlemi yaparken hata çıkmıştır. Hata mesajı: " + ex.Message);
                }
                return pathResized;

            }
            else
            {
                return "";
            }

        }
    }
}