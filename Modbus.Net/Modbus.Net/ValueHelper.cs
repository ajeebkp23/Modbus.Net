﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Modbus.Net
{
    /// <summary>
    /// 值与字节数组之间转换的辅助类，这是一个Singleton类
    /// 作者：罗圣（Chris L.）
    /// </summary>
    public class ValueHelper
    {
        public Dictionary<string, double> ByteLength = new Dictionary<string, double>()
        {
            {"System.Boolean", 0.125},
            {"System.Byte", 1},
            {"System.Int16", 2},
            {"System.Int32", 4},
            {"System.Int64", 8},
            {"System.UInt16", 2},
            {"System.UInt32", 4},
            {"System.UInt64", 8},
            {"System.Single", 4},
            {"System.Double", 8}
        };

        protected ValueHelper()
        {
        }

        /// <summary>
        /// 协议中的内容构造是否小端的，默认是小端构造协议。
        /// </summary>
        public static bool LittleEndian => true;

        #region Factory

        private static ValueHelper _instance;

        protected virtual ValueHelper _Instance => _instance;

        /// <summary>
        /// ValueHelper单例的实例
        /// </summary>
        public static ValueHelper Instance => _instance ?? (_instance = new ValueHelper());

        #endregion

        /// <summary>
        /// 将一个byte数字转换为一个byte元素的数组。
        /// </summary>
        /// <param name="value">byte数字</param>
        /// <returns>byte数组</returns>
        public Byte[] GetBytes(byte value)
        {
            return new[] {value};
        }

        /// <summary>
        /// 将short数字转换为byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual Byte[] GetBytes(short value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// 将int数字转换为byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual Byte[] GetBytes(int value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// 将long数字转换为byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual Byte[] GetBytes(long value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// 将ushort数字转换为byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual Byte[] GetBytes(ushort value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// 将uint数字转换为byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual Byte[] GetBytes(uint value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// 将ulong数字转换为byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual Byte[] GetBytes(ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// 将float数字转换为byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual Byte[] GetBytes(float value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// 将double数字转换为byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual Byte[] GetBytes(double value)
        {
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// 将object数字转换为byte数组
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual Byte[] GetBytes(object value, Type type)
        {
            switch (type.FullName)
            {
                case "System.Int16":
                {
                    byte[] bytes = _Instance.GetBytes((short) value);
                    return bytes;
                }
                case "System.Int32":
                {
                    byte[] bytes = _Instance.GetBytes((int) value);
                    return bytes;
                }
                case "System.Int64":
                {
                    byte[] bytes = _Instance.GetBytes((long) value);
                    return bytes;
                }
                case "System.UInt16":
                {
                    byte[] bytes = _Instance.GetBytes((ushort) value);
                    return bytes;
                }
                case "System.UInt32":
                {
                    byte[] bytes = _Instance.GetBytes((uint) value);
                    return bytes;
                }
                case "System.UInt64":
                {
                    byte[] bytes = _Instance.GetBytes((ulong) value);
                    return bytes;
                }
                case "System.Single":
                {
                    byte[] bytes = _Instance.GetBytes((float) value);
                    return bytes;
                }
                case "System.Double":
                {
                    byte[] bytes = _Instance.GetBytes((double) value);
                    return bytes;
                }
                case "System.Byte":
                {
                    byte[] bytes = _Instance.GetBytes((byte) value);
                    return bytes;
                }
                default:
                {
                    throw new NotImplementedException("没有实现除整数以外的其它转换方式");
                }
            }
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为对应类型的数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <param name="subPos"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual object GetValue(byte[] data, ref int pos, ref int subPos, Type t)
        {
            switch (t.FullName)
            {
                case "System.Int16":
                    {
                        short value = _Instance.GetShort(data, ref pos);
                        return value;
                    }
                case "System.Int32":
                    {
                        int value = _Instance.GetInt(data, ref pos);
                        return value;
                    }
                case "System.Int64":
                    {
                        long value = _Instance.GetLong(data, ref pos);
                        return value;
                    }
                case "System.UInt16":
                    {
                        ushort value = _Instance.GetUShort(data, ref pos);
                        return value;
                    }
                case "System.UInt32":
                    {
                        uint value = _Instance.GetUInt(data, ref pos);
                        return value;
                    }
                case "System.UInt64":
                    {
                        ulong value = _Instance.GetULong(data, ref pos);
                        return value;
                    }
                case "System.Single":
                    {
                        float value = _Instance.GetFloat(data, ref pos);
                        return value;
                    }
                case "System.Double":
                    {
                        double value = _Instance.GetDouble(data, ref pos);
                        return value;
                    }
                case "System.Byte":
                    {
                        byte value = _Instance.GetByte(data, ref pos);
                        return value;
                    }
                case "System.Boolean":
                    {
                        bool value = _Instance.GetBit(data, ref pos, ref subPos);
                        return value;
                    }
                default:
                    {
                        throw new NotImplementedException("没有实现除整数以外的其它转换方式");
                    }
            }
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为byte数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual byte GetByte(byte[] data, ref int pos)
        {
            byte t = data[pos];
            pos += 1;
            return t;
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为short数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual short GetShort(byte[] data, ref int pos)
        {
            short t = BitConverter.ToInt16(data, pos);
            pos += 2;
            return t;
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为int数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual int GetInt(byte[] data, ref int pos)
        {
            int t = BitConverter.ToInt32(data, pos);
            pos += 4;
            return t;
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为long数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual long GetLong(byte[] data, ref int pos)
        {
            long t = BitConverter.ToInt64(data, pos);
            pos += 8;
            return t;
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为ushort数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual ushort GetUShort(byte[] data, ref int pos)
        {
            ushort t = BitConverter.ToUInt16(data, pos);
            pos += 2;
            return t;
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为uint数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual uint GetUInt(byte[] data, ref int pos)
        {
            uint t = BitConverter.ToUInt32(data, pos);
            pos += 4;
            return t;
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为ulong数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual ulong GetULong(byte[] data, ref int pos)
        {
            ulong t = BitConverter.ToUInt64(data, pos);
            pos += 8;
            return t;
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为float数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual float GetFloat(byte[] data, ref int pos)
        {
            float t = BitConverter.ToSingle(data, pos);
            pos += 4;
            return t;
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为double数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual double GetDouble(byte[] data, ref int pos)
        {
            double t = BitConverter.ToDouble(data, pos);
            pos += 8;
            return t;
        }

        /// <summary>
        /// 将byte数组中相应的位置转换为8个bit数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public virtual bool[] GetBits(byte[] data, ref int pos)
        {
            bool[] t = new bool[8];
            byte temp = data[pos];
            for (int i = 0; i < 8; i++)
            {
                t[i] = temp % 2 > 0;
                temp /= 2;
            }
            pos += 1;
            return t;
        }

        /// <summary>
        /// 获取一个byte中相对应的bit数组展开中第n个位置中的bit元素。
        /// </summary>
        /// <param name="number">byte数字</param>
        /// <param name="pos">bit数组中的对应位置</param>
        /// <param name="subPos">小数位</param>
        /// <returns>对应位置的bit元素</returns>
        public bool GetBit(byte number, ref int pos, ref int subPos)
        { 
            if (subPos < 0 && subPos >= 8) throw new IndexOutOfRangeException();
            int ans = number % 2;
            int i = 7;
            while (i >= subPos)
            {
                ans = number % 2;
                number /= 2;
                i--;
            }
            subPos += 1;
            if (subPos > 7)
            {
                pos++;
                subPos = 0;
            }
            return ans > 0;
        }

        public virtual bool GetBit(byte[] number, ref int pos, ref int subPos)
        {
            return GetBit(number[pos], ref pos, ref subPos);
        }

        /// <summary>
        /// 将待转换的对象数组转换为需要发送的byte数组
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        public virtual byte[] ObjectArrayToByteArray(object[] contents)
        {
            bool b = false;
            //先查找传入的结构中有没有数组，有的话将其打开
            var newContentsList = new List<object>();
            foreach (object content in contents)
            {
                string t = content.GetType().ToString();
                if (t.Substring(t.Length - 2, 2) == "[]")
                {
                    b = true;
                    //自动将目标数组中内含的子数组展开，是所有包含在子数组拼接为一个数组
                    IEnumerable<object> contentArray =
                        ArrayList.Adapter((Array) content).ToArray(typeof (object)).OfType<object>();
                    newContentsList.AddRange(contentArray);
                }
                else
                {
                    newContentsList.Add(content);
                }
            }
            //重新调用一边这个函数，这个传入的参数中一定没有数组。
            if (b) return ObjectArrayToByteArray(newContentsList.ToArray());
            //把参数一个一个翻译为相对应的字节，然后拼成一个队列
            var translateTarget = new List<byte>();
            //将bool类型拼装为byte类型时，按照8个一组，不满8个时补false为原则进行
            bool lastIsBool = false;
            byte boolToByteTemp = 0;
            int boolToByteCount = 0;
            foreach (object content in contents)
            {
                string t = content.GetType().ToString();
                if (t == "System.Boolean")
                {
                    if (boolToByteCount >= 8)
                    {
                        translateTarget.Add(boolToByteTemp);
                        boolToByteCount = 0;
                        boolToByteTemp = 0;
                    }
                    lastIsBool = true;
                    if (LittleEndian)
                    {
                        boolToByteTemp = (byte)(boolToByteTemp * 2 + ((bool)content ? 1 : 0));
                    }
                    else
                    {                       
                        boolToByteTemp += (byte)((bool)content ? Math.Pow(2, boolToByteCount) : 0);
                    }
                    boolToByteCount++;
                }
                else
                {
                    if (lastIsBool)
                    {
                        translateTarget.Add(boolToByteTemp);
                        boolToByteCount = 0;
                        boolToByteTemp = 0;
                        lastIsBool = false;
                    }
                    switch (t)
                    {
                        case "System.Int16":
                            {
                                translateTarget.AddRange(_Instance.GetBytes((short)content));
                                break;
                            }
                        case "System.Int32":
                            {
                                translateTarget.AddRange(_Instance.GetBytes((int)content));
                                break;
                            }
                        case "System.Int64":
                            {
                                translateTarget.AddRange(_Instance.GetBytes((long)content));
                                break;
                            }
                        case "System.UInt16":
                            {
                                translateTarget.AddRange(_Instance.GetBytes((ushort)content));
                                break;
                            }
                        case "System.UInt32":
                            {
                                translateTarget.AddRange(_Instance.GetBytes((uint)content));
                                break;
                            }
                        case "System.UInt64":
                            {
                                translateTarget.AddRange(_Instance.GetBytes((ulong)content));
                                break;
                            }
                        case "System.Single":
                            {
                                translateTarget.AddRange(_Instance.GetBytes((float)content));
                                break;
                            }
                        case "System.Double":
                            {
                                translateTarget.AddRange(_Instance.GetBytes((double)content));
                                break;
                            }
                        case "System.Byte":
                            {
                                translateTarget.AddRange(_Instance.GetBytes((byte)content));
                                break;
                            }
                        default:
                            {
                                throw new NotImplementedException("没有实现除整数以外的其它转换方式");
                            }
                    }
                }        
            }
            //最后是bool拼装时，表示数字还没有添加，把数字添加进返回数组中。
            if (lastIsBool)
            {
                translateTarget.Add(boolToByteTemp);
            }
            //最后把队列转换为数组
            return translateTarget.ToArray();
        }

        /// <summary>
        /// 将byte数组转换为用户指定类型的数组，通过object数组的方式返回，用户需要再把object转换为自己需要的类型，或调用ObjectArrayToDestinationArray返回单一类型的目标数组。
        /// </summary>
        /// <param name="contents">byte数组</param>
        /// <param name="translateTypeAndCount">单一的类型和需要转换的个数的键值对</param>
        /// <returns>object数组</returns>
        public virtual object[] ByteArrayToObjectArray(byte[] contents, KeyValuePair<Type, int> translateTypeAndCount)
        {
            return ByteArrayToObjectArray(contents, new List<KeyValuePair<Type, int>>() {translateTypeAndCount});
        }

        public virtual T[] ByteArrayToDestinationArray<T>(byte[] contents, int getCount)
        {
            var objectArray = _Instance.ByteArrayToObjectArray(contents,
                new KeyValuePair<Type, int>(typeof (T), getCount));
            return _Instance.ObjectArrayToDestinationArray<T>(objectArray);
        }

        /// <summary>
        /// 将byte数组转换为用户指定类型的数组，通过object数组的方式返回，用户需要再把object转换为自己需要的类型，或调用ObjectArrayToDestinationArray返回单一类型的目标数组。
        /// </summary>
        /// <param name="contents">byte数组</param>
        /// <param name="translateTypeAndCount">一连串类型和需要转换的个数的键值对，该方法会依次转换每一个需要转的目标数据类型。比如：typeof(int),5; typeof(short),3 会转换出8个元素（当然前提是byte数组足够长的时候），5个int和3个short，然后全部变为object类型返回。</param>
        /// <returns>object数组</returns>
        public virtual object[] ByteArrayToObjectArray(byte[] contents,
            IEnumerable<KeyValuePair<Type, int>> translateTypeAndCount)
        {
            List<object> translation = new List<object>();
            int count = 0;
            foreach (var translateUnit in translateTypeAndCount)
            {
                for (int i = 0; i < translateUnit.Value; i++)
                {
                    if (count >= contents.Length) break;
                    try
                    {
                        switch (translateUnit.Key.ToString())
                        {
                            case "System.Int16":
                            {
                                short value = _Instance.GetShort(contents, ref count);
                                translation.Add(value);
                                break;
                            }
                            case "System.Int32":
                            {
                                int value = _Instance.GetInt(contents, ref count);
                                translation.Add(value);
                                break;
                            }
                            case "System.Int64":
                            {
                                long value = _Instance.GetLong(contents, ref count);
                                translation.Add(value);
                                break;
                            }
                            case "System.UInt16":
                            {
                                ushort value = _Instance.GetUShort(contents, ref count);
                                translation.Add(value);
                                break;
                            }
                            case "System.UInt32":
                            {
                                uint value = _Instance.GetUInt(contents, ref count);
                                translation.Add(value);
                                break;
                            }
                            case "System.UInt64":
                            {
                                ulong value = _Instance.GetULong(contents, ref count);
                                translation.Add(value);
                                break;
                            }
                            case "System.Single":
                            {
                                float value = _Instance.GetFloat(contents, ref count);
                                translation.Add(value);
                                break;
                            }
                            case "System.Double":
                            {
                                double value = _Instance.GetDouble(contents, ref count);
                                translation.Add(value);
                                break;
                            }
                            case "System.Byte":
                            {
                                byte value = _Instance.GetByte(contents, ref count);
                                translation.Add(value);
                                break;
                            }
                            case "System.Boolean":
                            {
                                
                                bool[] value = _Instance.GetBits(contents, ref count);
                                int k = translateUnit.Value - i < 8 ? translateUnit.Value - i : 8;
                                for (int j = 0; j < k; j++)
                                {
                                    translation.Add(value[j]);
                                }
                                i += 7;
                                break;
                            }
                            default:
                            {
                                throw new NotImplementedException("没有实现除整数以外的其它转换方式");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        count = contents.Length;
                    }
                }
            }
            return translation.ToArray();
        }

        /// <summary>
        /// 将object数组转换为目标类型的单一数组
        /// </summary>
        /// <typeparam name="T">需要转换的目标类型</typeparam>
        /// <param name="contents">object数组</param>
        /// <returns>目标数组</returns>
        public T[] ObjectArrayToDestinationArray<T>(object[] contents)
        {
            T[] array = new T[contents.Length];
            Array.Copy(contents,array,contents.Length);
            return array;
        }

        public bool SetValue(byte[] contents, int setPos, int subPos, object setValue)
        {
            var type = setValue.GetType();

            switch (type.FullName)
            {
                case "System.Int16":
                {
                    bool success = _Instance.SetValue(contents, setPos, (short)setValue);
                    return success;
                }
                case "System.Int32":
                {
                    bool success = _Instance.SetValue(contents, setPos, (int) setValue);
                    return success;
                }
                case "System.Int64":
                {
                    bool success = _Instance.SetValue(contents, setPos, (long) setValue);
                    return success;
                }
                case "System.UInt16":
                {
                    bool success = _Instance.SetValue(contents, setPos, (ushort) setValue);
                    return success;
                }
                case "System.UInt32":
                {
                    bool success = _Instance.SetValue(contents, setPos, (uint) setValue);
                    return success;
                }
                case "System.UInt64":
                {
                    bool success = _Instance.SetValue(contents, setPos, (ulong) setValue);
                    return success;
                }
                case "System.Single":
                {
                    bool success = _Instance.SetValue(contents, setPos, (float) setValue);
                    return success;
                }
                case "System.Double":
                {
                    bool success = _Instance.SetValue(contents, setPos, (double) setValue);
                    return success;
                }
                case "System.Byte":
                {
                    bool success = _Instance.SetValue(contents, setPos, (byte) setValue);
                    return success;
                }
                case "System.Boolean":
                {
                    bool success = _Instance.SetBit(contents, setPos, subPos, (bool) setValue);
                    return success;
                }
                default:
                {
                    throw new NotImplementedException("没有实现除整数以外的其它转换方式");
                }
            }
        }

        /// <summary>
        /// 将short值设置到byte数组中
        /// </summary>
        /// <param name="contents">待设置的byte数组</param>
        /// <param name="pos">设置的位置</param>
        /// <param name="setValue">要设置的值</param>
        /// <returns></returns>
        public virtual bool SetValue(byte[] contents, int pos, object setValue)
        {
            try
            {
                byte[] datas = _Instance.GetBytes(setValue, setValue.GetType());
                Array.Copy(datas, 0, contents, pos, datas.Length);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 设置对应数字中相应位置的bit的值
        /// </summary>
        /// <param name="number">byte数子</param>
        /// <param name="subPos">设置位置</param>
        /// <param name="setBit">设置bit大小，true为1，false为0</param>
        /// <returns></returns>
        public byte SetBit(byte number, int subPos, bool setBit)
        {
            int creation = 0;
            if (setBit)
            {
                for (int i = 7; i >= 0; i--)
                {
                    creation *= 2;
                    if (i == subPos) creation++;
                }
                return (byte)(number | creation);
            }
            else
            {
                for (int i = 7; i >= 0; i--)
                {
                    creation *= 2;
                    if (i != subPos) creation++;
                }
                return (byte)(number & creation);
            }
        }

        /// <summary>
        /// 设置一组数据中的一个bit
        /// </summary>
        /// <param name="contents">待设置的字节数组</param>
        /// <param name="pos">位置</param>
        /// <param name="subPos">bit位置</param>
        /// <param name="setValue">bit数</param>
        /// <returns></returns>
        public virtual bool SetBit(byte[] contents, int pos, int subPos, bool setValue)
        {
            try
            {
                contents[pos] = SetBit(contents[pos], subPos, setValue);
                return true;
            }
            catch (Exception)
            {
                return false;
            }          
        }
    }

    public class BigEndianValueHelper : ValueHelper
    {
        private static BigEndianValueHelper _bigEndianInstance;

        protected override ValueHelper _Instance => _bigEndianInstance;

        protected BigEndianValueHelper()
        {
            
        }

        protected new bool LittleEndian => false;

        public new static BigEndianValueHelper Instance => _bigEndianInstance ?? (_bigEndianInstance = new BigEndianValueHelper());

        public override Byte[] GetBytes(short value)
        {
            return Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(int value)
        {
            return Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(long value)
        {
            return Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(ushort value)
        {
            return Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(uint value)
        {
            return Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(ulong value)
        {
            return Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(float value)
        {
            return Reverse(BitConverter.GetBytes(value));
        }

        public override Byte[] GetBytes(double value)
        {
            return Reverse(BitConverter.GetBytes(value));
        }

        public override short GetShort(byte[] data, ref int pos)
        {
            Array.Reverse(data, pos, 2);
            short t = BitConverter.ToInt16(data, pos);
            pos += 2;
            return t;
        }

        public override int GetInt(byte[] data, ref int pos)
        {
            Array.Reverse(data, pos, 4);
            int t = BitConverter.ToInt32(data, pos);
            pos += 4;
            return t;
        }

        public override long GetLong(byte[] data, ref int pos)
        {
            Array.Reverse(data, pos, 8);
            long t = BitConverter.ToInt64(data, pos);
            pos += 8;
            return t;
        }

        public override ushort GetUShort(byte[] data, ref int pos)
        {
            Array.Reverse(data, pos, 2);
            ushort t = BitConverter.ToUInt16(data, pos);
            pos += 2;
            return t;
        }

        public override uint GetUInt(byte[] data, ref int pos)
        {
            Array.Reverse(data, pos, 4);
            uint t = BitConverter.ToUInt32(data, pos);
            pos += 4;
            return t;
        }

        public override ulong GetULong(byte[] data, ref int pos)
        {
            Array.Reverse(data, pos, 8);
            ulong t = BitConverter.ToUInt64(data, pos);
            pos += 8;
            return t;
        }

        public override float GetFloat(byte[] data, ref int pos)
        {
            Array.Reverse(data, pos, 4);
            float t = BitConverter.ToSingle(data, pos);
            pos += 4;
            return t;
        }

        public override double GetDouble(byte[] data, ref int pos)
        {
            Array.Reverse(data, pos, 8);
            double t = BitConverter.ToDouble(data, pos);
            pos += 8;
            return t;
        }

        public override bool GetBit(byte[] number, ref int pos, ref int subPos)
        {
            if (subPos < 0 && subPos > 7) throw new IndexOutOfRangeException();
            var tspos = 7 - subPos;
            var tpos = pos;
            var bit = GetBit(number[pos], ref tpos, ref tspos);
            subPos += 1;
            if (subPos > 7)
            {
                pos++;
                subPos = 0;
            }
            return bit;
        }

        public override bool[] GetBits(byte[] data, ref int pos)
        {
            bool[] t = new bool[8];
            byte temp = data[pos];
            for (int i = 0; i < 8; i++)
            {
                t[7 - i] = temp % 2 > 0;
                temp /= 2;
            }
            pos += 1;
            return t;
        }

        public override bool SetBit(byte[] number, int pos, int subPos, bool setBit)
        {
            return base.SetBit(number, pos, 7 - subPos, setBit);
        }

        private Byte[] Reverse(Byte[] data)
        {
            Array.Reverse(data);
            return data;
        }
    }
}