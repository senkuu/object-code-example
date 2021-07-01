using System;
namespace NIRScore.data
{
    public struct DataSet
    {

        public double TSI;
        public double HHb;
        public double tHb;
        public double O2Hb;

        public DataSet Sub(DataSet b)
        {
            TSI -= b.TSI;
            HHb -= b.HHb;
            tHb -= b.tHb;
            O2Hb -= b.O2Hb;
            return this;
        }

        public DataSet Add(DataSet b)
        {
            TSI += b.TSI;
            HHb += b.HHb;
            tHb += b.tHb;
            O2Hb += b.O2Hb;
            return this;
        }

        public DataSet Div(DataSet b)
        {
            TSI /= b.TSI;
            HHb /= b.HHb;
            tHb /= b.tHb;
            O2Hb /= b.O2Hb;
            return this;
        }

        public DataSet Div(double value)
        {
            TSI /= value;
            HHb /= value;
            tHb /= value;
            O2Hb /= value;
            return this;
        }

        public DataSet Mul(DataSet b)
        {
            TSI *= b.TSI;
            HHb *= b.HHb;
            tHb *= b.tHb;
            O2Hb *= b.O2Hb;
            return this;
        }

        public DataSet Mul(double value)
        {
            TSI *= value;
            HHb *= value;
            tHb *= value;
            O2Hb *= value;
            return this;
        }

        public static DataSet Sub(DataSet a, DataSet b)
        {
            return new DataSet
            {
                TSI = a.TSI - b.TSI,
                HHb = a.HHb - b.HHb,
                tHb = a.tHb - b.tHb,
                O2Hb = a.O2Hb - b.O2Hb
            };
        }

        public static DataSet Add(DataSet a, DataSet b)
        {
            return new DataSet
            {
                TSI = a.TSI + b.TSI,
                HHb = a.HHb + b.HHb,
                tHb = a.tHb + b.tHb,
                O2Hb = a.O2Hb + b.O2Hb
            };
        }


        public static DataSet Div(DataSet a, double ratio)
        {
            return new DataSet
            {
                TSI = a.TSI / ratio,
                HHb = a.HHb / ratio,
                tHb = a.tHb / ratio,
                O2Hb = a.O2Hb / ratio
            };
        }

        public static DataSet Div(DataSet a, DataSet ratio)
        {
            return new DataSet
            {
                TSI = a.TSI / ratio.TSI,
                HHb = a.HHb / ratio.HHb,
                tHb = a.tHb / ratio.tHb,
                O2Hb = a.O2Hb / ratio.O2Hb
            };
        }

        public static DataSet SubDiv(DataSet a, DataSet b, double ratio)
        {
            return Div(Sub(a, b), ratio);
        }


        public static DataSet Mean(params DataSet[] list)
        {
            DataSet ret = new DataSet
            {
                TSI = 0.0,
                HHb = 0.0,
                tHb = 0.0,
                O2Hb = 0.0
            };

            for (int i = 0; i < list.Length; i++)
            {
                ret = Add(ret, list[i]);
            }

            return Div(ret, (double)list.Length);
        }

    }
}
