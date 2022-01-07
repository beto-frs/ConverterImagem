using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterIMG
{
    public class ConverterImagem
    {
        string Arquivo = @"D:\Users\beto-\Pictures\3x4.png";
        public byte[] _imageArray { get; private set; }
        public string _imageBase64 { get; private set; }

        public string ext { get; private set; }

        public void ConverterBase64()
        {
            ext = Arquivo.Split('.').Last();
            byte[] ArrayByte = File.ReadAllBytes(Arquivo);
            string ImageBase64 = Convert.ToBase64String(ArrayByte);

            _imageArray = ArrayByte;
            _imageBase64 = ImageBase64;

            RestaurarImagem();

        }

        public void RestaurarImagem()
        {
            
            byte[] bytes = Convert.FromBase64String(_imageBase64);
            string arquivoConvertido = @$"{DateTime.Now.ToString("ddd-ss")}.{ext}";
            File.WriteAllBytes(@$"E:\{arquivoConvertido}", bytes);
            File.Copy(@$"E:\{arquivoConvertido}", @$"E:\CONSEGUI\{arquivoConvertido}");

        }
    }
}
