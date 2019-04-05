using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeProject
{
    public struct Time : IEquatable<object>, IComparable<Time>
    {
        #region Constructors
        /// <summary>
        /// Constructor with three params - hours, minutes and seconds.
        /// </summary>
        /// <param name="hours">Accepted values: 0-23, if value is > 23, then final value is calculated using % 24</param>
        /// <param name="minutes">Accepted values: 0-59</param>
        /// <param name="seconds">Accepted values: 0-59</param>
        public Time(byte hours, byte minutes, byte seconds)
        {
            if (hours < 24)
                Hours = hours;
            else
            {
                hours = (byte)(hours % 24);
                Hours = hours;
              //  throw new ArgumentException("Invalid hours value! Accepted values 0-23");
            }
            if (minutes < 60)
                Minutes = minutes;
            else
            {
                //throw new ArgumentException("Invalid minutes value! Accepted values 0-59");
                minutes = (byte)(minutes % 60);
                Minutes = minutes;
            }
            if (seconds < 60)
                Seconds = seconds;
            else
            {
                //throw new ArgumentException("Invalid seconds value! Accepted values 0-59");
                seconds = (byte)(seconds % 60);
                Seconds = seconds;
            }

        }

        /// <summary>
        /// Construct Time from two params - hours and minutes.
        /// </summary>
        /// <param name="hours">Accepted values: 0-23, if value is > 23, then final value is calculated using % 24</param>
        /// <param name="minutes">Accepted values: 0-59</param>
        public Time(byte hours, byte minutes)
            :this(hours,minutes,0)
        {
           
        }

        /// <summary>
        /// Construct Time from only hours value.
        /// </summary>
        /// <param name="hours">Accepted values: 0-23, if value is > 23, then final value is calculated using % 24</param>
        public Time(byte hours)
            : this(hours, 0, 0)
        {

        }
        /// <summary>
        /// Constructor with string param - string should be in hh:mm:ss format.
        /// </summary>
        /// <param name="hhMMss">Valid string format is hh:mm:ss</param>
        public Time(string hhMMss)
        {
            string pattern = "00:00:00";
            if(hhMMss is null)
            {
                throw new ArgumentNullException("String time value cannot be null!");
            }
            else
            {
                if(hhMMss.Length != pattern.Length)
                {
                    throw new ArgumentException("Invalid string length! Format should be HH:MM:SS.");
                }
                else
                {
                    if(hhMMss.ElementAt(2) != pattern.ElementAt(2) || hhMMss.ElementAt(5) != pattern.ElementAt(5))
                    {
                        throw new ArgumentException("Invalid string format! Should be HH:MM:SS");
                    }
                    else
                    {
                        byte hh, mm, ss = 0;
                        string tmp = hhMMss.Substring(0, 2);                        
                        //hh = System.Convert.ToByte(tmp);
                        bool parse = Byte.TryParse(tmp, out hh);
                        if(!parse)
                        {
                            throw new ArgumentException("Invalid string format! Time cannot contain letters.");
                        }
                        
                        tmp = hhMMss.Substring(3, 2);
                        parse = Byte.TryParse(tmp, out mm);
                        if (!parse)
                        {
                            throw new ArgumentException("Invalid string format! Time cannot contain letters.");
                        }
                        //mm = System.Convert.ToByte(tmp);

                        tmp = hhMMss.Substring(6, 2);
                        parse = Byte.TryParse(tmp, out ss);
                        if (!parse)
                        {
                            throw new ArgumentException("Invalid string format! Time cannot contain letters.");
                        }
                        //ss = System.Convert.ToByte(tmp);


                        this = new Time(hh, mm, ss);
                    }
                    
                }
                
            }
            
           
        }

        /// <summary>
        /// Construct Time only from summary seconds value. (60 - 00:01:00). Use (long) cast for numbers which are also valid for byte type.
        /// </summary>
        /// <param name="fromSeconds">Use (long) cast for numbers which are also valid for byte type.</param>
        public Time(long fromSeconds)
        {
            byte newHH, newMM, newSS = 0;
            newHH = (byte)(fromSeconds / 3600);
            fromSeconds -= (newHH * 3600);

            newMM = (byte)(fromSeconds / 60);
            fromSeconds -= (newMM * 60);

            newSS = (byte)fromSeconds;
            this = new Time(newHH, newMM, newSS);
        }


        #endregion

        #region C#6_Readonly_Autoproperties
        /// <summary>
        /// Returns Hours from Time.
        /// </summary>
        public byte Hours { get; }
        /// <summary>
        /// Returns Minutes from Time.
        /// </summary>
        public byte Minutes { get; }
        /// <summary>
        /// Returns Seconds from Time.
        /// </summary>
        public byte Seconds { get; }
        private long TimeInSeconds { get { return (Hours * 3600) + (Minutes * 60) +Seconds; } }
        #endregion


        #region Overrides
        /// <summary>
        /// Provides default text output for Time objects in format: HH:MM:SS
        /// </summary>
        /// <returns>String in format HH:MM:SS</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(Hours.ToString("00") + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00"));
            return stringBuilder.ToString();
        }
        /// <summary>
        /// Check if two objects are equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Time)) return false;
                var compareElement = (Time)obj;
                if (compareElement.Hours == this.Hours
                     && compareElement.Minutes == this.Minutes &&
                     compareElement.Seconds == this.Seconds) return true;
                else return false;


            }
            else return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -99606436;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Hours.GetHashCode();
            hashCode = hashCode * -1521134295 + Minutes.GetHashCode();
            hashCode = hashCode * -1521134295 + Seconds.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// Checks if one of Time object is bigger/lower/equals from another one
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Time other)
        {
            if (this.Hours > other.Hours) return 1;
            else if (this.Hours < other.Hours) return -1;
            else
            {
                if (this.Minutes > other.Minutes) return 1;
                else if (this.Minutes < other.Minutes) return -1;
                else
                {
                    if (this.Seconds > other.Seconds) return 1;
                    else if (this.Seconds < other.Seconds) return -1;
                    else return 0;
                }
            }            
        }
        /// <summary>
        /// Checks if left-hand argument is bigger than right-hand
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>Returns true if left argument is bigger than right, otherwise returns false</returns>
        public static bool operator >(Time time1, Time time2)
        {
            var result = time1.CompareTo(time2);
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// Checks if left-hand argument is lower than right-hand
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>True if left-hand argument is lower than right=hand</returns>
        public static bool operator <(Time time1, Time time2)
        {
            var result = time1.CompareTo(time2);
            if (result == -1) return true;
            else return false;
        }
        /// <summary>
        /// Checks if left-hand argument is lower/equal from/to right-hand argument
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator <=(Time time1, Time time2)
        {
            var result = time1.CompareTo(time2);
            if (result == -1 || result == 0) return true;
            else return false;
        }
        /// <summary>
        /// Checks if left-hand argument is bigger/equal from/to right-hand argument
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator >=(Time time1, Time time2)
        {
            var result = time1.CompareTo(time2);
            if (result == 1 || result == 0) return true;
            else return false;
        }
        /// <summary>
        /// Checks equality of two time objects
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator ==(Time time1, Time time2)
        {
            return time1.Equals(time2);
        }
        /// <summary>
        /// Checks if two Time objects are not equal
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator !=(Time time1, Time time2)
        {
            return !(time1 == time2);
        }
        /// <summary>
        /// Multiply Time by constant value
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static Time operator *(Time time1, int multiplier)
        {
            long time1_inSeconds = (time1.Hours * 3600) + (time1.Minutes * 60) + time1.Seconds;
            long result = time1_inSeconds * multiplier;
            if (result < 0) throw new Exception("Time cannot be negative.");
            else
            {
                byte newHH, newMM, newSS = 0;
                newHH = (byte)(result / 3600);
                result -= (newHH * 3600);

                newMM = (byte)(result / 60);
                result -= (newMM * 60);

                newSS = (byte)result;

                return new Time(newHH, newMM, newSS);
            }
        }public static Time operator *(int multiplier, Time time1)
        {
            long time1_inSeconds = (time1.Hours * 3600) + (time1.Minutes * 60) + time1.Seconds;
            long result = time1_inSeconds * multiplier;
            if (result < 0) throw new Exception("Time cannot be negative.");
            else
            {
                byte newHH, newMM, newSS = 0;
                newHH = (byte)(result / 3600);
                result -= (newHH * 3600);

                newMM = (byte)(result / 60);
                result -= (newMM * 60);

                newSS = (byte)result;

                return new Time(newHH, newMM, newSS);
            }
        }
        /// <summary>
        /// Substract two Time objects.
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>New Time object, containing substracted time values</returns>
        public static Time operator -(Time time1, Time time2)
        {
            byte newHH, newMM, newSS = 0;
            long time1_inSeconds = (time1.Hours * 3600) + (time1.Minutes * 60) + time1.Seconds;
            long time2_inSeconds = (time2.Hours * 3600) + (time2.Minutes * 60) + time2.Seconds;

            long result = time1_inSeconds - time2_inSeconds;
            if (result < 0) throw new ArithmeticException("Time duration cannot be negative!");
            newHH = (byte)(result / 3600);
            result -= (newHH * 3600);

            newMM = (byte)(result / 60);
            result -= (newMM * 60);

            newSS = (byte)result;

            return new Time(newHH,newMM,newSS);
        }
        /// <summary>
        /// Sum of two Time objects.
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>New Time object, containing calculated sum value of time.</returns>
        public static Time operator +(Time time1, Time time2)
        {
            byte newHH, newMM, newSS = 0;
            long time1_inSeconds = (time1.Hours * 3600) + (time1.Minutes * 60) + time1.Seconds;
            long time2_inSeconds = (time2.Hours * 3600) + (time2.Minutes * 60) + time2.Seconds;
            long result = time1_inSeconds + time2_inSeconds;
            newHH = (byte)(result / 3600);
            result -= (newHH * 3600);

            newMM = (byte)(result / 60);
            result -= (newMM * 60);

            newSS = (byte)result;

            return new Time(newHH, newMM, newSS);
        }

        #endregion

        #region CUSTOM_ARITHMETICS
        /// <summary>
        /// Add TimePeriod value to Time object.
        /// If time properties are out of range after adding operation, then modulo is performed on property.
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public Time Plus(TimePeriod tp)
        {
            long result = TimeInSeconds + tp.Duration;
            return new Time(result);
        }
        /// <summary>
        /// Static version of Plus method.
        /// Adds two Time objects and returns new one.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static Time Plus(Time time, TimePeriod tp)
        {
            long result = time.TimeInSeconds + tp.Duration;
            return new Time(result);
        }
        #endregion
    }

    public struct TimePeriod :IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        
        #region PUBLIC_PROPERTIES
        /// <summary>
        /// Total amount of time in seconds.
        /// </summary>
        public long Duration { get; }

        /// <summary>
        /// Hours amount calculated from Duration.
        /// </summary>
        public short Hours { get { return (short)(Duration / 3600); } }
        /// <summary>
        /// Minutes amount calculated from Duration.
        /// </summary>
        public short Minutes { get { return (short)((Duration-(Hours * 3600))/60); } }
        /// <summary>
        /// Seconds amount calculated from Duration.
        /// </summary>
        public short Seconds { get { return (short)((Duration - (Hours * 3600)-(Minutes*60))); } }
        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Construct TimePeriod object from seconds value.
        /// </summary>
        /// <param name="durationInSeconds"></param>
        public TimePeriod(long durationInSeconds)
        {
            if (durationInSeconds < 0) throw new ArgumentException("Duration cannoc be negative");
            else Duration = durationInSeconds;
        }
        /// <summary>
        /// Contstruct TimePeriod object from provided time values.
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public TimePeriod(short hours, short minutes, short seconds)
        {
            if (hours < 0 || minutes < 0 || seconds < 0) throw new ArgumentException("Invalid arguments! Params cannot be negative.");
            else
            {
                Duration = hours * 3600 + minutes *60 + seconds;
            }
        }
        /// <summary>
        /// Construct TimePeriod object from provided time values.
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        public TimePeriod(short hours, short minutes) :this(hours,minutes,0)
        {
        }

        /// <summary>
        /// Construct TimePeriod object from provided time values.
        /// </summary>
        /// <param name="hours"></param>
        public TimePeriod(short hours) : this(hours, 0, 0)
        {
        }

        /// <summary>
        /// Construct TimePeriod object from provided Time objects.
        /// New TimePeriod object is based on difference between first time object and second time object.
        /// </summary>
        /// <param name="time2"></param>
        /// <param name="time1"></param>
        public TimePeriod(Time time2, Time time1)
        {
            Time result = time2 - time1;
            short hours = result.Hours;
            short mins = result.Minutes;
            short secs = result.Seconds;

            this = new TimePeriod(hours, mins, secs);
        }
        /// <summary>
        /// Construct TimePeriod object from string in format HHHH:MM:SS
        /// </summary>
        /// <param name="timePeriodString">String in format HHHH:MM:SS</param>
        public TimePeriod(string timePeriodString)
        {
            string pattern = "0000:00:00";
            if (timePeriodString is null) throw new ArgumentNullException("Time string cannot be null");
            else
            {
                if (timePeriodString.Length != pattern.Length) throw new ArgumentException("Invalid time string length.");
                else
                {
                    if (timePeriodString.ElementAt(4) != pattern.ElementAt(4) || timePeriodString.ElementAt(7) != pattern.ElementAt(7))
                        throw new ArgumentException("Invalid string format! Should be HHHH:MM:SS");
                    else
                    {
                        short hh, mm, ss = 0;
                        string tmp = timePeriodString.Substring(0, 4);
                        bool parse = short.TryParse(tmp, out hh);
                        if (!parse)
                        {
                            throw new ArgumentException("Invalid string format! Time cannot contain letters.");
                        }

                        tmp = timePeriodString.Substring(5, 2);
                        parse = short.TryParse(tmp, out mm);
                        if (!parse)
                        {
                            throw new ArgumentException("Invalid string format! Time cannot contain letters.");
                        }

                        tmp = timePeriodString.Substring(8, 2);
                        parse = short.TryParse(tmp, out ss);
                        if (!parse)
                        {
                            throw new ArgumentException("Invalid string format! Time cannot contain letters.");
                        }


                        this = new TimePeriod(hh, mm, ss);
                    }
                }
            }
        }
        #endregion

        #region OVERRIDES

        /// <summary>
        /// Returns TimePeriod string representation in HHH:MM:SS format.
        /// Optionally it can be HH:MM:SS format for hour values lower than 100.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(Hours > 99)
            {
                StringBuilder stringBuilder = new StringBuilder(Hours.ToString("000") + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00"));
                return stringBuilder.ToString();
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder(Hours.ToString("00") + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00"));
                return stringBuilder.ToString();
            }
        }
        /// <summary>
        /// Comparsion method for TimePeriod objects.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TimePeriod other)
        {
            if (this.Duration > other.Duration) return 1;
            else if (this.Duration < other.Duration) return -1;
            else return 0;
        }
        /// <summary>
        /// Checks if two TimePeriod objects are equal.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(TimePeriod other)
        {
            if (this.Duration == other.Duration) return true;
            else return false;
        }
        /// <summary>
        /// Checks if two TimePeriod objects are equal.
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator ==(TimePeriod time1, TimePeriod time2) => time1.Equals(time2);
        /// <summary>
        /// Checks if two TimePeriod objects are not equal.
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator !=(TimePeriod time1, TimePeriod time2) => !time1.Equals(time2);
        /// <summary>
        /// Checks if one of TimePeriod objects if bigger from another.
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator >(TimePeriod time1, TimePeriod time2)
        {
            if (time1.Duration > time2.Duration) return true;
            else return false;
        }
        /// <summary>
        /// Checks if one of TimePeriod objects is lower than another.
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator <(TimePeriod time1, TimePeriod time2)
        {
            if (time1.Duration < time2.Duration) return true;
            else return false;
        }
        /// <summary>
        /// Checks if one of TimePeriod objects is bigger or equals another.
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator >=(TimePeriod time1, TimePeriod time2)
        {
            if (time1.Duration >= time2.Duration) return true;
            else return false;
        }
        /// <summary>
        /// Checks if one of TimePeriod objects is lower or equals another.
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool operator <=(TimePeriod time1, TimePeriod time2)
        {
            if (time1.Duration <= time2.Duration) return true;
            else return false;
        }
        /// <summary>
        /// Adds two TimePeriod objects and returns new TimePeriod object.
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns></returns>
        public static TimePeriod operator +(TimePeriod tp1, TimePeriod tp2)
        {
            long newDuration = tp1.Duration + tp2.Duration;
            return new TimePeriod(newDuration);
        }
        /// <summary>
        /// Substracts two TimePeriod objects and returns new TimePeriod object.
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns></returns>
        public static TimePeriod operator -(TimePeriod tp1, TimePeriod tp2)
        {
            long newDuration = tp1.Duration - tp2.Duration;
            return new TimePeriod(newDuration);
        }        
        /// <summary>
        /// Multiply TimePeriod by constant value.
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static TimePeriod operator *(TimePeriod tp1, int multiplier)
        {
            long newDuration = tp1.Duration * multiplier;
            return new TimePeriod(newDuration);
        }
        public static TimePeriod operator *(int multiplier, TimePeriod tp1)
        {
            long newDuration = tp1.Duration * multiplier;
            return new TimePeriod(newDuration);
        }
        #endregion

        #region CUSTOM_ARITHMETICS
        /// <summary>
        /// Sums two TimePeriod objects.
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public TimePeriod Plus(TimePeriod tp)
        {
            return this + tp;
        }
        /// <summary>
        /// Static version of Plus method.
        /// </summary>
        /// <param name="tp1"></param>
        /// <param name="tp2"></param>
        /// <returns></returns>
        public static TimePeriod Plus(TimePeriod tp1, TimePeriod tp2)
        {
            return tp1 + tp2;
        }
        #endregion  
    }
}
