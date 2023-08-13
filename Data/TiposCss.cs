using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectQT.Data
{
    public static class TiposCss
    {

        public enum CssTipoAlinear
        {
            NotSet,
            Left,
            Center,
            Right
        };

        public enum CssColorBoostrap
        {
            primary,
            secondary,
            success,
            danger,
            warning,
            info,
            light,
            dark
        };

        public static string DarColor(CssColorBoostrap color, string tipo)
        {
            var x = "";
            switch (color)
            {
                case CssColorBoostrap.primary:
                    x = $"{tipo}-primary";
                    break;
                case CssColorBoostrap.secondary:
                    x = $"{tipo}-secondary";
                    break;
                case CssColorBoostrap.success:
                    x = $"{tipo}-success";
                    break;
                case CssColorBoostrap.danger:
                    x = $"{tipo}-danger";
                    break;
                case CssColorBoostrap.warning:
                    x = $"{tipo}-warning";
                    break;
                case CssColorBoostrap.info:
                    x = $"{tipo}-info";
                    break;
                case CssColorBoostrap.light:
                    x = $"{tipo}-light";
                    break;
                case CssColorBoostrap.dark:
                    x = $"{tipo}-dark";
                    break;

            }

            return x;
        }

        public static string AlinearTexto(CssTipoAlinear alinear)
        {
            var x = "";
            switch (alinear)
            {
                case CssTipoAlinear.NotSet:
                    x = "text-align: NotSet";
                    break;
                case CssTipoAlinear.Center:
                    x = "text-align: Center";
                    break;
                case CssTipoAlinear.Left:
                    x = "text-align: Left";
                    break;
                case CssTipoAlinear.Right:
                    x = "text-align: Right";
                    break;

            }

            return x;
        }


        public static type GetRandomEnumValue<type>(this Random random)
        {
            var values = Enum.GetValues(typeof(type));
            return (type)values.GetValue(random.Next(values.Length));
        }
    }

}
