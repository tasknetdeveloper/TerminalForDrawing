using System;
using Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TerminalTest
{
    public class CommonBase
    {
        protected OutputType GetOutputType(string Name)
        {
            var result = GetEnum<OutputType>(Name);
            return result;
        }

        protected FigureType GetFigureType(string Name)
        {
            var result = GetEnum<FigureType>(Name);
            return result;
        }
       
        protected T GetEnum<T>(string Name)
        {
            T result = default(T);
            if (string.IsNullOrEmpty(Name)) return result;            
            Name = GetNormalizeEnumStr(Name);
            object obj = null;
            Enum.TryParse(typeof(T), Name, out obj);
            if (obj != null) result = (T)obj;
            return result;
        }

        internal string GetNormalizeEnumStr(string Name)
        {
            var result = "";
            if (string.IsNullOrEmpty(Name)) return result;
            result = Name.Substring(0, 1).ToUpper() + ((Name.Length>1)? Name.Substring(1).ToLower():"");
            return result;
        }

        #region utils
        internal (FigureParameterName fgName, object val) GetPair(string s, string separator = "=")
        {
            var Name = FigureParameterName.Empty;
            object Val = null;
            if (string.IsNullOrEmpty(s)) return (Name, Val);
            s = GetNormalizeEnumStr(s);
            var arr = s.Split(separator);
            if (arr != null && arr.Length == 2)
            {
                object obj = null;
                Enum.TryParse(typeof(FigureParameterName), arr[0], out obj);
                if (obj != null)
                    Name = (FigureParameterName)obj;
                //int.TryParse(arr[1], out Val);
                Val = arr[1];
            }
            return (Name, Val);
        }

        internal string SaveCanvasToFile(Canvas canvas, int dpi, string filename)
        {
            var result = "";
            try
            {
                if (canvas == null) throw new Exception("canvas can not equal null");
                Size size = new Size(canvas.ActualWidth, canvas.ActualHeight);
                canvas.Measure(size);

                var rtb = new RenderTargetBitmap(
                                                    (int)canvas.ActualWidth, 
                                                    (int)canvas.ActualHeight,
                                                    dpi,
                                                    dpi,
                                                    PixelFormats.Pbgra32 
                                                    );
                rtb.Render(canvas);

                SaveRTBAsPNGBMP(rtb, filename);
            }
            catch (Exception exp)
            {
                result = exp.Message;
            }
            return result;
        }


        private void SaveRTBAsPNGBMP(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));

            using (var stm = System.IO.File.Create(filename))
            {
                enc.Save(stm);
            }
        }

        internal System.Windows.Point[] GetPoints(string s, char separator, char separatorInside)
        {
            System.Windows.Point[] result = null;
            if (string.IsNullOrEmpty(s))
                return result;
            var arr = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (arr == null) return null;
            result = new Point[arr.Length];
            var i = 0;
            double v = 0;
            foreach (var item in arr)
            {
                var arr2 = item.Split(separatorInside, StringSplitOptions.RemoveEmptyEntries);
                if (arr2 != null && arr2.Length == 2)
                {
                    if (double.TryParse(arr2[0], out v))
                        result[i].X = v;
                    if (double.TryParse(arr2[1], out v))
                        result[i].Y = v;
                    i++;
                }
            }

            return result;
        }
        #endregion
    }
}
