using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeProject;

namespace TimeStructTests
{
    [TestClass]
    public class Time_Constructor_Tests
    {
        [DataTestMethod]
        [DataRow((byte)12, (byte)20, (byte)30)]
        [DataRow((byte)9, (byte)59, (byte)59)]
        [DataRow((byte)23, (byte)59, (byte)0)]
        public void Constructor_3Params_OK(byte h, byte m, byte s)
        {
            Time time = new Time(h, m, s);
            Assert.AreEqual(h, time.Hours);
            Assert.AreEqual(m, time.Minutes);
            Assert.AreEqual(s, time.Seconds);
        }

        [DataTestMethod]
        [DataRow((byte)12, (byte)20)]
        public void Constructor_2Params_OK(byte h, byte m)
        {
            Time time = new Time(h, m);
            Assert.AreEqual(h, time.Hours);
            Assert.AreEqual(m, time.Minutes);
            Assert.AreEqual(0, time.Seconds);
        }

        [DataTestMethod]
        [DataRow((byte)12)]
        public void Constructor_1Param_OK(byte h)
        {
            Time time = new Time(h);
            Assert.AreEqual(h, time.Hours);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(0, time.Seconds);
        }
        [TestMethod]
        public void Constructor_StringParam_OK()
        {
            string str = "10:23:17";
            Time time = new Time(str);
            Assert.AreEqual(10, time.Hours);
            Assert.AreEqual(23, time.Minutes);
            Assert.AreEqual(17, time.Seconds);
        }

        [TestMethod]
        public void Constructor_FromSecondsParam_OK()
        {
            long seconds = 14490;
            Time time = new Time(seconds);
            Assert.AreEqual(4, time.Hours);
            Assert.AreEqual(1, time.Minutes);
            Assert.AreEqual(30, time.Seconds);
        }
    }
    [TestClass]
    public class Time_Modulo_Tests
    {
        [TestMethod]
        public void ModuloHours_OK()
        {
            Time t1 = new Time(25);
            Time expected = new Time(25 * 3600);
            Assert.AreEqual(expected, t1);
            Console.Write(t1.Hours + " | " + expected.Hours);
        }

        [TestMethod]
        public void ModuloMinutes_OK()
        {
            Time t1 = new Time(0, 65);
            Time expected = new Time("00:05:00");
            Assert.AreEqual(expected, t1);
            Console.Write(t1.Hours + " | " + expected.Hours);
        }
        [TestMethod]
        public void ModuloSeconds_OK()
        {
            Time t1 = new Time(0, 0, 75);
            Time expected = new Time("00:00:15");
            Assert.AreEqual(expected, t1);
            Console.Write(t1.Hours + " | " + expected.Hours);
        }
    }
    [TestClass]
    public class Time_OtherTests
    {
        [TestMethod]
        public void ToStringOverride_OK()
        {
            string expected = "10:20:30";
            Time time = new Time("10:20:30");
            Assert.AreEqual(expected, time.ToString());
        }
        [DataTestMethod]
        [DataRow("12:31:00", "12:33:12")]
        [DataRow("12:38:38", "12:38:37")]
        public void NotEquals_OK(string s1, string s2)
        {
            Time t1 = new Time(s1);
            Time t2 = new Time(s2);

            Assert.AreNotEqual(t1, t2);
            Assert.IsTrue(t1 != t2);
        }

        [DataTestMethod]
        [DataRow("12:31:00", "12:31:00")]
        [DataRow("12:38:38", "12:38:38")]
        public void Equals_OK(string s1, string s2)
        {
            Time t1 = new Time(s1);
            Time t2 = new Time(s2);

            Assert.AreEqual(t1, t2);
            Assert.IsTrue(t1 == t2);
        }

        [DataTestMethod]
        [DataRow("12:31:00", "12:31:10")]
        [DataRow("12:38:38", "12:38:39")]
        public void Comparsion_Lower_OK(string s1, string s2)
        {
            Time t1 = new Time(s1);
            Time t2 = new Time(s2);

            Assert.IsTrue(t1 < t2);
        }

        [DataTestMethod]
        [DataRow("12:31:11", "12:31:10")]
        [DataRow("12:38:40", "12:38:39")]
        public void Comparsion_Bigger_OK(string s1, string s2)
        {
            Time t1 = new Time(s1);
            Time t2 = new Time(s2);

            Assert.IsTrue(t1 > t2);
        }

        [DataTestMethod]
        [DataRow("12:31:11", "12:31:10")]
        [DataRow("12:38:39", "12:38:39")]
        public void Comparsion_BiggerOrEqual_OK(string s1, string s2)
        {
            Time t1 = new Time(s1);
            Time t2 = new Time(s2);

            Assert.IsTrue(t1 >= t2);
        }

        [DataTestMethod]
        [DataRow("12:20:11", "12:31:13")]
        [DataRow("12:38:39", "12:38:39")]
        public void Comparsion_LowerOrEqual_OK(string s1, string s2)
        {
            Time t1 = new Time(s1);
            Time t2 = new Time(s2);

            Assert.IsTrue(t1 <= t2);
        }

        [TestMethod]
        public void OperatorPlus_OK()
        {
            Time t1 = new Time("00:00:11");
            Time t2 = new Time("00:00:10");
            t1 = t1 + t2;
            Time expected = new Time("00:00:21");
            Assert.AreEqual(expected, t1);
        }

        [TestMethod]
        public void OperatorMinus_OK()
        {
            Time t1 = new Time("02:10:11");
            Time t2 = new Time("01:10:10");
            t1 = t1 - t2;
            Time expected = new Time("01:00:01");
            Assert.AreEqual(expected, t1);
        }

        [TestMethod]
        public void OperatorMultiply_OK()
        {
            Time t1 = new Time("00:10:10");
            t1 = t1 * 3;
            Time expected = new Time("00:30:30");
            Assert.AreEqual(expected, t1);
        }
    }

    [TestClass]
    public class TimePeriodTests
    {
        #region CONSTRUCTOR_TESTS
        [DataTestMethod]
        [DataRow((short)30,(short)54,(short)58)]
        [DataRow((short)2,(short)1,(short)30)]
        public void TP_Constructor_3Params_OK(short h, short m, short s)
        {
            TimePeriod tp = new TimePeriod(h, m, s);
            Assert.AreEqual(h, tp.Hours);
            Assert.AreEqual(m, tp.Minutes);
            Assert.AreEqual(s, tp.Seconds);
        }
        [DataTestMethod]
        [DataRow((short)30, (short)54)]
        [DataRow((short)2, (short)1)]
        public void TP_Constructor_2Params_OK(short h, short m)
        {
            TimePeriod tp = new TimePeriod(h, m);
            Assert.AreEqual(h, tp.Hours);
            Assert.AreEqual(m, tp.Minutes);
            Assert.AreEqual(0, tp.Seconds);

        }

        [DataTestMethod]
        [DataRow((short)30)]
        [DataRow((short)2)]
        public void TP_Constructor_1Param_OK(short h)
        {
            TimePeriod tp = new TimePeriod(h);
            Assert.AreEqual(h, tp.Hours);
            Assert.AreEqual(0, tp.Minutes);
            Assert.AreEqual(0, tp.Seconds);
        }

        [TestMethod]
        public void TP_Constructor_String_OK()
        {
            TimePeriod tp = new TimePeriod("0032:23:45");
            TimePeriod expected = new TimePeriod(32, 23, 45);
            Assert.AreEqual(expected, tp);
        }
        [TestMethod]
        public void TP_Constructor_FromSeconds_OK()
        {
            long seconds = 14320;
            TimePeriod tp = new TimePeriod(seconds);
            TimePeriod expected = new TimePeriod("0003:58:40");

            Assert.AreEqual(expected, tp);
        }
        [TestMethod]
        public void TP_Constructor_FromTimes_OK()
        {
            Time t1 = new Time("20:20:30");
            Time t2 = new Time("13:15:30");
            TimePeriod expected = new TimePeriod((long)25500);
            TimePeriod tp = new TimePeriod(t1, t2);

            Assert.AreEqual(expected, tp);
        }
        #endregion

        #region OVERRIDE_TESTS
        [DataTestMethod]
        [DataRow("0003:24:43","03:24:43")]
        [DataRow("0333:24:43","333:24:43")]
        [DataRow("3333:24:43","3333:24:43")]
        public void TP_ToString_OK(string constructStr, string expectedOut)
        {
            TimePeriod tp = new TimePeriod(constructStr);
            Assert.AreEqual(tp.ToString(), expectedOut);
        }

        [TestMethod]
        public void TP_Comparsion_Lower_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)30000);
            TimePeriod tp2 = new TimePeriod((long)35000);

            Assert.IsTrue(tp1 < tp2);
        }
        [TestMethod]
        public void TP_Comparsion_Bigger_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)36000);
            TimePeriod tp2 = new TimePeriod((long)35000);

            Assert.IsTrue(tp1 > tp2);
        }
        [TestMethod]
        public void TP_Comparsion_LowerOrEqual_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)35000);
            TimePeriod tp2 = new TimePeriod((long)35000);

            Assert.IsTrue(tp1 <= tp2);
        }
        [TestMethod]
        public void TP_Comparsion_BiggerOrEqual_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)35000);
            TimePeriod tp2 = new TimePeriod((long)35000);

            Assert.IsTrue(tp1 >= tp2);
        }

        [TestMethod]
        public void TP_NotEquals_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)30000);
            TimePeriod tp2 = new TimePeriod((long)35000);

            Assert.IsTrue(tp1 != tp2);
        }
        [TestMethod]
        public void TP_Equals_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)30000);
            TimePeriod tp2 = new TimePeriod((long)30000);

            Assert.IsTrue(tp1 == tp2);
        }
        #endregion

        #region ARITHMETICS_TESTS

        [TestMethod]
        public void TP_PlusMethod_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)4000);
            TimePeriod tp2 = new TimePeriod((long)7000);
            TimePeriod expected = new TimePeriod("0003:03:20");
            tp1 = tp1.Plus(tp2);

            Assert.AreEqual(expected, tp1);
        }
        [TestMethod]
        public void TP_PlusStaticMethod_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)4000);
            TimePeriod tp2 = new TimePeriod((long)7000);
            TimePeriod expected = new TimePeriod("0003:03:20");
            TimePeriod result = TimePeriod.Plus(tp1, tp2);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TP_PlusOperator_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)4000);
            TimePeriod tp2 = new TimePeriod((long)7000);
            TimePeriod expected = new TimePeriod("0003:03:20");
            TimePeriod result = tp1 + tp2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TP_MinusOperator_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)7000);
            TimePeriod tp2 = new TimePeriod((long)4000);
            TimePeriod expected = new TimePeriod(0,50);
            TimePeriod result = tp1 - tp2;

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Duration cannot be negative")]
        public void TP_MinusOperatorException_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)4000);
            TimePeriod tp2 = new TimePeriod((long)6000);
            TimePeriod expected = new TimePeriod(0, 50);
            TimePeriod result = tp1 - tp2;
        }

        [TestMethod]
        public void TP_MultiplyOperator_OK()
        {
            TimePeriod tp1 = new TimePeriod((long)4000);
            int multiplier = 4;
            TimePeriod expected = new TimePeriod("0004:26:40");
            TimePeriod result = tp1 * multiplier;

            Assert.AreEqual(expected, result);
        }
        #endregion
    }

    [TestClass]
    public class MixedArithmetics_Tests
    {
        #region Time_MixedMath
        [TestMethod]
        public void Time_Plus_TimePeriod_OK()
        {
            Time t1 = new Time((long)4500);
            TimePeriod tp = new TimePeriod((long)15000);
            Time expected = new Time("05:25:00");

            t1 = t1.Plus(tp);
            Assert.AreEqual(expected, t1);
        }
        [TestMethod]
        public void Time_StaticPlus_TimePeriod_OK()
        {
            Time t1 = new Time((long)4500);
            TimePeriod tp = new TimePeriod((long)15000);
            Time expected = new Time("05:25:00");

            Time result = Time.Plus(t1, tp);
            Assert.AreEqual(expected, result);
        }
        #endregion
    }
}
