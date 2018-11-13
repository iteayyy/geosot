﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeoSOT
{
    public class TileUtils
    {
        #region 度分秒转换

        /// <summary>
        /// 将十进制经纬度转换为DMS字符串表达，秒保留4位精度
        /// </summary>
        /// <param name="dd">十进制经纬度</param>
        /// <returns>dms字符串</returns>
        private string DecimalDgreeToDMS(double dd, int precision = 4)
        {
            var degrees = (int)dd;
            var minutes = (dd - degrees) * 60;
            var seconds = ((minutes - (int)minutes) * 60);
            return string.Format("{0}° {1}' {2}\"",
                Math.Abs(degrees), Math.Abs((int)minutes),
                Math.Round(Math.Abs(seconds), precision));
        }

        /// <summary>
        /// 将DMS字符串转换为十进制经纬度，保留6位精度
        /// </summary>
        /// <param name="dms"></param>
        /// <returns></returns>
        private double DMSToDecimalDgree(string dms, int precision = 6)
        {
            var list = dms.Split(new char[] { '°', '\'', '\"' });
            var degrees = double.Parse(list[0].Trim(' '));
            var minutes = double.Parse(list[1].Trim(' ')) / 60;
            var seconds = double.Parse(list[2].Trim(' ')) / 3600;
            return Math.Round(degrees + minutes + seconds, precision);
        }

        /// <summary>
        /// 纬度转换为度分秒
        /// </summary>
        /// <param name="lat">维度</param>
        /// <returns>*度*分*秒</returns>
        public string GetLatDMS(double lat)
        {
            var dms = DecimalDgreeToDMS(lat);
            return string.Format("{0} {1}",
                dms, lat < 0 ? "S" : "N");
        }

        /// <summary>
        /// 经度转换为度分秒
        /// </summary>
        /// <param name="lng">经度</param>
        /// <returns>*度*分*秒</returns>
        public string GetLngDMS(double lng)
        {
            var dms = DecimalDgreeToDMS(lng);
            return string.Format("{0} {1}",
                dms, lng < 0 ? "W" : "E");
        }

        /// <summary>
        /// 度分秒维度转换为十进制度
        /// </summary>
        /// <param name="lat"></param>
        /// <returns></returns>
        public double GetLat(string dms)
        {
            var result = DMSToDecimalDgree(dms);
            if (dms.IndexOf("S") >= 0) { result = -result; }
            else if (dms.IndexOf("N") >= 0) { }
            else { throw new ArgumentException(); }
            return result;
        }

        /// <summary>
        /// 度分秒经度转换为十进制度
        /// </summary>
        /// <param name="dms"></param>
        /// <returns></returns>
        public double GetLng(string dms)
        {
            var result = DMSToDecimalDgree(dms);
            if (dms.IndexOf("W") >= 0) { result = -result; }
            else if (dms.IndexOf("E") >= 0) { }
            else { throw new ArgumentException(); }
            return result;
        }

        #endregion

        public Int32 EncodeLat(double lat)
        {
            throw new NotImplementedException();
            //var segs = new LngLatSegments(lat);

            //return segs.G << 31 & segs.D << 23 & segs.M << 17 & segs.S << 11 & segs.S11;
        }

        public Int32 EncodeLng(double lng)
        {
            throw new NotImplementedException();
        }

        public double DecodeLat(Int32 latKey)
        {
            throw new NotImplementedException();
        }

        public double DecodeLng(Int32 lngKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 北京世纪坛（39°54′37″N，116°18′54″E）
        /// 第 9 级其剖分编码为（ 39,116 ）
        /// 第 15 级为（ 39-54,116-18 ）
        /// 第 21 级为（39-54-37,116-18-54）
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        public Int64 Get1DId(double lat, double lng)
        {
            throw new NotImplementedException();
        }

        public Int32 GetLatId(Int64 quadKey)
        {
            throw new NotImplementedException();
        }

        public Int32 GetLngId(Int64 quadKey)
        {
            throw new NotImplementedException();
        }

        public Int64 Get1DId(Int32 latKey, Int32 lonKey)
        {
            throw new NotImplementedException();
        }
    }
}
