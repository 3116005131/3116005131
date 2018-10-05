using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct5th
{
    class Program
    {
        public class cnCalendarDemo
        {
            int cnYear;                 //年份(甲子)            
            int cnYearCelestialStem;    //年份天干
            int cnYearTerrestrialBranch;//年份地支
            int cnMonth;                //月份
            int cnLeapMonth;            //闰月
            int cnDay;                  //日子
            //年份用，天干与地支数组
            string[] arrCelestialStem = { "", "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
            string[] arrTerrestriaBranch = { "", "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "酉", "戌", "亥" };
            //月份名称
            string[] arrMonthName = { "", "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "冬月", "腊月" };
            //日子
            string[] arrDayName = { "", "初一", "初二", "初三", "初四", "初五", "初六", "初七", "初八", "初九", "初十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十", "廿一", "廿二", "廿三", "廿四", "廿五", "廿六", "廿七", "廿八", "廿九", "三十" };
            public cnCalendarDemo(DateTime date)
            {   
                //农历日历
                ChineseLunisolarCalendar cnCalendar = new ChineseLunisolarCalendar();
                cnYear = cnCalendar.GetSexagenaryYear(date);
                cnYearCelestialStem = cnCalendar.GetCelestialStem(cnYear);
                cnYearTerrestrialBranch = cnCalendar.GetTerrestrialBranch(cnYear);
                cnMonth = cnCalendar.GetMonth(date);
                cnDay = cnCalendar.GetDayOfMonth(date);
                cnLeapMonth = 0;
                if (date.Month < 3 && cnMonth > 9)
                {
                    cnLeapMonth = cnCalendar.GetLeapMonth(date.Year - 1);
                }
                else
                {
                    cnLeapMonth = cnCalendar.GetLeapMonth(date.Year);
                }
            }//初始化
            public void showCnYear()
            {
                Console.WriteLine(arrCelestialStem[cnYearCelestialStem] + arrTerrestriaBranch[cnYearTerrestrialBranch] + "年");
            } //显示年份，天干+地支
            public void showCnMonth()
            {
                if (cnLeapMonth==0||cnMonth<cnLeapMonth)
                {
                    Console.WriteLine(arrMonthName[cnMonth]);
                }
                else if (cnMonth==cnLeapMonth)
                {
                    Console.WriteLine("闰" + arrMonthName[cnMonth - 1]);
                }
                else
                {
                    Console.WriteLine(arrMonthName[cnMonth - 1]);
                }
            }//显示月份，注意闰月情况
            public void showDay()
            {
                Console.WriteLine(arrDayName[cnDay]);
            }//显示日子
        }//农历信息(表驱动法)以空间换取时间
        static void Main(string[] args)
        {
            //类cnCalenderDemo的测试代码
            DateTime date = new DateTime(1997, 10, 30);//我的阳历生日
            cnCalendarDemo ccd = new cnCalendarDemo(date);
            ccd.showCnYear();
            ccd.showCnMonth();
            ccd.showDay();
            Console.ReadLine();
        }
    }
}
